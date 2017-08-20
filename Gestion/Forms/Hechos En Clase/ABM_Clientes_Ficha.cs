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


namespace Gestion.Forms.Hechos_En_Clase {
    public partial class ABM_Clientes_Ficha : Form {
        public ABM_Clientes_Ficha() {
            InitializeComponent();
        }

        public DataSet ClientesDS = new DataSet();
        //Se encarga de la transferencia de datos entre el dataset y la tabla real
        public SqlDataAdapter DA = new SqlDataAdapter();
        public int Npuntero = 0; // puntero del registro del dataset
        public SqlConnection oCo = new SqlConnection(Program.Global_ConString); 
        


        private void LimiteCredito_TB_Leave(object sender, EventArgs e) {
            ID_TB.Focus();

            
        }

        private void ABM_Clientes_Ficha_Load(object sender, EventArgs e) {
            oCo.Open();
            DA = new SqlDataAdapter("SELECT * FROM clientes ORDER BY numclie ASC", oCo);
            SqlCommandBuilder aux = new SqlCommandBuilder(DA);
            DA.Fill(ClientesDS, "cliente");

            oCo.Close();

            
        }
    }
}
