﻿using System;
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
            
        }


    }
}
