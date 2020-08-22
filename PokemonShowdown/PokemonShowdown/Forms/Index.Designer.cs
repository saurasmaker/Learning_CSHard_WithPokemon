namespace PokemonShowdown
{
    partial class Index
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxEnterPokemonId = new System.Windows.Forms.TextBox();
            this.btnShowPokemon = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxShowPokemonData = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(696, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 305);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(696, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // menuStrip
            // 
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(696, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBoxEnterPokemonId);
            this.splitContainer1.Panel1.Controls.Add(this.btnShowPokemon);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(696, 256);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // textBoxEnterPokemonId
            // 
            this.textBoxEnterPokemonId.ForeColor = System.Drawing.Color.Gray;
            this.textBoxEnterPokemonId.Location = new System.Drawing.Point(3, 3);
            this.textBoxEnterPokemonId.Name = "textBoxEnterPokemonId";
            this.textBoxEnterPokemonId.Size = new System.Drawing.Size(226, 23);
            this.textBoxEnterPokemonId.TabIndex = 1;
            this.textBoxEnterPokemonId.Text = "Enter Pokémon Id...";
            this.textBoxEnterPokemonId.Enter += new System.EventHandler(this.textBoxEnterPokemonId_Enter);
            this.textBoxEnterPokemonId.Leave += new System.EventHandler(this.textBoxEnterPokemonId_Leave);
            // 
            // btnShowPokemon
            // 
            this.btnShowPokemon.Location = new System.Drawing.Point(3, 26);
            this.btnShowPokemon.Name = "btnShowPokemon";
            this.btnShowPokemon.Size = new System.Drawing.Size(226, 23);
            this.btnShowPokemon.TabIndex = 0;
            this.btnShowPokemon.Text = "Show Pokémon";
            this.btnShowPokemon.UseVisualStyleBackColor = true;
            this.btnShowPokemon.Click += new System.EventHandler(this.btnShowPokemon_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxShowPokemonData);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Show";
            // 
            // textBoxShowPokemonData
            // 
            this.textBoxShowPokemonData.Enabled = false;
            this.textBoxShowPokemonData.Location = new System.Drawing.Point(7, 22);
            this.textBoxShowPokemonData.Name = "textBoxShowPokemonData";
            this.textBoxShowPokemonData.Size = new System.Drawing.Size(441, 222);
            this.textBoxShowPokemonData.TabIndex = 0;
            this.textBoxShowPokemonData.Text = "";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 327);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Index";
            this.Text = "Index";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnShowPokemon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxEnterPokemonId;
        private System.Windows.Forms.RichTextBox textBoxShowPokemonData;
    }
}

