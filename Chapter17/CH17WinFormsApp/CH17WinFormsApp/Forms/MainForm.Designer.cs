using System;
using System.Drawing;
using System.Windows.Forms;

namespace CH17WinFormsApp;

public partial class MainForm : Form
{
    private MenuStrip menuMain = null!;
    private ToolStripMenuItem patientsMenu = null!;
    private ToolStripMenuItem miRegisterNew = null!;
    private ToolStripMenuItem miSearch = null!;
    private ToolStripMenuItem miManage = null!;
    private StatusStrip statusMain = null!;
    private ToolStripStatusLabel lblStatus = null!;
    private TabControl tabWorkspace = null!;

    private void InitializeComponent()
    {
        // ----- Form -----
        Text = "VCMS — Veterinary Clinic Management System";
        StartPosition = FormStartPosition.CenterScreen;
        AutoScaleMode = AutoScaleMode.Dpi;
        MinimumSize = new Size(900, 600);
        KeyPreview = true;

        // ----- MenuStrip -----
        menuMain = new MenuStrip { Dock = DockStyle.Top };

        patientsMenu = new ToolStripMenuItem("Patients");
        miRegisterNew = new ToolStripMenuItem("Register New");
        miSearch = new ToolStripMenuItem("Search");
        miManage = new ToolStripMenuItem("Manage Records");
        patientsMenu.DropDownItems.AddRange(new ToolStripItem[]
        {
            miRegisterNew, miSearch, miManage
        });

        var appointmentsMenu = new ToolStripMenuItem("Appointments");
        appointmentsMenu.DropDownItems.AddRange(new[]
        {
            new ToolStripMenuItem("New"),
            new ToolStripMenuItem("Calendar"),
            new ToolStripMenuItem("Today")
        });

        var billingMenu = new ToolStripMenuItem("Billing");
        billingMenu.DropDownItems.AddRange(new[]
        {
            new ToolStripMenuItem("Create Invoice"),
            new ToolStripMenuItem("Receive Payment")
        });

        var inventoryMenu = new ToolStripMenuItem("Inventory");
        inventoryMenu.DropDownItems.AddRange(new[]
        {
            new ToolStripMenuItem("Items"),
            new ToolStripMenuItem("Orders")
        });

        var reportsMenu = new ToolStripMenuItem("Reports");
        reportsMenu.DropDownItems.AddRange(new[]
        {
            new ToolStripMenuItem("Daily Summary"),
            new ToolStripMenuItem("Patient List")
        });

        var helpMenu = new ToolStripMenuItem("Help");
        helpMenu.DropDownItems.Add("About");

        menuMain.Items.AddRange(new ToolStripItem[]
        {
            patientsMenu, appointmentsMenu, billingMenu, inventoryMenu, reportsMenu, helpMenu
        });

        // ----- TabControl (workspace) -----
        tabWorkspace = new TabControl { Dock = DockStyle.Fill };
        var tpHome = new TabPage("Home");
        var lblWelcome = new Label
        {
            Text = "Welcome to VCMS. Use the menu to begin.",
            AutoSize = true,
            Font = new Font("Segoe UI", 11, FontStyle.Regular),
            Location = new Point(16, 16)
        };
        tpHome.Controls.Add(lblWelcome);
        tabWorkspace.TabPages.Add(tpHome);

        // ----- StatusStrip -----
        statusMain = new StatusStrip();
        lblStatus = new ToolStripStatusLabel("Ready");
        statusMain.Items.Add(lblStatus);

        // ----- Add to Form -----
        Controls.Add(tabWorkspace);
        Controls.Add(statusMain);
        Controls.Add(menuMain);
    }
}
