using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Gestion.Forms {
    public partial class Password_Salt_And_Hash : Gestion.Forms.OwnForm {
        public Password_Salt_And_Hash() {
            InitializeComponent();
        }

        Classes.newSalt s;

        private void button1_Click(object sender, EventArgs e) {
            Classes.hashIt h = new Classes.hashIt(mTextBox_Edit1.Text.Trim());
            mTextBox_Edit2.Text = h.Hash;
        }

        private void button2_Click(object sender, EventArgs e) {
            s = new Classes.newSalt(10);
            mTextBox_Edit3.Text = s.Salt;
        }

        private void button3_Click(object sender, EventArgs e) {
            //Classes.newSalt s = new Classes.newSalt(10);
            Classes.hashIt h = new Classes.hashIt(mTextBox_Edit1.Text.Trim(), s.Salt);
            mTextBox_Edit4.Text = h.Hash;
        }
    }







}


