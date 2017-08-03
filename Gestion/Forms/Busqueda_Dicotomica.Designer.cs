namespace Gestion {
    partial class Busqueda_Dicotomica {
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
            this.btnDicotomica = new System.Windows.Forms.Button();
            this.txtBus = new System.Windows.Forms.TextBox();
            this.txtPos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstDesordenados
            // 
            this.lstDesordenados.FormattingEnabled = true;
            this.lstDesordenados.Location = new System.Drawing.Point(12, 12);
            this.lstDesordenados.Name = "lstDesordenados";
            this.lstDesordenados.Size = new System.Drawing.Size(136, 290);
            this.lstDesordenados.TabIndex = 0;
            // 
            // lstOrdenados
            // 
            this.lstOrdenados.FormattingEnabled = true;
            this.lstOrdenados.Location = new System.Drawing.Point(285, 12);
            this.lstOrdenados.Name = "lstOrdenados";
            this.lstOrdenados.Size = new System.Drawing.Size(128, 290);
            this.lstOrdenados.TabIndex = 1;
            // 
            // btnBurbuja
            // 
            this.btnBurbuja.Location = new System.Drawing.Point(164, 13);
            this.btnBurbuja.Name = "btnBurbuja";
            this.btnBurbuja.Size = new System.Drawing.Size(75, 23);
            this.btnBurbuja.TabIndex = 2;
            this.btnBurbuja.Text = "Burbuja";
            this.btnBurbuja.UseVisualStyleBackColor = true;
            this.btnBurbuja.Click += new System.EventHandler(this.btnBurbuja_Click);
            // 
            // btnDicotomica
            // 
            this.btnDicotomica.Location = new System.Drawing.Point(433, 16);
            this.btnDicotomica.Name = "btnDicotomica";
            this.btnDicotomica.Size = new System.Drawing.Size(75, 23);
            this.btnDicotomica.TabIndex = 3;
            this.btnDicotomica.Text = "Dicotomica";
            this.btnDicotomica.UseVisualStyleBackColor = true;
            this.btnDicotomica.Click += new System.EventHandler(this.btnDicotomica_Click);
            // 
            // txtBus
            // 
            this.txtBus.Location = new System.Drawing.Point(532, 16);
            this.txtBus.Name = "txtBus";
            this.txtBus.Size = new System.Drawing.Size(100, 20);
            this.txtBus.TabIndex = 4;
            // 
            // txtPos
            // 
            this.txtPos.Location = new System.Drawing.Point(532, 123);
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(100, 20);
            this.txtPos.TabIndex = 5;
            // 
            // Busqueda_Dicotomica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 369);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.txtBus);
            this.Controls.Add(this.btnDicotomica);
            this.Controls.Add(this.btnBurbuja);
            this.Controls.Add(this.lstOrdenados);
            this.Controls.Add(this.lstDesordenados);
            this.Name = "Busqueda_Dicotomica";
            this.Text = "Busqueda_Dicotomica";
            this.Load += new System.EventHandler(this.Busqueda_Dicotomica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstDesordenados;
        private System.Windows.Forms.ListBox lstOrdenados;
        private System.Windows.Forms.Button btnBurbuja;
        private System.Windows.Forms.Button btnDicotomica;
        private System.Windows.Forms.TextBox txtBus;
        private System.Windows.Forms.TextBox txtPos;
    }
}