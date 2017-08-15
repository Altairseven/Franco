using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.Classes;

namespace Gestion.Forms.Hechos_En_Clase {
    public partial class MaskedTB_Ejemplo : Gestion.Forms.EnClasesForm {
        public MaskedTB_Ejemplo()
        {
            InitializeComponent();
        }

        private void MaskedTB_Ejemplo_Load(object sender, EventArgs e)
        {
            Tools T = new Tools();
            this.mTextBox_Edit1.Mask = ">" + T.replicate("A", 10);
            

         }
    }
}
