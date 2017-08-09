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
    public partial class Teorema_del_Resto : Form {
        public Teorema_del_Resto() {
            InitializeComponent();
        }

        private void Teorema_del_Resto_Load(object sender, EventArgs e) {
            Raiz myForm = new Raiz();
            myForm.TopLevel = false;
            myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Dock = DockStyle.Fill;
            myForm.AutoScroll = true;
            this.panel1.Controls.Add(myForm);
            myForm.Show();
        }
    }
}
