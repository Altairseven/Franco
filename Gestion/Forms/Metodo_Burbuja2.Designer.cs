namespace Gestion {
    partial class Metodo_Burbuja2 {
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
            this.lstDesordenados = new System.Windows.Forms.ListBox();
            this.lstOrdenados = new System.Windows.Forms.ListBox();
            this.btnBurbuja = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstDesordenados
            // 
            this.lstDesordenados.FormattingEnabled = true;
            this.lstDesordenados.Location = new System.Drawing.Point(12, 25);
            this.lstDesordenados.Name = "lstDesordenados";
            this.lstDesordenados.Size = new System.Drawing.Size(127, 394);
            this.lstDesordenados.TabIndex = 0;
            // 
            // lstOrdenados
            // 
            this.lstOrdenados.FormattingEnabled = true;
            this.lstOrdenados.Location = new System.Drawing.Point(226, 25);
            this.lstOrdenados.Name = "lstOrdenados";
            this.lstOrdenados.Size = new System.Drawing.Size(127, 394);
            this.lstOrdenados.TabIndex = 1;
            // 
            // btnBurbuja
            // 
            this.btnBurbuja.Location = new System.Drawing.Point(145, 190);
            this.btnBurbuja.Name = "btnBurbuja";
            this.btnBurbuja.Size = new System.Drawing.Size(75, 23);
            this.btnBurbuja.TabIndex = 2;
            this.btnBurbuja.Text = "Con Array";
            this.btnBurbuja.UseVisualStyleBackColor = true;
            this.btnBurbuja.Click += new System.EventHandler(this.btnBurbuja_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "lstDesordenados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "lstOrdenados";
            // 
            // Metodo_Burbuja2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 431);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBurbuja);
            this.Controls.Add(this.lstOrdenados);
            this.Controls.Add(this.lstDesordenados);
            this.Name = "Metodo_Burbuja2";
            this.Text = "Metodo_Burbuja";
            this.Load += new System.EventHandler(this.Metodo_Burbuja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDesordenados;
        private System.Windows.Forms.ListBox lstOrdenados;
        private System.Windows.Forms.Button btnBurbuja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}