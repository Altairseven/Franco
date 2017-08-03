using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gestion {
    public partial class ABM_Grilla : Gestion.Forms.EnClasesForm {
        public ABM_Grilla() {
            InitializeComponent();
        }

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        SqlConnection co;

        private void ABM_Grilla_Load(object sender, EventArgs e) {
            co = new SqlConnection(@"Data Source=FRANCO-NB\ALTAIRSQL;Initial Catalog=Gestion;Integrated Security=True");
            da = new SqlDataAdapter("SELECT * FROM Clientes", co);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);

           da.Fill(ds, "Clientes");
            da.AcceptChangesDuringFill = true;
            da.AcceptChangesDuringUpdate = true;
            bs.DataSource = ds;
            bs.DataMember = "Clientes";
            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
        }

        private void button1_Click(object sender, EventArgs e) {
            da.Update(ds, "Clientes");

        }
    }
}
