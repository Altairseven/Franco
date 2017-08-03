using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestion.Components.Estadistica;

namespace Gestion.Components.Estadistica {
    public partial class Estadistica_panel : UserControl {
        public Estadistica_panel(int paneltype) {
            InitializeComponent();
            if (paneltype == 1) {
                E_panel1 content = new E_panel1();
                content.Dock = DockStyle.Fill;
                this.Controls.Add(content);
            }
            else if (paneltype == 2) {
                E_panel2 content = new E_panel2();
                content.Dock = DockStyle.Fill;
                this.Controls.Add(content);
            }
            else if (paneltype == 3) {
                E_panel3 content = new E_panel3();
                content.Dock = DockStyle.Fill;
                this.Controls.Add(content);
            }
        }
    }
}
