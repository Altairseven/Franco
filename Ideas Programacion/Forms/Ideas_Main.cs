using System;
using System.Windows.Forms;
using Ideas_Programacion.Classes;
using Gestion.Forms;
using System.Collections.Generic;

namespace Ideas_Programacion {
    public partial class Ideas_Main : OwnForm {
        public Ideas_Main() {
            InitializeComponent();
        }

        List<FormData>[] FormsData;
        List<FormData> Lista;

        private void Form1_Load(object sender, EventArgs e) {
            SetupForms();
        }

        private void SetupForms() {
            FormsData = new List<FormData>[11];

            Get_Forms[] forms = new Get_Forms[11] {
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Numeros_Form"),
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Textos_Form"),
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Red_Form"),
                    new Get_Forms("Ideas_Programacion.Forms.Templates.EmpresaApp_Form"),
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Hilos_Form"),
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Web_Form") ,
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Files_Form"),
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Database_Form"),
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Media_Form"),
                    new Get_Forms("Ideas_Programacion.Forms.Templates.Juegos_Form"),
                    new Get_Forms("System.Windows.Forms.Form")
            };

            for (int i = 0; i < forms.Length; i++) {
                Lista = new List<FormData>();
                foreach (Type form in forms[i].Formlist) {
                    if (forms[i].Exceptions_check(form) == false) {
                        string a = form.Name.Replace("_", " ");
                        FormData FD = new FormData(i, a, form.FullName);
                        Lista.Add(FD);
                    }
                }
                FormsData[i] = Lista;
                foreach (FormData FD in Lista) {
                    treeView1.Nodes[i].Nodes.Add(FD.FormName);
                }
            }
            Lista = null;
            treeView1.ExpandAll();
        }

        private void treeView1_DoubleClick(object sender, EventArgs e) {
            if (treeView1.SelectedNode.Parent != null)
                foreach (FormData fd in FormsData[treeView1.SelectedNode.Parent.Index])
                    if (fd.FormName == treeView1.SelectedNode.Text) {
                        Form myObject = (Form)Activator.CreateInstance(Type.GetType(fd.FormTypeName));
                        myObject.Show();
                    }
        }
    }
}
