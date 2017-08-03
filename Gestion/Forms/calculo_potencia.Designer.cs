namespace Gestion
{
    partial class calculo_potencia
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
            this.txt_base = new Components.MTextBox_Edit();
            this.txt_exp = new Components.MTextBox_Edit();
            this.txt_res = new Components.MTextBox_Edit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_calc = new System.Windows.Forms.Button();
            this.fib_bn = new System.Windows.Forms.Button();
            this.FibTB = new Components.MTextBox_Edit();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_base
            // 
            this.txt_base.Location = new System.Drawing.Point(72, 12);
            this.txt_base.Name = "txt_base";
            this.txt_base.Size = new System.Drawing.Size(43, 21);
            this.txt_base.TabIndex = 0;
            // 
            // txt_exp
            // 
            this.txt_exp.Location = new System.Drawing.Point(211, 12);
            this.txt_exp.Name = "txt_exp";
            this.txt_exp.Size = new System.Drawing.Size(52, 21);
            this.txt_exp.TabIndex = 1;
            // 
            // txt_res
            // 
            this.txt_res.Enabled = false;
            this.txt_res.Location = new System.Drawing.Point(179, 180);
            this.txt_res.Name = "txt_res";
            this.txt_res.Size = new System.Drawing.Size(84, 21);
            this.txt_res.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Exponente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Resultado";
            // 
            // btn_calc
            // 
            this.btn_calc.Location = new System.Drawing.Point(109, 78);
            this.btn_calc.Name = "btn_calc";
            this.btn_calc.Size = new System.Drawing.Size(75, 23);
            this.btn_calc.TabIndex = 6;
            this.btn_calc.Text = "Calcular";
            this.btn_calc.UseVisualStyleBackColor = true;
            this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
            // 
            // fib_bn
            // 
            this.fib_bn.Location = new System.Drawing.Point(46, 226);
            this.fib_bn.Name = "fib_bn";
            this.fib_bn.Size = new System.Drawing.Size(75, 23);
            this.fib_bn.TabIndex = 7;
            this.fib_bn.Text = "fibonachi";
            this.fib_bn.UseVisualStyleBackColor = true;
            this.fib_bn.Click += new System.EventHandler(this.fib_bn_Click);
            // 
            // FibTB
            // 
            this.FibTB.Location = new System.Drawing.Point(211, 228);
            this.FibTB.Name = "FibTB";
            this.FibTB.Size = new System.Drawing.Size(52, 21);
            this.FibTB.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hasta Numero:";
            // 
            // calculo_potencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FibTB);
            this.Controls.Add(this.fib_bn);
            this.Controls.Add(this.btn_calc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_res);
            this.Controls.Add(this.txt_exp);
            this.Controls.Add(this.txt_base);
            this.Name = "calculo_potencia";
            this.Text = "calculo_potencia";
            this.Load += new System.EventHandler(this.calculo_potencia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.MTextBox_Edit txt_base;
        private Components.MTextBox_Edit txt_exp;
        private Components.MTextBox_Edit txt_res;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_calc;
        private System.Windows.Forms.Button fib_bn;
        private Components.MTextBox_Edit FibTB;
        private System.Windows.Forms.Label label4;
    }
}