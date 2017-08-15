using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion.Forms {
    public partial class AA_Test : OwnForm {
        public AA_Test() {
            InitializeComponent();
        }
        private static string descripcion = 
            "Formulario para Pruebas Randoms, previo a determinar si" +
            " lo que estoy probando amerita su propio form";

        public static string Descripcion { get { return descripcion; } }

        private void AA_Test_Load(object sender, EventArgs e) {
            label1.Text = Properties.Settings.Default.ReflectionType;
        }

        private void button1_Click(object sender, EventArgs e) {
            Properties.Settings.Default.ReflectionType = "NameSpace";
            label1.Text = Properties.Settings.Default.ReflectionType;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e) {
            Properties.Settings.Default.ReflectionType = "Type";
            label1.Text = Properties.Settings.Default.ReflectionType;
            Properties.Settings.Default.Save();
        }
    }
}
