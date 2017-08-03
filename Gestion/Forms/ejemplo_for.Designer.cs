namespace Gestion
{
    partial class ejemplo_for
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
            this.text = new System.Windows.Forms.Label();
            this.btn_calc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_res = new Gestion.Components.MTextBox_Edit();
            this.txt_num = new Gestion.Components.MTextBox_Edit();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Location = new System.Drawing.Point(26, 16);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(44, 13);
            this.text.TabIndex = 0;
            this.text.Text = "Numero";
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(173, 51);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(75, 23);
            this.btn_calc.TabIndex = 2;
            this.btn_calc.Text = "Calcular";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Resultado";
            // 
            // txt_res
            // 
            this.txt_res.Location = new System.Drawing.Point(132, 94);
            this.txt_res.Name = "txt_res";
            this.txt_res.Size = new System.Drawing.Size(116, 20);
            this.txt_res.TabIndex = 4;
            // 
            // txt_num
            // 
            this.txt_num.Location = new System.Drawing.Point(132, 8);
            this.txt_num.Name = "txt_num";
            this.txt_num.Size = new System.Drawing.Size(116, 20);
            this.txt_num.TabIndex = 5;
            // 
            // ejemplo_for
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 151);
            this.Controls.Add(this.txt_num);
            this.Controls.Add(this.txt_res);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.text);
            this.Name = "ejemplo_for";
            this.Text = "ejemplo_for";
            this.Load += new System.EventHandler(this.ejemplo_for_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.Label label1;
        private Components.MTextBox_Edit txt_res;
        private Components.MTextBox_Edit txt_num;
    }
}