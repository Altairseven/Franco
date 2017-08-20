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
using Gestion.Data;

namespace Gestion.Forms.Hechos_En_Clase {
    public partial class ABM_Ficha : EnClasesForm {
        public ABM_Ficha() {
            InitializeComponent();
        }

        
        public bool editmode { get; set; }

        private void Form1_Load(object sender, EventArgs e) {
            editmode = false;
        }

        private void EditMode(bool mode) {
            if (mode) {
                editmode = true;
                AddSave_BT.Image = Gestion.Properties.Resources.floppy1;
                AddSave_BT.Text = "Guardar";
                Del_BT.Image = Gestion.Properties.Resources.sign_delete;
                Del_BT.Text = "Cancelar";
                groupBox1.Visible = false;
                Search_BT.Enabled = false;
            }
            else {
                editmode = false;
                AddSave_BT.Image = Gestion.Properties.Resources.sign_add;
                AddSave_BT.Text = "Nuevo";
                Del_BT.Image = Gestion.Properties.Resources.trashcan;
                Del_BT.Text = "Eliminar";
                groupBox1.Visible = true;
                Search_BT.Enabled = true;
            }
        }

        private void AddSaveBT_Click(object sender, EventArgs e) {
            if (!editmode)
                EditMode(true);
            else
                EditMode(false);
               
        }

        private void Search_BT_Click(object sender, EventArgs e) {
           ABM_Ficha_Busqueda_Cliente Search =  new ABM_Ficha_Busqueda_Cliente();
            Search.Show();
        }
    }
}
