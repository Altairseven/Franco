using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion.Forms {
    public partial class ExperimentoUI : OwnForm {

        private PictureBox title = new PictureBox(); // create a PictureBox

        private bool drag = false; // determine if we should be moving the form
        private Point startPoint = new Point(0, 0); // also for the moving


        public void OnResize(object sender, EventArgs e) {
            Titlebar.Location = new Point(0, 0);
            Titlebar.Size = new Size(this.Width, 40);
            Sidepanel.Location = new Point(0, Titlebar.Height);
            Sidepanel.Size = new Size(220, this.Height - Titlebar.Height);
            Content1.Location = new Point(Sidepanel.Width, Titlebar.Height);
            Content1.Size = new Size(this.Width - Sidepanel.Width, this.Height - Titlebar.Height);
        }


        public ExperimentoUI() {
            InitializeComponent();
            OnResize(null, null);
        }


        private void Control_MouseEnter(object sender, EventArgs e) {
            if (sender.Equals(this.CloseBT))
                this.CloseBT.ForeColor = Color.RoyalBlue;
            else if (sender.Equals(this.MaxBt))
                this.MaxBt.ForeColor = Color.RoyalBlue;
            else
                this.MinBt.ForeColor = Color.RoyalBlue;
        }
        private void Control_MouseLeave(object sender, EventArgs e) {
            if (sender.Equals(this.CloseBT))
                this.CloseBT.ForeColor = Color.White;
            else if (sender.Equals(this.MaxBt))
                this.MaxBt.ForeColor = Color.White;
            else
                this.MinBt.ForeColor = Color.White;
        }

        private void Control_MouseClick(object sender, EventArgs e) {
            if (sender.Equals(this.CloseBT))
                this.Close(); // close the form
            else if (sender.Equals(this.MaxBt)) {                                 
                if (this.MaxBt.Text == "+") {
                    this.WindowState = FormWindowState.Maximized; // maximise the form
                    this.MaxBt.Text = "~"; // change the text
                }
                else // we need to restore
                {
                    this.WindowState = FormWindowState.Normal;
                    this.MaxBt.Text = "+";
                }
            }
            else 
                this.WindowState = FormWindowState.Minimized; 
        }

        void Title_MouseUp(object sender, MouseEventArgs e) {
            this.drag = false;
        }

        void Title_MouseDown(object sender, MouseEventArgs e) {
            this.startPoint = e.Location;
            this.drag = true;
        }

        void Title_MouseMove(object sender, MouseEventArgs e) {
            if (this.drag) { // if we should be dragging it, we need to figure out some movement
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);
                this.Location = p3;
            }
        }

    }
}
