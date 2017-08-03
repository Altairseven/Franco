using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceProcess;
using ServiceControl.Classes;

namespace ServiceControl.Forms {
    public partial class ServicesForm : Form {
        public ServicesForm(Main a) {
            InstanceOfMain = a;
            InitializeComponent();
        }
        Main InstanceOfMain;

        List<ServiceController> listAll;
        List<ServiceController> listSelected;
        List<string> SLoadedFromFile;
        List<string> SelectedStrings = new List<string>();


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
                        break;
                    case 404:
                        DialogResult a = MessageBox.Show("Error al cargar la definicion de un servicio desde la configuracion" +
                                        "Desea Corregir manualmente el error?", "Error" + _excode.ToString(),
                                        MessageBoxButtons.YesNo);
                        if (a == DialogResult.Yes) { }
                        //Open Editor
                        break;
                }
            }
        }



        private void ServicesForm_Load(object sender, EventArgs e) {
            List_Control a = new List_Control();
            ConfigfileStatus F = List_Control.ReadFromFile(List_Control.SelectedServicesPath);
            if (F.Ex == null) {
                SLoadedFromFile = F.List;
                Load_Data();
            }
            else {
                this.exCode = 403;
                ServicesForm_Load(this,e);
            }

        }

        public void Load_Data() {
            listAll = Service_Control.GetServices("ServiceName");
            listSelected = List_Control.GetSelected(listAll, SLoadedFromFile, SelectedStrings, exCode);
            listAll = Service_Control.ServiceListSorting("DisplayName", listAll);
            listSelected = Service_Control.ServiceListSorting("DisplayName", listSelected);
            dataGridView2.DataSource = listSelected;
            dataGridView1.DataSource = listAll;
            List_Control.ApplyFormat(dataGridView1);
            List_Control.ApplyFormat(dataGridView2);
        }


        private void button1_Click(object sender, EventArgs e) {
            List_Control.AddMultipleToSelected(dataGridView1, SelectedStrings);
            Load_Data();
        }
        private void button2_Click(object sender, EventArgs e) {
            List_Control.RemoveMultipleFromSelected(dataGridView2, SLoadedFromFile, SelectedStrings);
            Load_Data();
        }

        private void Form_Closing(object sender, FormClosingEventArgs e) {
            if (listSelected.Count != 0) {
                DialogResult a = MessageBox.Show("Desea Guardar los Servicios Seleccionados", "Guardar?", MessageBoxButtons.YesNoCancel);
                switch (a) {
                case DialogResult.None:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Yes:
                    List_Control.WriteConfigToFile(listSelected);
                        InstanceOfMain.Load_Data();
                        //this.Dispose();
                    break;
                case DialogResult.No:
                    break;
                }
            }
        }
    }
}
