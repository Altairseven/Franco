using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion {
    public partial class Metodo_Burbuja : Gestion.Forms.EnClasesForm {
        public Metodo_Burbuja() {
            InitializeComponent();
        }

        // Metodo de Burbuja (Sirve para Ordenar los valores en un array).
        //En el formulario hay 2 Listbox LLamados lstDesordenados u lstOrdenados
        // y un Boton Llamado btnBurbuja

        /*
           Con tantos for loops por las dudas hago un comentario aclarando.
           Recuerden que si hacer un loop de 20 elementos, tenemos varias formar de hacerlo:
           i <= 19
           i < 20
           i < NOMBREDELARRAY.Length
           i <= NOMBREDELARRAY.Length -1

            Tengan cuidado con el <= o < y piensen bien al escribir cada loop, xq son errores
            boludos que tardas demasiado en darte cuenta que estan.


        */

        //en el form load, hay solamente un loop para llenar la primer listbox
        //con 20 numeros randoms.
        private void Metodo_Burbuja_Load(object sender, EventArgs e) {
            Random r = new Random();  //Genera un numero Random
            for (int i = 0; i <= 19; i++) { // el loop corre hasta el indice 19, que es el 20avo numero del array.
                                            // tambien podria expresarse como i < 20.
                lstDesordenados.Items.Add(r.Next(1, 100)); //el .Next() de r, es para que cree otro numero random
                                                           // entre 1 y 100
            }
        }

        private void btnBurbuja_Click(object sender, EventArgs e) {

            //Lo siguiente es lo que hay que hacer previamente al metodo de burbuja en si:

            //Para que cada vez q se aprete, primero limpie el contenido actual de la segunda listbox.
            lstOrdenados.Items.Clear();

            int[] d = new int[20]; //Declaracion de array de 20 numeros int.
            int aux = 0; //Declaracion de una variable auxiliar.

            // Llenamos el Array con los elementos de la primer listbox.
            for (int i = 0; i <= 19; i++) {
                d[i] = (int)lstDesordenados.Items[i];
                
            }   // d[i] = Convert.ToInt32(lstDesordenados.Items[i]);
            // metodo de burbuja en si:
            //Vamos a usar 2 For Loops anidados, esto es para que siempre compare 1 numero con el que sigue.
            // ejemplo el index 0 con el 1, el 1 con el 2, el 18 con el 19.

            for (int i = 0; i <= 18; i++) { // el primero va a ir desde 0 a 18, osea el anteultimo numero.
                for (int j = i + 1; j <= 19; j++) { // el segundo va a ir de 1 a 19, osea del segundo al ultimo.
                    if (d[i] > d[j]) { //si el valor del primer index es mayor que el del segundo. 

                        //intercambio los valores:

                        aux = d[i];   // Guardas el primero en aux,  
                        d[i] = d[j];  // Asignas el segundo en el primero  
                        d[j] = aux;   // guardas el aux en el segundo.  
                    }
                }
            }


            //A esta altura el array esta ordenado de menor a mayor, ahora vamos a hacer que se muestre en el segundo Listbox
            //con el numero de posicion primero, y luego el valor ej: "0 - 57"
            for (int i = 0; i <= 19; i++) {
                string textito = i.ToString() + " - " + d[i].ToString();

                lstOrdenados.Items.Add(textito);
            }
        }


    }
}
