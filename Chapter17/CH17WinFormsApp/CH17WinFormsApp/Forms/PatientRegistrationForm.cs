using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CH17WinFormsApp;
public partial class PatientRegistrationForm : Form
{
    private bool _hasUnsavedChanges;

    public PatientRegistrationForm()
    {
        InitializeComponent();
        WireEvents();
    }

    private void WireEvents()
    {
        Load += (_, __) =>
        {
            _hasUnsavedChanges = false;
            txtPetName.Focus();
        };

        FormClosing += (s, e) =>
        {
            if (_hasUnsavedChanges && DialogResult != DialogResult.OK)
            {
                var choice = MessageBox.Show(
                    "You have unsaved changes. Exit without saving?",
                    "VCMS",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (choice == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        };

        // Change tracking
        txtPetName.TextChanged += AnyChanged;
        cboSpecies.SelectedIndexChanged += AnyChanged;
        numAgeYears.ValueChanged += AnyChanged;
        txtOwnerName.TextChanged += AnyChanged;
        txtNotes.TextChanged += AnyChanged;

        // Validation
        txtPetName.Validating += ValidatePetName;
        cboSpecies.Validating += ValidateSpecies;
        txtOwnerName.Validating += ValidateOwner;

        // Buttons
        btnCancel.Click += (_, __) => { DialogResult = DialogResult.Cancel; Close(); };
        btnSave.Click += Save_Click;
    }

    private void AnyChanged(object? sender, EventArgs e) => _hasUnsavedChanges = true;

    private void ValidatePetName(object? sender, CancelEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtPetName.Text))
        {
            errorProvider.SetError(txtPetName, "Pet name is required.");
            e.Cancel = true;
        }
        else errorProvider.SetError(txtPetName, string.Empty);
    }

    private void ValidateSpecies(object? sender, CancelEventArgs e)
    {
        if (cboSpecies.SelectedItem is null)
        {
            errorProvider.SetError(cboSpecies, "Select a species.");
            e.Cancel = true;
        }
        else errorProvider.SetError(cboSpecies, string.Empty);
    }

    private void ValidateOwner(object? sender, CancelEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtOwnerName.Text))
        {
            errorProvider.SetError(txtOwnerName, "Owner name is required.");
            e.Cancel = true;
        }
        else errorProvider.SetError(txtOwnerName, string.Empty);
    }

    private void Save_Click(object? sender, EventArgs e)
    {
        if (!ValidateChildren())
        {
            MessageBox.Show("Fix validation errors and try again.", "VCMS",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var petName = txtPetName.Text.Trim();
        var species = cboSpecies.SelectedItem?.ToString() ?? "";
        var age = (int)numAgeYears.Value;
        var owner = txtOwnerName.Text.Trim();

        MessageBox.Show(
            $"Record saved for {petName} ({species}, {age} year(s)). Owner: {owner}",
            "VCMS — Record Saved",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        _hasUnsavedChanges = false;
        DialogResult = DialogResult.OK;
        Close();
    }
}
