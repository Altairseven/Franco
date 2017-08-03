using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion
{
    public partial class ejemplo_separar_par_impar : Gestion.Forms.EnClasesForm {
        public ejemplo_separar_par_impar()
        {
            InitializeComponent();
        }

        #region Descripcion (Para Mostrar en MainForm).
        private static string descripcion =
            "A partir de una lista de Numeros Randoms, divide los pares, " +
            "y los impares en diferentes listas.";

        public static string Descripcion { get { return descripcion; } }
        #endregion

        private void ejemplo_separar_par_impar_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 1; i <= 20; i++)
            {
                this.Lst_num.Items.Add(r.Next(1, 100));
            }
            this.Lst_num.SelectedIndex = 0;
        }

        private void bt_separar_Click(object sender, EventArgs e)
        {
            int aux;
            for (int i = 0; i < Lst_num.Items.Count - 1; i++)
            {
                aux = Convert.ToInt32(Lst_num.Items[i]);
                if (aux % 2 == 0)
                {
                    lst_p.Items.Add(aux.ToString());
                }
                else
                {
                    lst_i.Items.Add(aux.ToString());
                }
            }
        }
    }
}
