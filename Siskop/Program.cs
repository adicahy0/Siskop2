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

namespace Models
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
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "Nigger"));
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
                    "SELECT Id, Username, Password, Role, CreatedAt FROM Users WHERE Username = @Username",
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

public class PinjamanModel
{
    private List<Pinjaman> Pinjamans = new List<Pinjaman>();
    private readonly string connectionString;

    // Event for notifying views when data changes
    public event Action DataChanged;

    public PinjamanModel(string connectionString)
    {
        this.connectionString = connectionString;
        LoadFromDatabase(); // Load initial data
    }

    public async Task AddPinjaman(int idNasabah, decimal jumlahPinjaman, string keterangan, decimal bunga)
    {
        var pinjaman = new Pinjaman
        {
            Id_Nasabah = idNasabah.ToString(),
            Jumlah_pinjaman = jumlahPinjaman,
            Keterangan = keterangan,
            Bunga = bunga,
            Saldo_pinjaman = jumlahPinjaman, // Initially, saldo equals jumlah pinjaman
            CreatedAt = DateTime.Now
        };

        using var connection = new NpgsqlConnection(connectionString);

        var sql = @"INSERT INTO Pinjamans (Id_Nasabah, Jumlah_pinjaman, Keterangan, Bunga, Saldo_pinjaman, CreatedAt) 
                    VALUES (@Id_Nasabah, @Jumlah_pinjaman, @Keterangan, @Bunga, @Saldo_pinjaman, @CreatedAt) 
                    RETURNING ID_Pinjaman";

        pinjaman.ID_Pinjaman = await connection.ExecuteScalarAsync<string>(sql, pinjaman);

        // Update in-memory cache
        Pinjamans.Add(pinjaman);
        DataChanged?.Invoke(); // Views update automatically
    }

    public async Task RemovePinjaman(int index)
    {
        if (index < 0 || index >= Pinjamans.Count) return;

        var pinjaman = Pinjamans[index];

        using var connection = new NpgsqlConnection(connectionString);

        var sql = "DELETE FROM Pinjamans WHERE ID_Pinjaman = @ID_Pinjaman";
        await connection.ExecuteAsync(sql, new { ID_Pinjaman = pinjaman.ID_Pinjaman });

        // Update in-memory cache
        Pinjamans.RemoveAt(index);
        DataChanged?.Invoke();
    }

    public async Task UpdateSaldoPinjaman(string idPinjaman, decimal newSaldo)
    {
        var pinjaman = Pinjamans.FirstOrDefault(p => p.ID_Pinjaman == idPinjaman);
        if (pinjaman == null) return;

        using var connection = new NpgsqlConnection(connectionString);

        var sql = "UPDATE Pinjamans SET Saldo_pinjaman = @Saldo WHERE ID_Pinjaman = @ID_Pinjaman";
        await connection.ExecuteAsync(sql, new { Saldo = newSaldo, ID_Pinjaman = idPinjaman });

        // Update in-memory cache
        pinjaman.Saldo_pinjaman = newSaldo;
        DataChanged?.Invoke();
    }

    public async Task MakePayment(string idPinjaman, decimal paymentAmount)
    {
        var pinjaman = Pinjamans.FirstOrDefault(p => p.ID_Pinjaman == idPinjaman);
        if (pinjaman == null) return;

        if (paymentAmount <= 0 || paymentAmount > pinjaman.Saldo_pinjaman)
            throw new ArgumentException("Invalid payment amount");

        var newSaldo = pinjaman.Saldo_pinjaman - paymentAmount;
        await UpdateSaldoPinjaman(idPinjaman, newSaldo);
    }

    public async Task<List<Pinjaman>> GetPinjamansByNasabah(int idNasabah)
    {
        using var connection = new NpgsqlConnection(connectionString);

        var sql = @"SELECT ID_Pinjaman, Id_Nasabah, Jumlah_pinjaman, Keterangan, 
                           Bunga, Saldo_pinjaman, CreatedAt 
                    FROM Pinjamans 
                    WHERE Id_Nasabah = @Id_Nasabah 
                    ORDER BY CreatedAt DESC";

        var pinjamans = await connection.QueryAsync<Pinjaman>(sql, new { Id_Nasabah = idNasabah.ToString() });
        return pinjamans.ToList();
    }

    public async Task<decimal> GetTotalOutstandingDebt(int idNasabah)
    {
        using var connection = new NpgsqlConnection(connectionString);

        var sql = @"SELECT COALESCE(SUM(Saldo_pinjaman), 0) 
                    FROM Pinjamans 
                    WHERE Id_Nasabah = @Id_Nasabah AND Saldo_pinjaman > 0";

        return await connection.ExecuteScalarAsync<decimal>(sql, new { Id_Nasabah = idNasabah.ToString() });
    }

    public List<Pinjaman> GetActivePinjamans()
    {
        return Pinjamans.Where(p => p.Saldo_pinjaman > 0).ToList();
    }

    public List<Pinjaman> GetPaidOffPinjamans()
    {
        return Pinjamans.Where(p => p.Saldo_pinjaman == 0).ToList();
    }

    private async void LoadFromDatabase()
    {
        using var connection = new NpgsqlConnection(connectionString);

        var sql = @"SELECT ID_Pinjaman, Id_Nasabah, Jumlah_pinjaman, Keterangan, 
                           Bunga, Saldo_pinjaman, CreatedAt 
                    FROM Pinjamans 
                    ORDER BY CreatedAt DESC";

        Pinjamans = (await connection.QueryAsync<Pinjaman>(sql)).ToList();
        DataChanged?.Invoke(); // Notify views after initial load
    }

    public List<Pinjaman> GetPinjamans() => new List<Pinjaman>(Pinjamans);

    // Method to refresh from database (useful for multi-user scenarios)
    public void RefreshFromDatabase() => LoadFromDatabase();
}

public class Pinjaman
{
    public string ID_Pinjaman { get; set; }
    public string Id_Nasabah { get; set; }
    public decimal Jumlah_pinjaman { get; set; }
    public string Keterangan { get; set; }
    public decimal Bunga { get; set; }
    public decimal Saldo_pinjaman { get; set; }
    public DateTime CreatedAt { get; set; }

    // Constructor for creating new pinjaman
    public Pinjaman() { }

    public Pinjaman(int idNasabah, decimal jumlahPinjaman, string keterangan, decimal bunga)
    {
        Id_Nasabah = idNasabah.ToString();
        Jumlah_pinjaman = jumlahPinjaman;
        Keterangan = keterangan ?? "";
        Bunga = bunga;
        Saldo_pinjaman = jumlahPinjaman; // Initially full amount
        CreatedAt = DateTime.Now;
    }

    // Helper properties for business logic
    public decimal TotalAmountWithInterest => Jumlah_pinjaman + (Jumlah_pinjaman * Bunga / 100);
    public decimal AmountPaid => Jumlah_pinjaman - Saldo_pinjaman;
    public bool IsFullyPaid => Saldo_pinjaman == 0;
    public decimal InterestAmount => Jumlah_pinjaman * Bunga / 100;
}