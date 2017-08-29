using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Microsoft.CSharp;
using System.Reflection;


namespace Gestion {
    public partial class MainDockForm : Gestion.Forms.OwnForm {
        public MainDockForm() {
            InitializeComponent();
        }

        List<FormData>[] FormsData;
        List<FormData> Lista;

        private void MainForm_Load(object sender, EventArgs e) {
            Setup_FormsByNamespace();
            tabControl1.Visible = false;
        }

        private void Setup_FormsByNamespace() {
            FormsData = new List<FormData>[3];


            Get_Forms_ByNameSpace Forms = new Get_Forms_ByNameSpace();

            Forms.AddFormList("Gestion.Forms.Hechos_En_Clase");
            Forms.AddFormList("Gestion.Forms.Propios");
            Forms.AddUncategorizedFormList();

            for (int i = 0; i < Forms.FormLists.Count; i++) {
                Lista = new List<FormData>();
                foreach (Type form in Forms.FormLists[i]) {
                    if (!Forms.Exceptions_check(form)) {
                        string a = form.Name.Replace("_", " ");
                        FormData FD = new FormData(i, a, form.FullName);
                        Lista.Add(FD);
                    }
                }
                FormsData[i] = (from a in Lista
                                orderby a.FormName ascending
                                select a).ToList();

                foreach (FormData FD in Lista) {
                    treeView1.Nodes[i].Nodes.Add(FD.FormName);
                }
            }
            Lista = null;
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeView1.SelectedNode.Parent != null){
                
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

        private void RunForm(object sender, EventArgs e) {
            if (treeView1.SelectedNode.Parent != null)
                foreach (FormData fd in FormsData[treeView1.SelectedNode.Parent.Index])
                    if (fd.FormName == treeView1.SelectedNode.Text) {
                        
                        Form myObject = (Form)Activator.CreateInstance(Type.GetType(fd.FormTypeName));
                        if (myObject.IsMdiContainer) {
                            myObject.Show();
                        }
                        else {
                            if (tabControl1.TabPages.Count == 0)
                                tabControl1.Visible = true;

                            myObject.TopLevel = false;
                            myObject.Dock = DockStyle.Fill;
                            myObject.FormBorderStyle = FormBorderStyle.None;
                            TabPage tab = new TabPage();
                            tab.Text = myObject.Name;
                            tab.Controls.Add(myObject);
                            myObject.Show();
                            tabControl1.TabPages.Add(tab);
                            tabControl1.SelectedTab = tab;
                        }
                    }
        }

        private void Ajustes_MouseEnter(object sender, EventArgs e) {
            Ajustes.Text = "Ajustes";
        }

        private void Ajustes_MouseLeave(object sender, EventArgs e) {
            Ajustes.Text = "";
        }

        private void Ajustes_Click(object sender, EventArgs e) {
            Forms.Settings settings = new Forms.Settings();
            settings.ShowDialog();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e) {
            var tabControl = sender as TabControl;
            var tabs = tabControl.TabPages;

            if (e.Button == MouseButtons.Middle) {
                tabs.Remove(tabs.Cast<TabPage>()
                        .Where((t, i) => tabControl.GetTabRect(i).Contains(e.Location))
                        .First());
                if (tabs.Count == 0)
                    tabControl1.Visible = false;
            }
        }
    }
}
