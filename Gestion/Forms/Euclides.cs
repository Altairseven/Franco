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
    public partial class Euclides : Gestion.Forms.EnClasesForm {
        public Euclides()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(tb.Text);
            int num2 = Convert.ToInt32(tb2.Text);
            int res = mcd(num1, num2);
            tb3.Text = res.ToString();
        }
        public int mcd(int num1, int num2)
        {
            int mcd = 0;
            int a = Math.Max(num1, num2);
            int b = Math.Min(num1, num2);
            do
            {
                mcd = b;
                b = a % b;
                a = mcd;
            } while (b != 0);
            return mcd;


        }

        private void Euclides_Load(object sender, EventArgs e)
        {

        }
    }
}