using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gestion.Data;
using Gestion.Classes;

namespace Gestion.Forms.Propios {
    public partial class Model_ABM : OwnForm {
        public Model_ABM() {
            InitializeComponent();
        }

        GestionEntities _db = new GestionEntities();
        List<ColSortOrder> ColSortlist = new List<ColSortOrder>();

        private void Model_ABM_Load(object sender, EventArgs e) {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Get_List();

            foreach (DataGridViewColumn col in dataGridView1.Columns) {
                ColSortlist.Add(new ColSortOrder(col.Name));
            }



            Format_Table();
        }

        #region Formato

        private void Format_Table() {
            
            //dataGridView1.Columns["ID"].Visible = false;
            //dataGridView1.Columns["ID_Tipo_Documento"].Visible = false;
            //dataGridView1.Columns["ID_Localidad"].Visible = false;
            //dataGridView1.Columns["DocNombre"].Index = 3;


        }


        #endregion

        public IEnumerable<ClientesEntity> Get_List(string Sortfield = "Nombre", string SortOrder = "ASC") {
            List<ClientesEntity> List = new List<ClientesEntity>();
            //Mediante Consulta sql

            switch (Sortfield) {
                case "LocNombre": Sortfield = "B.Nombre"; break;
                case "DocNombre": Sortfield = "C.Nombre"; break;
                default: Sortfield = "A." + Sortfield; break;
            }

            List = _db.Database.SqlQuery<ClientesEntity>(@"SELECT A.*, B.Nombre as LocNombre, C.Nombre as DocNombre  
                                                        FROM Clientes as A 
                                                        INNER JOIN Localidades as B on A.ID_Localidad = B.ID 
                                                        INNER JOIN Tipos_Documento as C on A.ID_Tipo_Documento = C.ID 
                                                        ORDER BY " + Sortfield + " " + SortOrder).ToList();



            ////Mediante Linq
            //var query = from a in _db.Clientes
            //            join b in _db.Localidades on a.ID_Localidad equals b.ID
            //            join c in _db.Tipos_Documento on a.ID_Tipo_Documento equals c.ID
            //            select new {
            //                a,
            //                LocNombre = b.Nombre,
            //                DocNombre = c.Nombre
            //            };

            //foreach (var item in query) {
            //    ClientesEntity _entity = new ClientesEntity(item.a);
            //    _entity.LocNombre = item.LocNombre;
            //    _entity.DocNombre = item.DocNombre;
            //}
            //if (SortOrder == "ASC")
            //    List = List.OrderBy(s => s.GetType().GetProperty(Sortfield).GetValue(s, null)).ToList();
            //else
            //    List = List.OrderByDescending(s => s.GetType().GetProperty(Sortfield).GetValue(s, null)).ToList();


            return List;
        }
        
        private void On_Order(object sender, DataGridViewCellMouseEventArgs e) {
            string sortfield = dataGridView1.Columns[e.ColumnIndex].Name;
            ColSortOrder order = ColSortlist.Where(x => x.ColName == sortfield).FirstOrDefault();
            if (order.Ord == "") order.Ord = "ASC";
            else if (order.Ord == "ASC") order.Ord = "DESC";
            else if (order.Ord == "DESC") order.Ord = "";
            foreach (ColSortOrder order1 in ColSortlist) {
                if (order1.ColName != sortfield)
                    order1.Ord = "";
            }
            dataGridView1.DataSource = Get_List(sortfield, order.Ord);
            int a = 1;
        }

        private void EditForm_Open(object sender, DataGridViewCellEventArgs e) {
           decimal id = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);


        }
    }

    public class ColSortOrder {

        public string  ColName { get; set; }
        public string Ord { get; set; }

        public ColSortOrder(string _colName) {
            ColName = _colName;
            Ord = "";
        }

    }


}



