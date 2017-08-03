using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion
{
    public partial class Prueba_ado : Gestion.Forms.EnClasesForm {
        public Prueba_ado(){
            InitializeComponent();
        }

        public SqlConnection co = new SqlConnection(MainForm.ConString);
        public DataSet ds= new DataSet();

        private void Prueba_ado_Load(object sender, EventArgs e) {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Clientes", co);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);

            da.Fill(ds, "clientes");

            var b = ds.Tables[0].DefaultView;
            string aux;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++) // loop en el registro.
            {
                aux = b[i]["limitecredito"].ToString();
                
            }
            dataGridView1.DataSource = b;
            //bindingSource1.DataSource = ds.Tables[0];
            
            //bindingNavigator1.BindingSource = this.bindingSource1;



        }
    }
}
