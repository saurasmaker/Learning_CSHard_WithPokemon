namespace PokemonShowdown.Forms
{
    partial class Index
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTeamsSubmenu = new System.Windows.Forms.Panel();
            this.btnRemoveTeam = new System.Windows.Forms.Button();
            this.btnEditTeam = new System.Windows.Forms.Button();
            this.btnCreateTeam = new System.Windows.Forms.Button();
            this.btnTeams = new System.Windows.Forms.Button();
            this.panelPokedexToolsSubmenu = new System.Windows.Forms.Panel();
            this.btnShowPokedex = new System.Windows.Forms.Button();
            this.btnRemovePokeFromPokedex = new System.Windows.Forms.Button();
            this.btnUpdatePokeFromPokedex = new System.Windows.Forms.Button();
            this.btnAddPokeToPokedex = new System.Windows.Forms.Button();
            this.btnShowPokeFromPokedex = new System.Windows.Forms.Button();
            this.btnPokedexTools = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.panelLeft.SuspendLayout();
            this.panelTeamsSubmenu.SuspendLayout();
            this.panelPokedexToolsSubmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 583);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1192, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1192, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1192, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.Controls.Add(this.panelTeamsSubmenu);
            this.panelLeft.Controls.Add(this.btnTeams);
            this.panelLeft.Controls.Add(this.panelPokedexToolsSubmenu);
            this.panelLeft.Controls.Add(this.btnPokedexTools);
            this.panelLeft.Controls.Add(this.panelLogo);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 49);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(250, 534);
            this.panelLeft.TabIndex = 3;
            // 
            // panelTeamsSubmenu
            // 
            this.panelTeamsSubmenu.Controls.Add(this.btnRemoveTeam);
            this.panelTeamsSubmenu.Controls.Add(this.btnEditTeam);
            this.panelTeamsSubmenu.Controls.Add(this.btnCreateTeam);
            this.panelTeamsSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTeamsSubmenu.Location = new System.Drawing.Point(0, 397);
            this.panelTeamsSubmenu.Name = "panelTeamsSubmenu";
            this.panelTeamsSubmenu.Size = new System.Drawing.Size(250, 125);
            this.panelTeamsSubmenu.TabIndex = 2;
            // 
            // btnRemoveTeam
            // 
            this.btnRemoveTeam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemoveTeam.FlatAppearance.BorderSize = 0;
            this.btnRemoveTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTeam.Location = new System.Drawing.Point(0, 80);
            this.btnRemoveTeam.Name = "btnRemoveTeam";
            this.btnRemoveTeam.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRemoveTeam.Size = new System.Drawing.Size(250, 40);
            this.btnRemoveTeam.TabIndex = 0;
            this.btnRemoveTeam.Text = "Remove Team";
            this.btnRemoveTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveTeam.UseVisualStyleBackColor = true;
            // 
            // btnEditTeam
            // 
            this.btnEditTeam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditTeam.FlatAppearance.BorderSize = 0;
            this.btnEditTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTeam.Location = new System.Drawing.Point(0, 40);
            this.btnEditTeam.Name = "btnEditTeam";
            this.btnEditTeam.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnEditTeam.Size = new System.Drawing.Size(250, 40);
            this.btnEditTeam.TabIndex = 0;
            this.btnEditTeam.Text = "Edit Team";
            this.btnEditTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditTeam.UseVisualStyleBackColor = true;
            // 
            // btnCreateTeam
            // 
            this.btnCreateTeam.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateTeam.FlatAppearance.BorderSize = 0;
            this.btnCreateTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTeam.Location = new System.Drawing.Point(0, 0);
            this.btnCreateTeam.Name = "btnCreateTeam";
            this.btnCreateTeam.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnCreateTeam.Size = new System.Drawing.Size(250, 40);
            this.btnCreateTeam.TabIndex = 0;
            this.btnCreateTeam.Text = "Create Team";
            this.btnCreateTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateTeam.UseVisualStyleBackColor = true;
            // 
            // btnTeams
            // 
            this.btnTeams.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTeams.FlatAppearance.BorderSize = 0;
            this.btnTeams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeams.Location = new System.Drawing.Point(0, 352);
            this.btnTeams.Name = "btnTeams";
            this.btnTeams.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTeams.Size = new System.Drawing.Size(250, 45);
            this.btnTeams.TabIndex = 0;
            this.btnTeams.Text = "Teams";
            this.btnTeams.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeams.UseVisualStyleBackColor = true;
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);
            // 
            // panelPokedexToolsSubmenu
            // 
            this.panelPokedexToolsSubmenu.Controls.Add(this.btnShowPokedex);
            this.panelPokedexToolsSubmenu.Controls.Add(this.btnRemovePokeFromPokedex);
            this.panelPokedexToolsSubmenu.Controls.Add(this.btnUpdatePokeFromPokedex);
            this.panelPokedexToolsSubmenu.Controls.Add(this.btnAddPokeToPokedex);
            this.panelPokedexToolsSubmenu.Controls.Add(this.btnShowPokeFromPokedex);
            this.panelPokedexToolsSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPokedexToolsSubmenu.Location = new System.Drawing.Point(0, 145);
            this.panelPokedexToolsSubmenu.Name = "panelPokedexToolsSubmenu";
            this.panelPokedexToolsSubmenu.Size = new System.Drawing.Size(250, 207);
            this.panelPokedexToolsSubmenu.TabIndex = 1;
            // 
            // btnShowPokedex
            // 
            this.btnShowPokedex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowPokedex.FlatAppearance.BorderSize = 0;
            this.btnShowPokedex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPokedex.Location = new System.Drawing.Point(0, 160);
            this.btnShowPokedex.Name = "btnShowPokedex";
            this.btnShowPokedex.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnShowPokedex.Size = new System.Drawing.Size(250, 40);
            this.btnShowPokedex.TabIndex = 0;
            this.btnShowPokedex.Text = "Show Pokédex";
            this.btnShowPokedex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowPokedex.UseVisualStyleBackColor = true;
            // 
            // btnRemovePokeFromPokedex
            // 
            this.btnRemovePokeFromPokedex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRemovePokeFromPokedex.FlatAppearance.BorderSize = 0;
            this.btnRemovePokeFromPokedex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePokeFromPokedex.Location = new System.Drawing.Point(0, 120);
            this.btnRemovePokeFromPokedex.Name = "btnRemovePokeFromPokedex";
            this.btnRemovePokeFromPokedex.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRemovePokeFromPokedex.Size = new System.Drawing.Size(250, 40);
            this.btnRemovePokeFromPokedex.TabIndex = 0;
            this.btnRemovePokeFromPokedex.Text = "Remove Pokémon";
            this.btnRemovePokeFromPokedex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemovePokeFromPokedex.UseVisualStyleBackColor = true;
            // 
            // btnUpdatePokeFromPokedex
            // 
            this.btnUpdatePokeFromPokedex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUpdatePokeFromPokedex.FlatAppearance.BorderSize = 0;
            this.btnUpdatePokeFromPokedex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePokeFromPokedex.Location = new System.Drawing.Point(0, 80);
            this.btnUpdatePokeFromPokedex.Name = "btnUpdatePokeFromPokedex";
            this.btnUpdatePokeFromPokedex.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnUpdatePokeFromPokedex.Size = new System.Drawing.Size(250, 40);
            this.btnUpdatePokeFromPokedex.TabIndex = 0;
            this.btnUpdatePokeFromPokedex.Text = "Update Pokémon";
            this.btnUpdatePokeFromPokedex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdatePokeFromPokedex.UseVisualStyleBackColor = true;
            // 
            // btnAddPokeToPokedex
            // 
            this.btnAddPokeToPokedex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddPokeToPokedex.FlatAppearance.BorderSize = 0;
            this.btnAddPokeToPokedex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPokeToPokedex.Location = new System.Drawing.Point(0, 40);
            this.btnAddPokeToPokedex.Name = "btnAddPokeToPokedex";
            this.btnAddPokeToPokedex.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAddPokeToPokedex.Size = new System.Drawing.Size(250, 40);
            this.btnAddPokeToPokedex.TabIndex = 0;
            this.btnAddPokeToPokedex.Text = "Add Pokémon";
            this.btnAddPokeToPokedex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPokeToPokedex.UseVisualStyleBackColor = true;
            this.btnAddPokeToPokedex.Click += new System.EventHandler(this.btnAddPokeToPokedex_Click);
            // 
            // btnShowPokeFromPokedex
            // 
            this.btnShowPokeFromPokedex.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShowPokeFromPokedex.FlatAppearance.BorderSize = 0;
            this.btnShowPokeFromPokedex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPokeFromPokedex.Location = new System.Drawing.Point(0, 0);
            this.btnShowPokeFromPokedex.Name = "btnShowPokeFromPokedex";
            this.btnShowPokeFromPokedex.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnShowPokeFromPokedex.Size = new System.Drawing.Size(250, 40);
            this.btnShowPokeFromPokedex.TabIndex = 0;
            this.btnShowPokeFromPokedex.Text = "Show Pokémon";
            this.btnShowPokeFromPokedex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowPokeFromPokedex.UseVisualStyleBackColor = true;
            this.btnShowPokeFromPokedex.Click += new System.EventHandler(this.btnShowPokeFromPokedex_Click);
            // 
            // btnPokedexTools
            // 
            this.btnPokedexTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPokedexTools.FlatAppearance.BorderSize = 0;
            this.btnPokedexTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPokedexTools.Location = new System.Drawing.Point(0, 100);
            this.btnPokedexTools.Name = "btnPokedexTools";
            this.btnPokedexTools.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPokedexTools.Size = new System.Drawing.Size(250, 45);
            this.btnPokedexTools.TabIndex = 0;
            this.btnPokedexTools.Text = "Pokédex Tools";
            this.btnPokedexTools.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPokedexTools.UseVisualStyleBackColor = true;
            this.btnPokedexTools.Click += new System.EventHandler(this.btnPokedexTools_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // panelChildForm
            // 
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 49);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(942, 534);
            this.panelChildForm.TabIndex = 4;
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 605);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Index";
            this.panelLeft.ResumeLayout(false);
            this.panelTeamsSubmenu.ResumeLayout(false);
            this.panelPokedexToolsSubmenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnPokedexTools;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelPokedexToolsSubmenu;
        private System.Windows.Forms.Button btnShowPokeFromPokedex;
        private System.Windows.Forms.Button btnAddPokeToPokedex;
        private System.Windows.Forms.Button btnUpdatePokeFromPokedex;
        private System.Windows.Forms.Button btnRemovePokeFromPokedex;
        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Button btnShowPokedex;
        private System.Windows.Forms.Panel panelTeamsSubmenu;
        private System.Windows.Forms.Button btnRemoveTeam;
        private System.Windows.Forms.Button btnEditTeam;
        private System.Windows.Forms.Button btnCreateTeam;
        private System.Windows.Forms.Panel panelChildForm;
    }
}