using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Dapper;
using Npgsql;

namespace Siskop
{
    public class NasabahModel
    {
        private List<Nasabah> Nasabahs = new List<Nasabah>();
        private readonly string connectionString;

        // Event for notifying views when data changes
        public event Action DataChanged;

        public NasabahModel(string connectionString)
        {
            this.connectionString = connectionString;
            LoadFromDatabase(); // Load initial data
        }

        public async Task AddNasabah(string name, string alamat, string pekerjaan)
        {
            var nasabah = new Nasabah { Nama = name, Alamat = alamat, Pekerjaan = pekerjaan };

            using var connection = new NpgsqlConnection(connectionString);

            // Using Dapper's ExecuteScalarAsync for insertion with returning ID
            var sql = @"INSERT INTO Nasabahs (Nama, Alamat, Pekerjaan) 
                        VALUES (@Nama, @Alamat, @Pekerjaan) 
                        RETURNING Id";

            nasabah.Id = await connection.ExecuteScalarAsync<int>(sql, nasabah);

            // Then update in-memory cache
            Nasabahs.Add(nasabah);
            DataChanged?.Invoke(); // Views update automatically
        }

        public async Task RemoveNasabah(int index)
        {
            if (index < 0 || index >= Nasabahs.Count) return;

            var nasabah = Nasabahs[index];

            using var connection = new NpgsqlConnection(connectionString);

            // Using Dapper's ExecuteAsync for deletion
            var sql = "DELETE FROM Nasabahs WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = nasabah.Id });

            // Then update in-memory cache
            Nasabahs.RemoveAt(index);
            DataChanged?.Invoke();
        }

        private async void LoadFromDatabase()
        {
            using var connection = new NpgsqlConnection(connectionString);

            // Using Dapper's QueryAsync for loading data
            var sql = "SELECT Id, Nama, Alamat, Pekerjaan FROM Nasabahs";
            Nasabahs = (await connection.QueryAsync<Nasabah>(sql)).ToList();

            DataChanged?.Invoke(); // Notify views after initial load
        }

        public List<Nasabah> GetNasabahs() => new List<Nasabah>(Nasabahs);

        // Method to refresh from database (useful for multi-user scenarios)
        public void RefreshFromDatabase() => LoadFromDatabase();
    }

    public class Nasabah
    {
        public int Id { get; set; }
        public required string Nama { get; set; }
        public required string Alamat { get; set; }
        public string Pekerjaan { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public User() { }

        public User(string username, string role, string password)
        {
            Username = username;
            Role = role;
            PasswordHash = HashPassword(password);
            CreatedAt = DateTime.Now;
        }

        public bool VerifyPassword(string password)
        {
            return PasswordHash == HashPassword(password);
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "MySalt123"));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    // AUTHENTICATION MODEL - Handles login/logout state and user management
    public class AuthModel
    {
        private readonly string connectionString;
        private User currentUser;

        // Events for notifying views about authentication state changes
        public event Action<User> UserLoggedIn;
        public event Action UserLoggedOut;
        public event Action<string> LoginFailed;
        public event Action<string> RegistrationFailed;
        public event Action<User> UserRegistered;

        public AuthModel(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User CurrentUser => currentUser;
        public bool IsLoggedIn => currentUser != null;

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                var user = await connection.QuerySingleOrDefaultAsync<User>(
                    "SELECT Id, Username, PasswordHash, Role, CreatedAt FROM Users WHERE Username = @Username",
                    new { Username = username });

                if (user == null)
                {
                    LoginFailed?.Invoke("Username not found");
                    return false;
                }

                if (!user.VerifyPassword(password))
                {
                    LoginFailed?.Invoke("Invalid password");
                    return false;
                }

                currentUser = user;
                UserLoggedIn?.Invoke(user);
                return true;
            }
            catch (Exception ex)
            {
                LoginFailed?.Invoke($"Login error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RegisterAsync(string username, string role, string password)
        {
            try
            {
                using var connection = new NpgsqlConnection(connectionString);

                // Check if username already exists
                var existingUser = await connection.QuerySingleOrDefaultAsync<User>(
                    "SELECT Id FROM Users WHERE Username = @Username",
                    new { Username = username });

                if (existingUser != null)
                {
                    RegistrationFailed?.Invoke("Username already exists");
                    return false;
                }

                // Create new user
                var user = new User(username, role, password);

                var sql = @"INSERT INTO Users (Username, PasswordHash, Role, CreatedAt) 
                       OUTPUT INSERTED.Id 
                       VALUES (@Username, @PasswordHash, @Role, @CreatedAt)";

                user.Id = await connection.QuerySingleAsync<int>(sql, user);

                UserRegistered?.Invoke(user);
                return true;
            }
            catch (Exception ex)
            {
                RegistrationFailed?.Invoke($"Registration error: {ex.Message}");
                return false;
            }
        }

        public void Logout()
        {
            currentUser = null;
            UserLoggedOut?.Invoke();
        }
    }
}