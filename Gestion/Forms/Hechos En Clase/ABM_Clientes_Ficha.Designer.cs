namespace Gestion.Forms.Hechos_En_Clase {
    partial class ABM_Clientes_Ficha {
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
            this.ID_TB = new Gestion.Components.MTextBox_Edit();
            this.Nombre_TB = new Gestion.Components.MTextBox_Edit();
            this.LimiteCredito_TB = new Gestion.Components.MTextBox_Edit();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID_TB
            // 
            this.ID_TB.Location = new System.Drawing.Point(24, 32);
            this.ID_TB.Name = "ID_TB";
            this.ID_TB.Size = new System.Drawing.Size(100, 22);
            this.ID_TB.TabIndex = 0;
            // 
            // Nombre_TB
            // 
            this.Nombre_TB.Location = new System.Drawing.Point(24, 80);
            this.Nombre_TB.Name = "Nombre_TB";
            this.Nombre_TB.Size = new System.Drawing.Size(100, 22);
            this.Nombre_TB.TabIndex = 1;
            // 
            // LimiteCredito_TB
            // 
            this.LimiteCredito_TB.Location = new System.Drawing.Point(24, 120);
            this.LimiteCredito_TB.Name = "LimiteCredito_TB";
            this.LimiteCredito_TB.Size = new System.Drawing.Size(100, 22);
            this.LimiteCredito_TB.TabIndex = 2;
            this.LimiteCredito_TB.Leave += new System.EventHandler(this.LimiteCredito_TB_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ABM_Clientes_Ficha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 329);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LimiteCredito_TB);
            this.Controls.Add(this.Nombre_TB);
            this.Controls.Add(this.ID_TB);
            this.Name = "ABM_Clientes_Ficha";
            this.Text = "ABM_Clientes_Ficha";
            this.Load += new System.EventHandler(this.ABM_Clientes_Ficha_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.MTextBox_Edit ID_TB;
        private Components.MTextBox_Edit Nombre_TB;
        private Components.MTextBox_Edit LimiteCredito_TB;
        private System.Windows.Forms.Button button1;
    }
}