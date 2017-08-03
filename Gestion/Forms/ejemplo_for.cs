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
    public partial class ejemplo_for : Gestion.Forms.EnClasesForm {
        public ejemplo_for()
        {
            InitializeComponent();
        }

        #region Descripcion (Para Mostrar en MainForm).
        private static string descripcion =
            "Ejemplo Simple de un For Loop";

        public static string Descripcion { get { return descripcion; } }
        #endregion

        private void btn_calc_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(this.txt_num.Text);
            int sum = 0;

            for (int i = 1; i <= num; i++)
            {
                sum += i; //sum +1 = sum+=
            }
            this.txt_res.Text = sum.ToString();
        }

        private void ejemplo_for_Load(object sender, EventArgs e)
        {
            this.txt_num.Mask= "99";
        }


    }
}
