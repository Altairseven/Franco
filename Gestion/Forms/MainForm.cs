using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Microsoft.CSharp;
using System.Reflection;


namespace Gestion {
    public partial class MainForm : Gestion.Forms.OwnForm {
        public MainForm() {
            InitializeComponent();
        }

        List<FormData>[] FormsData;
        List<FormData> Lista;
        connectionstring con = new connectionstring();

        public static string ConString;


        private void MainForm_Load(object sender, EventArgs e) {
            toolStripComboBox1.Items.Add("LocalDB");
            toolStripComboBox1.Items.Add("LocalSQLServer");
            toolStripComboBox1.SelectedIndex = 1;
            constringinit();
            Setup_Forms();
        }
        
        //Hace una lista de todos los forms en el proyecto, y dependiendo de su herencia
        // los acomoda en Un TreeView

        private void Setup_Forms() {
            FormsData = new List<FormData>[3];

            Get_Forms[] forms = new Get_Forms[3] {
                    new Get_Forms("Gestion.Forms.EnClasesForm"),
                    new Get_Forms("Gestion.Forms.OwnForm"),
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
        
        private void toolStripComboBox1_IndexChanged(object sender, EventArgs e) {
            constringinit();
        }

        private void constringinit() {
            if (toolStripComboBox1.Text == "LocalSQLServer") {
                ConString = con.ConSrt(true);
            }
            else if (toolStripComboBox1.Text == "LocalDB") {
                ConString = con.ConSrt(false);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeView1.SelectedNode.Parent == null) 
                button1.Enabled = false;
            else {
                button1.Enabled = true;
                foreach (FormData fd in FormsData[treeView1.SelectedNode.Parent.Index])
                    if (fd.FormName == treeView1.SelectedNode.Text) {
                        Type obj = Type.GetType(fd.FormTypeName);
                        PropertyInfo p = obj.GetProperty("Descripcion");
                        if (p == null)
                            textBox1.Text = "";
                        else
                            textBox1.Text = p.GetValue(obj, null).ToString();
                    }
            }
                
        }

        private void RunForm() {
            if (treeView1.SelectedNode.Parent != null)
                foreach (FormData fd in FormsData[treeView1.SelectedNode.Parent.Index])
                    if (fd.FormName == treeView1.SelectedNode.Text) {
                        Form myObject = (Form)Activator.CreateInstance(Type.GetType(fd.FormTypeName));
                        myObject.Show();
                    }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e) {
            RunForm();
        }

        private void button1_Click(object sender, EventArgs e) {
            RunForm();
        }
    }
}
