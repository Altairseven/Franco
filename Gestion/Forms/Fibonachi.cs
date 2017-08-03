using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion.Forms {
    public partial class Fibonachi : EnClasesForm {
        public Fibonachi() {
            InitializeComponent();
        }

        private void fib_bn_Click(object sender, EventArgs e) {
            int outParse;
            listBox1.Items.Clear();
            // Check if the point entered is numeric or not
            if (!Int32.TryParse(FibTB.Text, out outParse)) {
                MessageBox.Show("Solo Se permiten Numeros Enteros.");
            }
            else {
                int x = Int32.Parse(FibTB.Text);
                if (x < 0) {
                    MessageBox.Show("Ingrese un numero de valor positivo");
                }
                else {
                    int fib1 = 0;
                    int fib2 = 1;
                    int ac = fib2;
                    listBox1.Items.Add("0");
                    for (int i = 1; i < x; i++) {
                        ac = fib2 + fib1;
                        fib1 = fib2;
                        fib2 = ac;
                        listBox1.Items.Add(ac.ToString());
                    }
                }
            }

        }
    }
}
