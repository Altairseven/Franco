using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion.Forms {
    public partial class Metodo_Burbuja_Modular : OwnForm {
        public Metodo_Burbuja_Modular() {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e) {
            listBox1.Items.Clear();
            
            if (int.TryParse(mTextBox_Edit1.Text, out int cantidad) == false)
                MessageBox.Show("bobo");
            else if (cantidad == 0) 
                MessageBox.Show("el valor es cero boboooo");
            else {
              Random r = new Random();
                for (int i = 0; i < cantidad; i++)
                    listBox1.Items.Add(r.Next(1, 100));
            }    


        }

        private void button2_Click(object sender, EventArgs e) {
            if (listBox1.Items.Count == 0)
                MessageBox.Show("bobo, completa la otra wea primero");
            else {
                listBox2.Items.Clear();

                int[] d = new int[listBox1.Items.Count]; //Declaracion de array de 20 numeros int.
                int aux = 0;


                for (int i = 0; i <= d.Length - 1; i++) {
                    d[i] = (int)listBox1.Items[i];

                }

                for (int i = 0; i <= d.Length - 2; i++) {
                    for (int j = i + 1; j <= d.Length - 1; j++) {
                        if (d[i] > d[j]) {

                            aux = d[i];
                            d[i] = d[j];
                            d[j] = aux;
                        }
                    }
                }
                for (int i = 0; i <= d.Length - 1; i++) {
                    string textito = i.ToString() + " - " + d[i].ToString();

                    listBox2.Items.Add(textito);
                }
            }
            
        }


    }
}




