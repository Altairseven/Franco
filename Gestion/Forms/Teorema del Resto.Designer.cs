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
            this.mTextBox_Edit1 = new Gestion.Components.MTextBox_Edit();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // mTextBox_Edit1
            // 
            this.mTextBox_Edit1.Location = new System.Drawing.Point(64, 112);
            this.mTextBox_Edit1.Name = "mTextBox_Edit1";
            this.mTextBox_Edit1.Size = new System.Drawing.Size(216, 22);
            this.mTextBox_Edit1.TabIndex = 0;
            this.mTextBox_Edit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mTextBox_Edit1_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(32, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(272, 32);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "5x^3-4x^6+1x^5+2x^1-20";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inserte un Polinomio de la forma: ";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(8, 160);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(312, 56);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "NOTA: Por el momento, este formulario solo parsea los datos, todavia no hace las " +
    "cuentas necesarias.\r\nPara poder visualizar lo que hace, usar el debugger ";
            // 
            // Teorema_del_Resto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(329, 227);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.mTextBox_Edit1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Teorema_del_Resto";
            this.Text = "Teorema_del_Resto";
            this.Load += new System.EventHandler(this.Teorema_del_Resto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.MTextBox_Edit mTextBox_Edit1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
    }
}