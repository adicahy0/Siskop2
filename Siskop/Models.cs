using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siskop;
namespace View
{
 
    // VIEW - Your UI components
    // Views observe the Model and update themselves when it changes
    public partial class NasabahListView : UserControl
    {
        private NasabahModel model;
        private ListBox listBox;

        public NasabahListView(NasabahModel model)
        {
            this.model = model;
            InitializeComponent();

            // Subscribe to model changes
            model.DataChanged += UpdateDisplay;
            UpdateDisplay(); // Initial display
        }

        private void InitializeComponent()
        {
            listBox = new ListBox();
            listBox.Dock = DockStyle.Fill;
            this.Controls.Add(listBox);
        }

        private void UpdateDisplay()
        {
            listBox.Items.Clear();
            foreach (var Nasabah in model.GetNasabahs())
            {
                listBox.Items.Add($"{Nasabah.Nama} (: {Nasabah.Age})");
            }
        }

        // Views can expose events for controllers to handle
        public event Action<int> NasabahSelected;

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)
                NasabahSelected?.Invoke(listBox.SelectedIndex);
        }
    }

    // Another view of the same data
    public partial class NasabahCountView : UserControl
    {
        private NasabahModel model;
        private Label countLabel;

        public NasabahCountView(NasabahModel model)
        {
            this.model = model;
            InitializeComponent();

            // Same model, different view
            model.DataChanged += UpdateDisplay;
            UpdateDisplay();
        }

        private void InitializeComponent()
        {
            countLabel = new Label();
            countLabel.Text = "Total Nasabahs: 0";
            countLabel.Dock = DockStyle.Fill;
            this.Controls.Add(countLabel);
        }

        private void UpdateDisplay()
        {
            countLabel.Text = $"Total Nasabahs: {model.GetNasabahs().Count}";
        }
    }

    // CONTROLLER - Handles user input and coordinates between Model and View
    public class NasabahController
    {
        private NasabahModel model;
        private Form mainForm;

        public NasabahController(NasabahModel model, Form mainForm)
        {
            this.model = model;
            this.mainForm = mainForm;
            SetupUI();
        }

        private void SetupUI()
        {
            // Create views
            var listView = new NasabahListView(model);
            var countView = new NasabahCountView(model);

            // Create input controls
            var nameTextBox = new TextBox { PlaceholderText = "Nasabah Name" };
            var ageTextBox = new TextBox { PlaceholderText = "Age" };
            var addButton = new Button { Text = "Add Nasabah" };
            var removeButton = new Button { Text = "Remove Selected" };

            // Wire up controller logic to handle user input
            addButton.Click += (s, e) => HandleAddNasabah(nameTextBox.Text, ageTextBox.Text);
            removeButton.Click += (s, e) => HandleRemoveNasabah();

            // Listen to view events
            listView.NasabahSelected += (index) => selectedIndex = index;

            // Layout (simplified)
            var inputPanel = new Panel { Height = 30, Dock = DockStyle.Top };
            inputPanel.Controls.AddRange(new Control[] { nameTextBox, ageTextBox, addButton, removeButton });

            var splitContainer = new SplitContainer { Dock = DockStyle.Fill, Orientation = Orientation.Horizontal };
            splitContainer.Panel1.Controls.Add(listView);
            splitContainer.Panel2.Controls.Add(countView);

            mainForm.Controls.Add(splitContainer);
            mainForm.Controls.Add(inputPanel);
        }

        private int selectedIndex = -1;

        private void HandleAddNasabah(string name, string alamat)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            if (!int.TryParse(ageText, out int age)) return;

            // Controller tells Model what to do
            model.AddNasabah(name, alamat);
        }

        private void HandleRemoveNasabah()
        {
            if (selectedIndex >= 0)
            {
                model.RemoveNasabah(selectedIndex);
                selectedIndex = -1;
            }
        }
    }

}
