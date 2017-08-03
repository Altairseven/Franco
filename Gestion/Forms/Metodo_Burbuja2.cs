using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestion.Classes;

namespace Gestion {
    public partial class Metodo_Burbuja2 : Gestion.Forms.OwnForm {
        public Metodo_Burbuja2() {
            InitializeComponent();
        }


        private void Metodo_Burbuja_Load(object sender, EventArgs e) {
            Random r = new Random();  //Genera un numero Random
            for (int i = 0; i < 20; i++) { // es i < 20, xq hace de 0 a 19, tambien podriamos poner i <=19.
                lstDesordenados.Items.Add(r.Next(1, 100)); //el .Next() de r, es para que cree otro numero random
                                                           // entre 1 y 100
            }
        }

        private void btnBurbuja_Click(object sender, EventArgs e) {

            lstOrdenados.Items.Clear();
            int[] d = new int[20];
            for (int i = 0; i < 20; i++) {
                d[i] = (int)lstDesordenados.Items[i];
            }
            bubble burb = new bubble(d);




            for (int i = 0; i < 20; i++) {
                string textito = i.ToString() + " - " + burb.resultado[i].ToString();

                lstOrdenados.Items.Add(textito);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            //lstOrdenados.Items.Clear();
            //bubble burb = new bubble(lstDesordenados.Items);
        }
    }
}
