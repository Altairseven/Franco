namespace ServiceControl.Forms {
    partial class Main {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Settings = new System.Windows.Forms.Button();
            this.dtgv1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // Settings
            // 
            this.Settings.BackgroundImage = global::ServiceControl.Properties.Resources.COG;
            this.Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Settings.Location = new System.Drawing.Point(390, 11);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(24, 24);
            this.Settings.TabIndex = 0;
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // dtgv1
            // 
            this.dtgv1.AllowUserToAddRows = false;
            this.dtgv1.AllowUserToDeleteRows = false;
            this.dtgv1.AllowUserToResizeColumns = false;
            this.dtgv1.AllowUserToResizeRows = false;
            this.dtgv1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dtgv1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv1.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgv1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgv1.Location = new System.Drawing.Point(110, 41);
            this.dtgv1.Name = "dtgv1";
            this.dtgv1.ReadOnly = true;
            this.dtgv1.RowHeadersVisible = false;
            this.dtgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv1.Size = new System.Drawing.Size(304, 201);
            this.dtgv1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Iniciar Seleccionados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 42);
            this.button2.TabIndex = 8;
            this.button2.Text = "Iniciar Todos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(92, 42);
            this.button3.TabIndex = 9;
            this.button3.Text = "Detener Seleccionados";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 200);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 42);
            this.button4.TabIndex = 10;
            this.button4.Text = "Detener Todos";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 248);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(402, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 277);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgv1);
            this.Controls.Add(this.Settings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Click += new System.EventHandler(this.Deselect);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.DataGridView dtgv1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

