using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion {
    public partial class FormButton : UserControl {

        Type form;

        public FormButton(string bttext,Type formulario) {
            InitializeComponent();
            button1.Text = bttext;
            form = formulario;
        }
        public FormButton() {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e) {
            Form myObject = (Form)Activator.CreateInstance(Type.GetType(form.ToString()));
            myObject.Show();
            
        }
    }
}
