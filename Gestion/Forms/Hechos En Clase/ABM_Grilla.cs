﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Gestion.Data;

namespace Gestion.Forms.Hechos_En_Clase {
    public partial class ABM_Grilla : Gestion.Forms.EnClasesForm {
        public ABM_Grilla() {
            InitializeComponent();
        }

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        SqlConnection co;

        private void ABM_Grilla_Load(object sender, EventArgs e) {
            co = new SqlConnection(Program.Global_ConString);
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
