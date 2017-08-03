using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceProcess;
using ServiceControl.Classes;


namespace ServiceControl.Forms {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }
        private int _excode;
        public int exCode {
            get { return _excode; }
            set {
                _excode = value;
                switch (_excode) {
                    case 0:
                        break;
                    case 403:
                        MessageBox.Show("No se ha encontrado el archivo de configuracion, se generara uno nuevo");
                        List<ServiceController> N = new List<ServiceController>();
                        List_Control.WriteConfigToFile(N);
                        _excode = 0;
                        break;
                    case 404:
                        DialogResult a = MessageBox.Show("Error al cargar la definicion de un servicio desde la configuracion" +
                                        "Desea Corregir manualmente el error?", "Error" + _excode.ToString(),
                                        MessageBoxButtons.YesNo);
                        if (a == DialogResult.Yes) { }
                        //Open Editor
                        _excode = 0;
                        break;
                }
            }
        }

        List<ServiceController> Selected;


        private Timer timer1;
        

        public void InitTimer() {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            List<int> indexes = StoreSelectedIndexes(dtgv1);
            Load_Data();
            dtgv1.Rows[0].Selected = false;
            RestoreSelectedIndexes(indexes, dtgv1);
        }

        private void Main_Load(object sender, EventArgs e) {
            Load_Data();
            dtgv1.Rows[0].Selected = false;
            InitTimer();
        }

        private List<int> StoreSelectedIndexes(DataGridView a) {
            List<int> _list = new List<int>();
            foreach (DataGridViewRow row in a.SelectedRows)
                _list.Add(row.Index);
            return _list;
        }
        private void RestoreSelectedIndexes(List<int> _list, DataGridView a) {
            foreach (int index in _list)
                a.Rows[index].Selected = true;
        
        }

        public void Load_Data() {
             Selected = List_Control.GetSelected(exCode);
            if (Selected == null) { 
                exCode = 403;
                Selected = List_Control.GetSelected(exCode);
            }
            dtgv1.DataSource = Selected;
            List_Control.ApplyFormat(dtgv1);
        }

        private void button1_Click(object sender, EventArgs e) {
            List<int> Sindexes = new List<int>();
            foreach (DataGridViewRow row in dtgv1.SelectedRows)
                Sindexes.Add(row.Index);
            for (int i = 0; i < Selected.Count; i++) 
                for (int j = 0; j < Sindexes.Count; j++) 
                    if(i == Sindexes[j])
                        if (Selected[i].Status != ServiceControllerStatus.Running)
                            Service_Control.StartService(Selected[i], 5000);
            foreach (DataGridViewRow row in dtgv1.SelectedRows)
                row.Selected = false;
        }

        private void button2_Click(object sender, EventArgs e) {
            
            foreach (ServiceController service in Selected)
                if (service.Status != ServiceControllerStatus.Running)
                    Service_Control.StartService(service, 5000);
            foreach (DataGridViewRow row in dtgv1.SelectedRows)
                row.Selected = false;
            
        }

        private void button3_Click(object sender, EventArgs e) {
            List<int> Sindexes = new List<int>();
            foreach (DataGridViewRow row in dtgv1.SelectedRows)
                Sindexes.Add(row.Index);
            for (int i = 0; i < Selected.Count; i++)
                for (int j = 0; j < Sindexes.Count; j++)
                    if (i == Sindexes[j])
                        if (Selected[i].Status != ServiceControllerStatus.Stopped)
                            Service_Control.StopService(Selected[i], 5000);
            foreach (DataGridViewRow row in dtgv1.SelectedRows)
                row.Selected = false;
        }

        private void button4_Click(object sender, EventArgs e) {
            foreach (ServiceController service in Selected)
                if (service.Status != ServiceControllerStatus.Stopped)
                    Service_Control.StopService(service, 5000);
            foreach (DataGridViewRow row in dtgv1.SelectedRows)
                row.Selected = false;
        }

        private void Settings_Click(object sender, EventArgs e) {
            ServicesForm form = new ServicesForm(this);
            form.ShowDialog();
        }

        private void Deselect(object sender, EventArgs e) {
            foreach (DataGridViewRow row in dtgv1.Rows)
                row.Selected = false;
        }
    }
}
