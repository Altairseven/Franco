namespace Gestion.Forms {
    partial class Fibonachi {
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
            this.fib_bn = new System.Windows.Forms.Button();
            this.FibTB = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fib_bn
            // 
            this.fib_bn.Location = new System.Drawing.Point(118, 9);
            this.fib_bn.Name = "fib_bn";
            this.fib_bn.Size = new System.Drawing.Size(75, 23);
            this.fib_bn.TabIndex = 0;
            this.fib_bn.Text = "Calcular Hasta N";
            this.fib_bn.UseVisualStyleBackColor = true;
            this.fib_bn.Click += new System.EventHandler(this.fib_bn_Click);
            // 
            // FibTB
            // 
            this.FibTB.Location = new System.Drawing.Point(42, 12);
            this.FibTB.Name = "FibTB";
            this.FibTB.Size = new System.Drawing.Size(70, 20);
            this.FibTB.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(181, 303);
            this.listBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "N = ";
            // 
            // Fibonachi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.FibTB);
            this.Controls.Add(this.fib_bn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fibonachi";
            this.Text = "Fibonachi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fib_bn;
        private System.Windows.Forms.TextBox FibTB;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}