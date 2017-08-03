using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion {
    public partial class Busqueda_Dicotomica : Gestion.Forms.EnClasesForm {
        public Busqueda_Dicotomica() {
            InitializeComponent();
        }

        //El codigo escrito en el metodo Load y el btnBurbuja_Click, son lo mismo que los encontrados en
        // el formulario metodo burbuja, pero en el mismo, esta mejor comentado.

        private void Busqueda_Dicotomica_Load(object sender, EventArgs e) {
            Random r = new Random();
            for (int i = 0; i < 20; i++) {
                lstDesordenados.Items.Add(r.Next(1, 100));
            }
        }

        private void btnBurbuja_Click(object sender, EventArgs e) {
            lstOrdenados.Items.Clear();
            int[] d = new int[20];
            int aux = 0;
            for (int i = 0; i < 20; i++) {
                d[i] = (int)lstDesordenados.Items[i];
            }
            //metodo burbubja para ordenar arreglos
            for (int i = 0; i <= 18; i++) {
                for (int j = i + 1; j <= 19; j++) {
                    if (d[i] > d[j])
                    {
                        aux = d[i];
                        d[i] = d[j];
                        d[j] = aux;
                    }
                }
            }
            for (int i = 0; i < 20; i++) {
                string o = i.ToString().PadRight(5) + "-" + d[i].ToString().PadLeft(5);
                lstOrdenados.Items.Add(o);
            }
        }

        private void btnDicotomica_Click(object sender, EventArgs e) {
            txtPos.Text = "";
            int[,] t = new int[20, 2]; //arreglado a 2!!
            string aux;
            int pos;
            int val;
            string car;
            for (int i = 0; i < 19; i++) {
                aux = lstOrdenados.Items[i].ToString();
                pos = aux.IndexOf("-");
                car = aux.Substring(pos + 1);  // Index of me buca la posicion del guioo
                                               // el substring corta desde la posicion que sigue al string
                val = Convert.ToInt32(car); // en val asignamos el casteo de car convertido a int. 
                t[i, 0] = val;
                t[i, 1] = i;
            }
            bool q = false;
            int comi = 0;
            int fin = 19;
            int medio = 0;
            int bus = 0;
            int posi = 0;

            if (txtBus.Text != "") { //ESTE CHECKEO, ES PARA EVITAR QUE SI EL TEXTBOX ESTE VACIO, CRASHEE EL PROGRAMA.
                int buscado = Convert.ToInt32(this.txtBus.Text); //valor del textbox del costado, que en la imagen dice 29.

                //for (int i = 0; i < t[i, 0]; i++) {
                //    if (IsInList == t[i, 0]) {

                //    }
                //}

                while (comi <= fin && q == false) {
                    medio = (comi + fin) / 2;
                    bus = t[medio, 0];
                    if (bus == buscado) {
                        q = true;
                        posi = t[medio, 1];
                    }
                    else {
                        if (buscado < bus) { //if dado vuelta para que sea mas claro
                            fin = medio - 1;
                        }
                        else {
                            comi = medio + 1;
                        }
                    }
                }




                /*  While Hecho Por el profesor, no podia detectar si el numero no estaba, y el bucle quedaba abierto
                   do {
                        medio = (comi + fin) / 2;
                        bus = t[medio, 0];
                        if (bus == buscado) {
                            q = true;
                            posi = t[medio, 1];
                        }
                        else {
                            if (buscado < bus) //if dado vuelta para que sea mas claro
                            {
                                fin = medio - 1;
                            }
                            else {
                                comi = medio + 1;
                            }
                        }
                    } while (q == false);
                */



                if (q == false) {
                    MessageBox.Show("El numero Solicitado no esta en la lista!!");
                }
                else {
                    this.txtPos.Text = posi.ToString();
                    this.lstOrdenados.SelectedIndex = posi;
                }


            }
            else {
                MessageBox.Show("Ingrese un numero a buscar!!");
            }
        }
    }
}