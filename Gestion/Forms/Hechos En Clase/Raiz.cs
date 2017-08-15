using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion.Forms.Hechos_En_Clase {
    public partial class Raiz : EnClasesForm {
        public Raiz() {
            InitializeComponent();
        }

        private void Raiz_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            double Root;
            double value;
            double result;

            if (textBox1.Text.Contains("-") || textBox1.Text.Contains(".") || textBox1.Text.Contains(",") ||
                textBox2.Text.Contains("-") || textBox2.Text.Contains(".") || textBox2.Text.Contains(",")) {
                MessageBox.Show("Uno de los numeros ingresados es decimal o negativo");
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            }


            bool parse1 = Double.TryParse(textBox1.Text, out Root);
            bool parse2 = Double.TryParse(textBox2.Text, out value);

            if (!parse1 || !parse2)
                MessageBox.Show("Uno de los numeros ingresados no es Valido");
            else {
                double temp;
                for (int i = 0; i < value; i++) {
                    temp = Math.Pow(i, Root);
                    if (temp == value) {
                        result = i;
                        MessageBox.Show("GGWP " + result);
                        
                }  

                }


            }

        }
    }
}
