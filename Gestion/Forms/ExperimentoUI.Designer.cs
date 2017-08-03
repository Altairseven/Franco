namespace Gestion.Forms {
    partial class ExperimentoUI {
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
            this.Titlebar = new System.Windows.Forms.Panel();
            this.MinBt = new System.Windows.Forms.Label();
            this.MaxBt = new System.Windows.Forms.Label();
            this.CloseBT = new System.Windows.Forms.Label();
            this.Sidepanel = new System.Windows.Forms.Panel();
            this.Content1 = new System.Windows.Forms.Panel();
            this.Titlebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Titlebar
            // 
            this.Titlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(63)))));
            this.Titlebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Titlebar.Controls.Add(this.MinBt);
            this.Titlebar.Controls.Add(this.MaxBt);
            this.Titlebar.Controls.Add(this.CloseBT);
            this.Titlebar.Location = new System.Drawing.Point(0, 0);
            this.Titlebar.Name = "Titlebar";
            this.Titlebar.Size = new System.Drawing.Size(776, 39);
            this.Titlebar.TabIndex = 1;
            this.Titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Title_MouseDown);
            this.Titlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Title_MouseMove);
            this.Titlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Title_MouseUp);
            // 
            // MinBt
            // 
            this.MinBt.AutoSize = true;
            this.MinBt.BackColor = System.Drawing.Color.Transparent;
            this.MinBt.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinBt.ForeColor = System.Drawing.Color.White;
            this.MinBt.Location = new System.Drawing.Point(683, 9);
            this.MinBt.Name = "MinBt";
            this.MinBt.Size = new System.Drawing.Size(16, 20);
            this.MinBt.TabIndex = 2;
            this.MinBt.Text = "-";
            this.MinBt.Click += new System.EventHandler(this.Control_MouseClick);
            this.MinBt.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.MinBt.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            // 
            // MaxBt
            // 
            this.MaxBt.AutoSize = true;
            this.MaxBt.BackColor = System.Drawing.Color.Transparent;
            this.MaxBt.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxBt.ForeColor = System.Drawing.Color.White;
            this.MaxBt.Location = new System.Drawing.Point(705, 9);
            this.MaxBt.Name = "MaxBt";
            this.MaxBt.Size = new System.Drawing.Size(18, 20);
            this.MaxBt.TabIndex = 1;
            this.MaxBt.Text = "+";
            this.MaxBt.Click += new System.EventHandler(this.Control_MouseClick);
            this.MaxBt.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.MaxBt.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            // 
            // CloseBT
            // 
            this.CloseBT.AutoSize = true;
            this.CloseBT.BackColor = System.Drawing.Color.Transparent;
            this.CloseBT.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBT.ForeColor = System.Drawing.Color.White;
            this.CloseBT.Location = new System.Drawing.Point(729, 9);
            this.CloseBT.Name = "CloseBT";
            this.CloseBT.Size = new System.Drawing.Size(19, 20);
            this.CloseBT.TabIndex = 0;
            this.CloseBT.Text = "X";
            this.CloseBT.Click += new System.EventHandler(this.Control_MouseClick);
            this.CloseBT.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.CloseBT.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            // 
            // Sidepanel
            // 
            this.Sidepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(57)))), ((int)(((byte)(68)))));
            this.Sidepanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Sidepanel.Location = new System.Drawing.Point(0, 38);
            this.Sidepanel.Name = "Sidepanel";
            this.Sidepanel.Size = new System.Drawing.Size(219, 448);
            this.Sidepanel.TabIndex = 3;
            // 
            // Content1
            // 
            this.Content1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Content1.Location = new System.Drawing.Point(219, 39);
            this.Content1.Name = "Content1";
            this.Content1.Size = new System.Drawing.Size(542, 448);
            this.Content1.TabIndex = 4;
            // 
            // ExperimentoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(69)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(760, 484);
            this.ControlBox = false;
            this.Controls.Add(this.Content1);
            this.Controls.Add(this.Sidepanel);
            this.Controls.Add(this.Titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExperimentoUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "ExperimentoUI";
            this.SizeChanged += new System.EventHandler(this.OnResize);
            this.Titlebar.ResumeLayout(false);
            this.Titlebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Titlebar;
        private System.Windows.Forms.Label MinBt;
        private System.Windows.Forms.Label MaxBt;
        private System.Windows.Forms.Label CloseBT;
        private System.Windows.Forms.Panel Sidepanel;
        private System.Windows.Forms.Panel Content1;
    }
}