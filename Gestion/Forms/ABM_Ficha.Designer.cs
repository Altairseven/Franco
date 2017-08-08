namespace Gestion.Forms {
    partial class ABM_Ficha {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABM_Ficha));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mTextBox_Edit1 = new Gestion.Components.MTextBox_Edit();
            this.mTextBox_Edit2 = new Gestion.Components.MTextBox_Edit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Last_BT = new System.Windows.Forms.Button();
            this.Next_BT = new System.Windows.Forms.Button();
            this.Prev_BT = new System.Windows.Forms.Button();
            this.First_BT = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Search_BT = new System.Windows.Forms.Button();
            this.Del_BT = new System.Windows.Forms.Button();
            this.Edit_BT = new System.Windows.Forms.Button();
            this.AddSave_BT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Telefono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Direccion";
            // 
            // mTextBox_Edit1
            // 
            this.mTextBox_Edit1.Location = new System.Drawing.Point(104, 32);
            this.mTextBox_Edit1.Name = "mTextBox_Edit1";
            this.mTextBox_Edit1.Size = new System.Drawing.Size(167, 22);
            this.mTextBox_Edit1.TabIndex = 2;
            // 
            // mTextBox_Edit2
            // 
            this.mTextBox_Edit2.Location = new System.Drawing.Point(104, 72);
            this.mTextBox_Edit2.Name = "mTextBox_Edit2";
            this.mTextBox_Edit2.Size = new System.Drawing.Size(344, 22);
            this.mTextBox_Edit2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Last_BT);
            this.groupBox1.Controls.Add(this.Next_BT);
            this.groupBox1.Controls.Add(this.Prev_BT);
            this.groupBox1.Controls.Add(this.First_BT);
            this.groupBox1.Location = new System.Drawing.Point(24, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 88);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Navegar";
            // 
            // Last_BT
            // 
            this.Last_BT.Image = ((System.Drawing.Image)(resources.GetObject("Last_BT.Image")));
            this.Last_BT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Last_BT.Location = new System.Drawing.Point(320, 32);
            this.Last_BT.Name = "Last_BT";
            this.Last_BT.Size = new System.Drawing.Size(96, 48);
            this.Last_BT.TabIndex = 3;
            this.Last_BT.Text = "Ultimo";
            this.Last_BT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Last_BT.UseVisualStyleBackColor = true;
            // 
            // Next_BT
            // 
            this.Next_BT.Image = ((System.Drawing.Image)(resources.GetObject("Next_BT.Image")));
            this.Next_BT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Next_BT.Location = new System.Drawing.Point(216, 32);
            this.Next_BT.Name = "Next_BT";
            this.Next_BT.Size = new System.Drawing.Size(96, 48);
            this.Next_BT.TabIndex = 2;
            this.Next_BT.Text = "Retroceder";
            this.Next_BT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Next_BT.UseVisualStyleBackColor = true;
            // 
            // Prev_BT
            // 
            this.Prev_BT.Image = ((System.Drawing.Image)(resources.GetObject("Prev_BT.Image")));
            this.Prev_BT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Prev_BT.Location = new System.Drawing.Point(112, 32);
            this.Prev_BT.Name = "Prev_BT";
            this.Prev_BT.Size = new System.Drawing.Size(96, 48);
            this.Prev_BT.TabIndex = 1;
            this.Prev_BT.Text = "Avanzar";
            this.Prev_BT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Prev_BT.UseVisualStyleBackColor = true;
            // 
            // First_BT
            // 
            this.First_BT.Image = ((System.Drawing.Image)(resources.GetObject("First_BT.Image")));
            this.First_BT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.First_BT.Location = new System.Drawing.Point(8, 32);
            this.First_BT.Name = "First_BT";
            this.First_BT.Size = new System.Drawing.Size(96, 48);
            this.First_BT.TabIndex = 0;
            this.First_BT.Text = "Primero";
            this.First_BT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.First_BT.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Search_BT);
            this.groupBox2.Controls.Add(this.Del_BT);
            this.groupBox2.Controls.Add(this.Edit_BT);
            this.groupBox2.Controls.Add(this.AddSave_BT);
            this.groupBox2.Location = new System.Drawing.Point(24, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 88);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Editar";
            // 
            // Search_BT
            // 
            this.Search_BT.Image = global::Gestion.Properties.Resources.search;
            this.Search_BT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Search_BT.Location = new System.Drawing.Point(320, 32);
            this.Search_BT.Name = "Search_BT";
            this.Search_BT.Size = new System.Drawing.Size(96, 48);
            this.Search_BT.TabIndex = 7;
            this.Search_BT.Text = "Buscar";
            this.Search_BT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Search_BT.UseVisualStyleBackColor = true;
            this.Search_BT.Click += new System.EventHandler(this.Search_BT_Click);
            // 
            // Del_BT
            // 
            this.Del_BT.Image = global::Gestion.Properties.Resources.trashcan;
            this.Del_BT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Del_BT.Location = new System.Drawing.Point(216, 32);
            this.Del_BT.Name = "Del_BT";
            this.Del_BT.Size = new System.Drawing.Size(96, 48);
            this.Del_BT.TabIndex = 6;
            this.Del_BT.Text = "Eliminar";
            this.Del_BT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Del_BT.UseVisualStyleBackColor = true;
            // 
            // Edit_BT
            // 
            this.Edit_BT.Image = global::Gestion.Properties.Resources.pencil;
            this.Edit_BT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Edit_BT.Location = new System.Drawing.Point(112, 32);
            this.Edit_BT.Name = "Edit_BT";
            this.Edit_BT.Size = new System.Drawing.Size(96, 48);
            this.Edit_BT.TabIndex = 5;
            this.Edit_BT.Text = "Editar";
            this.Edit_BT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Edit_BT.UseVisualStyleBackColor = true;
            // 
            // AddSave_BT
            // 
            this.AddSave_BT.Image = ((System.Drawing.Image)(resources.GetObject("AddSave_BT.Image")));
            this.AddSave_BT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AddSave_BT.Location = new System.Drawing.Point(8, 32);
            this.AddSave_BT.Name = "AddSave_BT";
            this.AddSave_BT.Size = new System.Drawing.Size(96, 48);
            this.AddSave_BT.TabIndex = 4;
            this.AddSave_BT.Text = "Nuevo";
            this.AddSave_BT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.AddSave_BT.UseVisualStyleBackColor = true;
            this.AddSave_BT.Click += new System.EventHandler(this.AddSaveBT_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Registro Xazsddasdasd";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ABM_Ficha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 340);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mTextBox_Edit2);
            this.Controls.Add(this.mTextBox_Edit1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ABM_Ficha";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Components.MTextBox_Edit mTextBox_Edit1;
        private Components.MTextBox_Edit mTextBox_Edit2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button First_BT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Last_BT;
        private System.Windows.Forms.Button Next_BT;
        private System.Windows.Forms.Button Prev_BT;
        private System.Windows.Forms.Button Search_BT;
        private System.Windows.Forms.Button Del_BT;
        private System.Windows.Forms.Button Edit_BT;
        private System.Windows.Forms.Button AddSave_BT;
    }
}