namespace Gestion.Forms {
    partial class Principal {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ejerciciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pruebaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMClientesFichaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ajustes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ejerciciosToolStripMenuItem,
            this.Ajustes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 48);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ejerciciosToolStripMenuItem
            // 
            this.ejerciciosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pruebaToolStripMenuItem,
            this.aBMClientesFichaToolStripMenuItem});
            this.ejerciciosToolStripMenuItem.Name = "ejerciciosToolStripMenuItem";
            this.ejerciciosToolStripMenuItem.Size = new System.Drawing.Size(83, 44);
            this.ejerciciosToolStripMenuItem.Text = "Ejercicios";
            // 
            // pruebaToolStripMenuItem
            // 
            this.pruebaToolStripMenuItem.Name = "pruebaToolStripMenuItem";
            this.pruebaToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.pruebaToolStripMenuItem.Text = "Prueba";
            this.pruebaToolStripMenuItem.Click += new System.EventHandler(this.pruebaToolStripMenuItem_Click);
            // 
            // aBMClientesFichaToolStripMenuItem
            // 
            this.aBMClientesFichaToolStripMenuItem.Name = "aBMClientesFichaToolStripMenuItem";
            this.aBMClientesFichaToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.aBMClientesFichaToolStripMenuItem.Text = "ABM_Clientes_Ficha";
            this.aBMClientesFichaToolStripMenuItem.Click += new System.EventHandler(this.aBMClientesFichaToolStripMenuItem_Click);
            // 
            // Ajustes
            // 
            this.Ajustes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Ajustes.Image = global::Gestion.Properties.Resources.wrench;
            this.Ajustes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Ajustes.Name = "Ajustes";
            this.Ajustes.Size = new System.Drawing.Size(68, 44);
            this.Ajustes.Text = "Ajustes";
            this.Ajustes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ajustes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Ajustes.Click += new System.EventHandler(this.Ajustes_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 638);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ejerciciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pruebaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMClientesFichaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Ajustes;
    }
}



