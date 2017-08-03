using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ideas_Programacion.Forms.Templates;

namespace Ideas_Programacion.Forms.Texto {
    public partial class Remove_Vocales : Textos_Form {
        public Remove_Vocales() {
            InitializeComponent();
        }


        private void Disemvoweler() {
            string texto = textBox1.Text;
            string res1 = "";
            string res2 = "";
            foreach (char c in texto) {
                switch (c) {
                default:
                    res1 += c;
                    break;
                case 'a':
                    res2 += "a";
                    break;
                case 'e':
                    res2 += "e";
                    break;
                case 'i':
                    res2 += "i";
                    break;
                case 'o':
                    res2 += "o";
                    break;
                case 'u':
                    res2 += "u";
                    break;
                case ' ':
                    break;
                }
            }
            res1 += " " + res2;
            textBox2.Text = res1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            Disemvoweler();
        }
    }
}
