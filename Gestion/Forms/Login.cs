using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestion.Classes;

namespace Gestion.Forms {
    public partial class Login : OwnForm {
        public Login() {
            InitializeComponent();
        }

        private static bool logedin = false;
        Login_func l = new Login_func();

        private void Login_Load(object sender, EventArgs e) {
            logintoggle();
        }
        private void logintoggle() {
            groupBox1.Location = new Point((this.ClientSize.Width - groupBox1.Width) / 2, (this.ClientSize.Height - groupBox1.Height) / 2);
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Show();
            panel1.Hide();
            mTextBox_Edit1.Text = ""; mTextBox_Edit2.Text = "";
            this.BackColor = SystemColors.Highlight;
            if (logedin == true) {
                groupBox1.Hide();
                panel1.Show();
                this.BackColor = SystemColors.Control;

            }


        }

        private void button3_Click(object sender, EventArgs e) {

            logintoggle();


        }

        private void button4_Click(object sender, EventArgs e) {
            if (logedin == true) {
                logedin = false;
                
            }
            else {
                logedin = true;
                
            }
            MessageBox.Show(logedin.ToString());


        }

        private void button1_Click(object sender, EventArgs e) {
            if (mTextBox_Edit1.Text != "" && mTextBox_Edit2.Text != "") {
                bool result = l.check_password(mTextBox_Edit1.Text, mTextBox_Edit2.Text);
                if (result == true) {
                    logedin = true;
                    logintoggle();
                }
            }
        }
    }
    
}
