using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion.Forms {
    public partial class Settings : Form {
        public Settings() {
            InitializeComponent();
        }

        


        private void Settings_Load(object sender, EventArgs e) {
            switch (Properties.Settings.Default.StartForm) {
                case 0: comboBox1.SelectedIndex = 0; break;
                case 1: comboBox1.SelectedIndex = 1; break;
                case 2: comboBox1.SelectedIndex = 2; break;
            }
            switch (Properties.Settings.Default.ConString) {
                case 0: comboBox2.SelectedIndex = 0; break;
                case 1: comboBox2.SelectedIndex = 1; break;
            }
            label4.Text = Program.Global_ConString;

        }

        private void BT_Save_Click(object sender, EventArgs e) {
            switch (comboBox1.SelectedIndex) {
                case 0: Properties.Settings.Default.StartForm = 0; break;
                case 1: Properties.Settings.Default.StartForm = 1; break;
                case 2: Properties.Settings.Default.StartForm = 2; break;
            }
            switch (comboBox2.SelectedIndex) {
                case 0: Properties.Settings.Default.ConString = 0; Program.Global_ConString = Program._conString[0]; break;
                case 1: Properties.Settings.Default.ConString = 1; Program.Global_ConString = Program._conString[1]; break;
            }
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void BT_Cancel_Click(object sender, EventArgs e) {
            comboBox1.SelectedIndex = 2;
        }
    }
}
