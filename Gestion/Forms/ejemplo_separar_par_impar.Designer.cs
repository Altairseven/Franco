namespace Gestion
{
    partial class ejemplo_separar_par_impar
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
            this.lst_p = new System.Windows.Forms.ListBox();
            this.Lst_num = new System.Windows.Forms.ListBox();
            this.lst_i = new System.Windows.Forms.ListBox();
            this.bt_separar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_p
            // 
            this.lst_p.FormattingEnabled = true;
            this.lst_p.Location = new System.Drawing.Point(12, 12);
            this.lst_p.Name = "lst_p";
            this.lst_p.Size = new System.Drawing.Size(120, 394);
            this.lst_p.TabIndex = 0;
            // 
            // Lst_num
            // 
            this.Lst_num.FormattingEnabled = true;
            this.Lst_num.Location = new System.Drawing.Point(192, 12);
            this.Lst_num.Name = "Lst_num";
            this.Lst_num.Size = new System.Drawing.Size(120, 394);
            this.Lst_num.TabIndex = 1;
            // 
            // lst_i
            // 
            this.lst_i.FormattingEnabled = true;
            this.lst_i.Location = new System.Drawing.Point(371, 12);
            this.lst_i.Name = "lst_i";
            this.lst_i.Size = new System.Drawing.Size(120, 381);
            this.lst_i.TabIndex = 2;
            // 
            // bt_separar
            // 
            this.bt_separar.Location = new System.Drawing.Point(215, 428);
            this.bt_separar.Name = "bt_separar";
            this.bt_separar.Size = new System.Drawing.Size(75, 23);
            this.bt_separar.TabIndex = 3;
            this.bt_separar.Text = "Separar";
            this.bt_separar.UseVisualStyleBackColor = true;
            this.bt_separar.Click += new System.EventHandler(this.bt_separar_Click);
            // 
            // ejemplo_separar_par_impar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 482);
            this.Controls.Add(this.bt_separar);
            this.Controls.Add(this.lst_i);
            this.Controls.Add(this.Lst_num);
            this.Controls.Add(this.lst_p);
            this.Name = "ejemplo_separar_par_impar";
            this.Text = "ejemplo_separar_par_impar";
            this.Load += new System.EventHandler(this.ejemplo_separar_par_impar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lst_p;
        private System.Windows.Forms.ListBox Lst_num;
        private System.Windows.Forms.ListBox lst_i;
        private System.Windows.Forms.Button bt_separar;
    }
}