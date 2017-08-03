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

namespace Gestion.Forms {
    public partial class DD_arbolMenu_Propio : OwnForm {
        public DD_arbolMenu_Propio() {
            InitializeComponent();
        }


        //DataSet primer_nivel = new DataSet();
        //int max_id = 0;
        //int cont_imagenes = 0;
        //int max_orden = 0;
        //ImageList il = new ImageList();



        //private void DDarbolMenu_Load(object sender, EventArgs e) {
        //    arbol();
        //}
        //public void arbol() {
        //    treeView1.ImageList = il;
        //    int flag = 0;
        //    // Determinar el maximo id usado para seguir numerando
        //    Program.con.Open();
        //    string cSql = "SELECT MAX(id_item) max FROM tree_menu ";
        //    SqlCommand _cmd = new SqlCommand(cSql);
        //    _cmd.Connection = Program.co;
        //    SqlDataReader rdr = _cmd.ExecuteReader();
        //    if (rdr.HasRows) {
        //        rdr.Read();
        //        max_id = (int)rdr["max"];
        //        max_id++;
        //    }
        //    rdr.Close();
        //    Program.co.Close();
        //    // Determinar el maximo orden para los nuevos nodos
        //    Program.co.Open();
        //    cSql = "SELECT MAX(orden) max FROM tree_menu ";
        //    SqlCommand cmd1 = new SqlCommand(cSql);
        //    cmd1.Connection = Program.co;
        //    rdr = _cmd.ExecuteReader();
        //    if (rdr.HasRows) {
        //        rdr.Read();
        //        max_orden = (int)rdr["max"];
        //        max_orden++;
        //    }
        //    rdr.Close();
        //    Program.co.Close();

        //    List<nodo_arbo_menu> nodos = new List<nodo_arbo_menu>();
        //    string id_item;
        //    string titulo;
        //    Program.co.Open();
        //    cSql = "SELECT id_item,titulo FROM tree_menu WHERE id_item_padre = 0 ORDER BY orden";
        //    SqlCommand cmd = new SqlCommand(cSql);
        //    cmd.Connection = Program.co;
        //    rdr = cmd.ExecuteReader();
        //    if (rdr.HasRows) {
        //        while (rdr.Read()) {
        //            id_item = rdr["id_item"].ToString().Trim();
        //            titulo = rdr["titulo"].ToString().Trim().ToUpper();
        //            nodo_arbo_menu n = new nodo_arbo_menu();
        //            n.id_item = id_item;
        //            n.titulo = titulo;
        //            nodos.Add(n);
        //        }
        //        rdr.Close();
        //        Program.co.Close();
        //        foreach (nodo_arbo_menu n in nodos) {
        //            TreeNode newNode = new TreeNode(n.titulo);
        //            newNode.Tag = n.id_item;
        //            tree.Nodes.Add(newNode);
        //            if (flag == 0) {
        //                txtFull.Text = newNode.FullPath.ToLower();
        //                flag = 1;
        //            }
        //            cargar_arbol(n.id_item, newNode);
        //        }
        //    }
        //    tree.ExpandAll();
        //}
        //private void cargar_arbol(string id_item, TreeNode n) {

        //    List<nodo_arbo_menu> nodos_hijos = new List<nodo_arbo_menu>();
        //    SqlDataReader rdr;
        //    SqlCommand cmd;
        //    string titulo;
        //    int grupo = 0;
        //    string icono;
        //    Program.co.Open();
        //    string cSql = "SELECT id_item,titulo,grupo,icono FROM tree_menu WHERE id_item_padre = " + id_item + " ORDER BY orden";
        //    cmd = new SqlCommand(cSql);
        //    cmd.Connection = Program.co;
        //    rdr = cmd.ExecuteReader();
        //    if (rdr.HasRows) {
        //        while (rdr.Read()) {
        //            id_item = rdr["id_item"].ToString().Trim();
        //            titulo = rdr["titulo"].ToString().Trim().ToUpper();
        //            grupo = (int)rdr["grupo"];
        //            icono = "";
        //            if (rdr["icono"] != System.DBNull.Value) {
        //                icono = rdr["icono"].ToString().Trim();
        //            }
        //            nodo_arbo_menu nh = new nodo_arbo_menu();
        //            nh.id_item = id_item;
        //            nh.titulo = titulo;
        //            nh.grupo = grupo;
        //            nh.icono = icono;
        //            nodos_hijos.Add(nh);
        //        }
        //        Program.co.Close();
        //        rdr.Close();
        //        foreach (nodo_arbo_menu _n in nodos_hijos) {
        //            TreeNode newNode = new TreeNode(_n.titulo);
        //            newNode.Tag = _n.id_item;
        //            if (_n.grupo == 1) {
        //                newNode.Checked = true;
        //            }
        //            if (!string.IsNullOrEmpty(_n.icono)) {
        //                il.Images.Add(Image.FromFile(Program.path_iconos + _n.icono));
        //                newNode.ImageIndex = cont_imagenes;
        //                cont_imagenes++;
        //            }
        //            n.Nodes.Add(newNode);
        //            cargar_arbol(_n.id_item, newNode);
        //        }
        //    }
        //    else {
        //        rdr.Close();
        //        Program.co.Close();
        //    }
        //}

        //private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
        //    txtFull.Text = e.Node.FullPath.ToLower();
        //    string id_item = e.Node.Tag.ToString();
        //    string ejecuta;
        //    string titulo;
        //    string modulo;
        //    int grupo;
        //    Program.co.Open();
        //    string cSql = "SELECT ejecuta,icono,titulo,id_modulo,grupo FROM tree_menu WHERE id_item = " + id_item;
        //    SqlCommand cmd = new SqlCommand(cSql);
        //    cmd.Connection = Program.co;
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    if (rdr.HasRows) {
        //        rdr.Read();
        //        ejecuta = rdr["ejecuta"].ToString().Trim();
        //        titulo = rdr["titulo"].ToString().Trim();
        //        modulo = rdr["id_modulo"].ToString().Trim();
        //        grupo = (int)rdr["grupo"];
        //        chcGrupo.Checked = false;
        //        if (grupo == 1) {
        //            chcGrupo.Checked = true;
        //        }
        //        txtTitulo.Text = titulo;
        //        txtEjecuta.Text = ejecuta;
        //        txtModulo.Text = modulo;
        //        txtID.Text = id_item;
        //        txtIcono.Text = "";
        //        if (!string.IsNullOrEmpty(rdr["icono"].ToString().Trim())) {
        //            txtIcono.Text = rdr["icono"].ToString().Trim();
        //        }
        //    }
        //    rdr.Close();
        //    Program.co.Close();
        //}

        //private void btnNuevoNodoHijo_Click(object sender, EventArgs e) {
        //    int r = (int)MessageBox.Show("¿Confirma la inserción de un nuevo nodo hijo?", "Sistema", MessageBoxButtons.OKCancel);
        //    if (r == 2) // 1=> Si , 2 => No
        //    {
        //        return;
        //    }
        //    // Crear el nodo en la tabla
        //    string id_item_padre = txtID.Text.Trim();
        //    string id_modulo = txtModulo.Text.Trim();
        //    string id_item = max_id.ToString();
        //    max_id++;
        //    string ejecuta = txtEjecuta.Text.Trim();
        //    string orden = max_orden.ToString();
        //    max_orden++;
        //    string titulo = txtTitulo.Text.Trim();
        //    string grupo = "0";
        //    if (chcGrupo.Checked) {
        //        grupo = "1";
        //    }
        //    string icono = txtIcono.Text.Trim();
        //    Program.co.Open();
        //    string cSql = "INSERT INTO tree_menu (id_item_padre , id_modulo,id_item,ejecuta,orden,titulo,grupo,icono) VALUES (";
        //    string cVal = id_item_padre + "," + id_modulo + "," + id_item + ",'" + ejecuta + "'," + orden + ",'" + titulo + "'," + grupo + ",'" + icono + "')";
        //    cSql += cVal;
        //    SqlCommand cmd = new SqlCommand(cSql);
        //    cmd.Connection = Program.co;
        //    int ret = cmd.ExecuteNonQuery();
        //    Program.co.Close();
        //    tree.Nodes.Clear();
        //    arbol();
        //    AutoClosingMessageBox.Show("El nodo hijo fue insertado con éxito", "Nuevo nodo hijo", 1000);
        //}

        //private void btnActu_Click(object sender, EventArgs e) {
        //    int r = (int)MessageBox.Show("¿Confirma la actualización del nodo seleccionado?", "Agregar", MessageBoxButtons.OKCancel);
        //    if (r == 2) // 1=> Si , 2 => No
        //    {
        //        return;
        //    }
        //    // Crear el nodo en la tabla
        //    string id_item = txtID.Text.Trim();
        //    string ejecuta = txtEjecuta.Text.Trim();
        //    string titulo = txtTitulo.Text.Trim();
        //    string grupo = "0";
        //    if (chcGrupo.Checked) {
        //        grupo = "1";
        //    }
        //    string icono = txtIcono.Text.Trim();
        //    Program.co.Open();
        //    string cUp = "UPDATE tree_menu SET grupo = " + grupo + ", ejecuta = '" + ejecuta + "' , titulo = '" + titulo + "', icono ='" + icono + "' WHERE id_item = " + id_item;
        //    SqlCommand cmd = new SqlCommand(cUp);
        //    cmd.Connection = Program.co;
        //    int ret = cmd.ExecuteNonQuery();
        //    Program.co.Close();
        //    AutoClosingMessageBox.Show("El nodo fue actualizado con éxito", "Actualizar", 1000);
        //    tree.Nodes.Clear();
        //    arbol();
        //}

        //private void btnBuscarIcono_Click(object sender, EventArgs e) {
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    openFileDialog1.InitialDirectory = Program.path_iconos;
        //    openFileDialog1.Filter = "Iodos los archivos (*.*)|*.*|Iconos (*.ico)|*.ico|GIF (*.gif)|*.gif|BMP (*.bmp)|*.bmp|JPG (*.jpg)|*.jpg";
        //    openFileDialog1.RestoreDirectory = true;
        //    if (openFileDialog1.ShowDialog() == DialogResult.OK) {
        //        string file = openFileDialog1.FileName.Trim();
        //        int pos = file.LastIndexOf(@"\");
        //        file = file.Substring(pos + 1);
        //        txtIcono.Text = file;
        //    }
        //}

        //private void btnBorrarNodo_Click(object sender, EventArgs e) {
        //    int r = (int)MessageBox.Show("¿Confirma la eliminación del nodo seleccionado?", "Sistema", MessageBoxButtons.OKCancel);
        //    if (r == 2) // 1=> Si , 2 => No
        //    {
        //        return;
        //    }
        //    string id_item = txtID.Text.Trim();
        //    Program.co.Open();
        //    string cDe = "DELETE tree_menu WHERE id_item = " + id_item;
        //    SqlCommand cmd = new SqlCommand(cDe);
        //    cmd.Connection = Program.co;
        //    int ret = cmd.ExecuteNonQuery();
        //    Program.co.Close();
        //    AutoClosingMessageBox.Show("El nodo fue borrado con éxito", "Borrar", 1000);
        //    tree.Nodes.Clear();
        //    arbol();
        //}

        //private void btnOrdenarHijos_Click(object sender, EventArgs e) {
        //    // Traer nodos hijos
        //    List<string> li = new List<string>();
        //    string item;
        //    string id_item = txtID.Text.Trim();
        //    string titulo;
        //    Program.co.Open();
        //    string cSql = "SELECT id_item,titulo FROM tree_menu WHERE id_item_padre = " + id_item + " ORDER BY orden";
        //    SqlCommand cmd = new SqlCommand(cSql);
        //    cmd.Connection = Program.co;
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    if (rdr.HasRows) {
        //        while (rdr.Read()) {
        //            id_item = rdr["id_item"].ToString().Trim();
        //            titulo = rdr["titulo"].ToString().Trim();
        //            item = id_item + "-" + titulo;
        //            li.Add(item);
        //        }
        //    }
        //    rdr.Close();
        //    Program.co.Close();
        //    DD_arbolMenuOrdenar f = new DD_arbolMenuOrdenar(li);
        //    f.ShowDialog();
        //    if (f.ok) {
        //        tree.Nodes.Clear();
        //        arbol();
        //    }
        //}
    }
}


