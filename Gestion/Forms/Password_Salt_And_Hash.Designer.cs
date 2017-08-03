namespace Gestion.Forms {
    partial class Password_Salt_And_Hash {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password_Salt_And_Hash));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.mTextBox_Edit1 = new Gestion.Components.MTextBox_Edit();
            this.button2 = new System.Windows.Forms.Button();
            this.mTextBox_Edit2 = new Gestion.Components.MTextBox_Edit();
            this.mTextBox_Edit3 = new Gestion.Components.MTextBox_Edit();
            this.mTextBox_Edit4 = new Gestion.Components.MTextBox_Edit();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(103, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(321, 100);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Simple Hash";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mTextBox_Edit1
            // 
            this.mTextBox_Edit1.Location = new System.Drawing.Point(95, 138);
            this.mTextBox_Edit1.Name = "mTextBox_Edit1";
            this.mTextBox_Edit1.Size = new System.Drawing.Size(390, 20);
            this.mTextBox_Edit1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Salt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mTextBox_Edit2
            // 
            this.mTextBox_Edit2.Location = new System.Drawing.Point(95, 181);
            this.mTextBox_Edit2.Name = "mTextBox_Edit2";
            this.mTextBox_Edit2.ReadOnly = true;
            this.mTextBox_Edit2.Size = new System.Drawing.Size(390, 20);
            this.mTextBox_Edit2.TabIndex = 7;
            this.mTextBox_Edit2.TabStop = false;
            // 
            // mTextBox_Edit3
            // 
            this.mTextBox_Edit3.Location = new System.Drawing.Point(95, 231);
            this.mTextBox_Edit3.Name = "mTextBox_Edit3";
            this.mTextBox_Edit3.ReadOnly = true;
            this.mTextBox_Edit3.Size = new System.Drawing.Size(390, 20);
            this.mTextBox_Edit3.TabIndex = 8;
            this.mTextBox_Edit3.TabStop = false;
            // 
            // mTextBox_Edit4
            // 
            this.mTextBox_Edit4.Location = new System.Drawing.Point(95, 279);
            this.mTextBox_Edit4.Name = "mTextBox_Edit4";
            this.mTextBox_Edit4.ReadOnly = true;
            this.mTextBox_Edit4.Size = new System.Drawing.Size(390, 20);
            this.mTextBox_Edit4.TabIndex = 10;
            this.mTextBox_Edit4.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 277);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Salt + Hash";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(12, 318);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(483, 111);
            this.richTextBox2.TabIndex = 11;
            this.richTextBox2.TabStop = false;
            this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // Password_Salt_And_Hash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 441);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.mTextBox_Edit4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.mTextBox_Edit3);
            this.Controls.Add(this.mTextBox_Edit2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.mTextBox_Edit1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Password_Salt_And_Hash";
            this.Text = "Password_Salt_And_Hash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private Components.MTextBox_Edit mTextBox_Edit1;
        private System.Windows.Forms.Button button2;
        private Components.MTextBox_Edit mTextBox_Edit2;
        private Components.MTextBox_Edit mTextBox_Edit3;
        private Components.MTextBox_Edit mTextBox_Edit4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}