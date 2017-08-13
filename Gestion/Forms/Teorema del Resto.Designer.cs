namespace Gestion.Forms {
    partial class Teorema_del_Resto {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.TB_1 = new Gestion.Components.MTextBox_Edit();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ejemplosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejemplo3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TB_2 = new Gestion.Components.MTextBox_Edit();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TB_3 = new Gestion.Components.MTextBox_Edit();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_1
            // 
            this.TB_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_1.Location = new System.Drawing.Point(136, 64);
            this.TB_1.Name = "TB_1";
            this.TB_1.Size = new System.Drawing.Size(200, 22);
            this.TB_1.TabIndex = 0;
            this.TB_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB1_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejemplosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(360, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ejemplosToolStripMenuItem
            // 
            this.ejemplosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ejemplo2ToolStripMenuItem,
            this.ejemplo3ToolStripMenuItem});
            this.ejemplosToolStripMenuItem.Name = "ejemplosToolStripMenuItem";
            this.ejemplosToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.ejemplosToolStripMenuItem.Text = "Ejemplos";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 26);
            this.toolStripMenuItem1.Text = "Ejemplo 1";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.Ejemplos_Load);
            // 
            // ejemplo2ToolStripMenuItem
            // 
            this.ejemplo2ToolStripMenuItem.Name = "ejemplo2ToolStripMenuItem";
            this.ejemplo2ToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.ejemplo2ToolStripMenuItem.Text = "Ejemplo 2";
            this.ejemplo2ToolStripMenuItem.Click += new System.EventHandler(this.Ejemplos_Load);
            // 
            // ejemplo3ToolStripMenuItem
            // 
            this.ejemplo3ToolStripMenuItem.Name = "ejemplo3ToolStripMenuItem";
            this.ejemplo3ToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.ejemplo3ToolStripMenuItem.Text = "Ejemplo 3";
            this.ejemplo3ToolStripMenuItem.Click += new System.EventHandler(this.Ejemplos_Load);
            // 
            // TB_2
            // 
            this.TB_2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_2.Location = new System.Drawing.Point(272, 104);
            this.TB_2.Name = "TB_2";
            this.TB_2.Size = new System.Drawing.Size(64, 22);
            this.TB_2.TabIndex = 6;
            this.TB_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_2_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Polinomio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Divisor:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(0, 0);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TB_3
            // 
            this.TB_3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_3.Location = new System.Drawing.Point(272, 144);
            this.TB_3.Name = "TB_3";
            this.TB_3.Size = new System.Drawing.Size(64, 22);
            this.TB_3.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Resto:";
            // 
            // Teorema_del_Resto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(360, 216);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_2);
            this.Controls.Add(this.TB_1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(378, 263);
            this.Name = "Teorema_del_Resto";
            this.Text = "Teorema_del_Resto";
            this.Load += new System.EventHandler(this.Teorema_del_Resto_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.MTextBox_Edit TB_1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ejemplosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ejemplo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejemplo3ToolStripMenuItem;
        private Components.MTextBox_Edit TB_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private Components.MTextBox_Edit TB_3;
        private System.Windows.Forms.Label label2;
    }
}