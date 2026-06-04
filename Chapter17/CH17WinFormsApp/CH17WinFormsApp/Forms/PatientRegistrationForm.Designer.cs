using System.Drawing;
using System.Windows.Forms;

namespace CH17WinFormsApp;
public partial class PatientRegistrationForm : Form
{
    private TableLayoutPanel table = null!;
    private Label lblPetName = null!;
    private TextBox txtPetName = null!;
    private Label lblSpecies = null!;
    private ComboBox cboSpecies = null!;
    private Label lblAgeYears = null!;
    private NumericUpDown numAgeYears = null!;
    private Label lblOwnerName = null!;
    private TextBox txtOwnerName = null!;
    private Label lblNotes = null!;
    private TextBox txtNotes = null!;
    private Button btnSave = null!;
    private Button btnCancel = null!;
    private ErrorProvider errorProvider = null!;

    private void InitializeComponent()
    {
        Text = "VCMS — Register New Patient";
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        AutoScaleMode = AutoScaleMode.Dpi;
        Width = 640;
        Height = 420;

        errorProvider = new ErrorProvider
        {
            BlinkStyle = ErrorBlinkStyle.NeverBlink
        };

        table = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            ColumnCount = 2,
            RowCount = 5,
            Padding = new Padding(12),
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink
        };
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));

        lblPetName = new Label { Text = "&Pet name:", AutoSize = true, Anchor = AnchorStyles.Left };
        txtPetName = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right, MaxLength = 60 };

        lblSpecies = new Label { Text = "&Species:", AutoSize = true, Anchor = AnchorStyles.Left };
        cboSpecies = new ComboBox
        {
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        cboSpecies.Items.AddRange(new object[] { "Dog", "Cat", "Bird", "Reptile", "Other" });

        lblAgeYears = new Label { Text = "Age (years):", AutoSize = true, Anchor = AnchorStyles.Left };
        numAgeYears = new NumericUpDown
        {
            Anchor = AnchorStyles.Left,
            Minimum = 0,
            Maximum = 60,
            DecimalPlaces = 0,
            Value = 0
        };

        lblOwnerName = new Label { Text = "&Owner name:", AutoSize = true, Anchor = AnchorStyles.Left };
        txtOwnerName = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right, MaxLength = 80 };

        lblNotes = new Label { Text = "Notes:", AutoSize = true, Anchor = AnchorStyles.Left };
        txtNotes = new TextBox
        {
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            Height = 80
        };

        table.Controls.Add(lblPetName, 0, 0);
        table.Controls.Add(txtPetName, 1, 0);
        table.Controls.Add(lblSpecies, 0, 1);
        table.Controls.Add(cboSpecies, 1, 1);
        table.Controls.Add(lblAgeYears, 0, 2);
        table.Controls.Add(numAgeYears, 1, 2);
        table.Controls.Add(lblOwnerName, 0, 3);
        table.Controls.Add(txtOwnerName, 1, 3);
        table.Controls.Add(lblNotes, 0, 4);
        table.Controls.Add(txtNotes, 1, 4);

        var buttonPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 52,
            Padding = new Padding(12)
        };

        btnSave = new Button { Text = "Save", Width = 100, Anchor = AnchorStyles.Right | AnchorStyles.Bottom };
        btnCancel = new Button { Text = "Cancel", Width = 100, Anchor = AnchorStyles.Right | AnchorStyles.Bottom };

        // Position buttons relative to right edge
        btnCancel.Location = new Point(ClientSize.Width - btnCancel.Width - 24, 12);
        btnSave.Location = new Point(btnCancel.Left - btnSave.Width - 8, 12);
        buttonPanel.Controls.Add(btnCancel);
        buttonPanel.Controls.Add(btnSave);

        var root = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
        root.Controls.Add(table);

        Controls.Add(root);
        Controls.Add(buttonPanel);

        AcceptButton = btnSave;
        CancelButton = btnCancel;
    }
}
