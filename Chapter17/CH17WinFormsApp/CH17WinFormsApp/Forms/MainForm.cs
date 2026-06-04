using System;
using System.Windows.Forms;

namespace CH17WinFormsApp;

public partial class MainForm : Form
{
    private System.Windows.Forms.Timer? _statusTimer;

    public MainForm()
    {
        InitializeComponent();
        WireEvents();
    }

    private void WireEvents()
    {
        // Patients ▸ Register New
        miRegisterNew.Click += (_, __) =>
        {
            using var dlg = new PatientRegistrationForm();
            var result = dlg.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                lblStatus.Text = "New patient record saved.";
                ShowTransientStatus();
            }
        };

        // Patients ▸ Search placeholder (keeps sample navigation behavior)
        miSearch.Click += (_, __) =>
        {
            var tp = new TabPage("Patient Search");
            tp.Controls.Add(new Label
            {
                Text = "Search screen placeholder",
                AutoSize = true,
                Location = new System.Drawing.Point(16, 16)
            });
            tabWorkspace.TabPages.Add(tp);
            tabWorkspace.SelectedTab = tp;
            lblStatus.Text = "Opened Patient Search.";
            ShowTransientStatus();
        };

        // Example keyboard shortcut
        KeyDown += (s, e) =>
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                lblStatus.Text = "Shortcut received (Ctrl+S).";
                ShowTransientStatus();
            }
        };
    }

private void ShowTransientStatus()
    {
        if (_statusTimer is null)
        {
            _statusTimer = new System.Windows.Forms.Timer { Interval = 2500 };
            _statusTimer.Tick += ClearStatus;   // hook once
        }

        _statusTimer.Stop();
        _statusTimer.Start();
    }

    // Correct Tick signature: (object? sender, EventArgs e)
    private void ClearStatus(object? sender, EventArgs e)
    {
        lblStatus.Text = "Ready";
        _statusTimer?.Stop();
    }
}