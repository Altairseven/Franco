using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestion.Components.Estadistica;

namespace Gestion.Forms {
    public partial class Estadistica_Main : OwnForm {
        public Estadistica_Main() {
            InitializeComponent();
        }

        #region Descripcion (Para Mostrar en MainForm).
        private static string descripcion =
            "Permite Armar tabla de frecuencias, y calcular las formulas comunmente usadas." +
            Environment.NewLine + Environment.NewLine +
            "Sirve con Variables agrupadas, no agrupadas, y bidimensionales.";

        public static string Descripcion { get { return descripcion; } }
        #endregion

        Estadistica_panel panel;

        void panelsetup(int paneltype) {
            panel = new Estadistica_panel(paneltype);
            panel.Size = new Size(this.Width, this.Height - menuStrip1.Height);
            panel.Location = new Point(0, menuStrip1.Height);
            panel.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
            this.Controls.Add(panel);
        }
        void panelclose() {
            if (panel != null) {
                DialogResult a = MessageBox.Show("Esta Seguro que desea Cerrar el Ejercicio, Su Progreso desde la ultima vez que guardo se perdera", "Seguro", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                    this.Controls.Remove(panel);
            }
        }
        private void New1_Click(object sender, EventArgs e) {
            panelclose();
            panelsetup(1);
        }

        private void New2_Click(object sender, EventArgs e) {
            panelclose();
            panelsetup(2);
        }

        private void New3_Click(object sender, EventArgs e) {
            panelclose();
            panelsetup(3);
        }
    }






}
