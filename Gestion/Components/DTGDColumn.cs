using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion.Components {
    public partial class DTGDColumn : DataGridViewColumn {

        public string test { get; set; }

        public DTGDColumn() {
            InitializeComponent();
        }
    }
}
