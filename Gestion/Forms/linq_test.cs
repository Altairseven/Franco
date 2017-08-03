using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gestion {
    public partial class linq_test : Gestion.Forms.OwnForm {
        public linq_test() {
            InitializeComponent();
        }

        LINQDataContext db;

        private void linq_test_Load(object sender, EventArgs e) {
            reload();
        }

        private void reload() {
            db = new LINQDataContext(MainForm.ConString);
            dataGridView1.DataSource = db.clientes;
        }

        private void button1_Click(object sender, EventArgs e) {
            var querry = from c in db.clientes
                         where c.numclie == 2106
                         select c.nombre;
            
            MessageBox.Show(querry.Single().ToString());

        }

        private void button2_Click_1(object sender, EventArgs e) {
            var querry = (from c in db.clientes
                         where c.numclie == 2106
                         select new {
                             id = c.numclie,
                             nombre = c.nombre,
                             cred = c.limitecredito
                             
                         }).Single();

            MessageBox.Show(String.Format("id: {0} \nNombre: {1} \nLimite de Credito: {2}",
                        querry.id.ToString(), querry.nombre.ToString(), querry.cred.ToString()));
        }

        private void insBT_Click(object sender, EventArgs e) {
            int newid;
            int newlc;
            if (int.TryParse(textBox1.Text, out newid) && int.TryParse(textBox3.Text, out newlc)) {
                cliente newclient = new cliente();

                    newclient.numclie = newid;
                    newclient.nombre = textBox2.Text.Trim();
                    newclient.limitecredito = newlc;

                db.clientes.InsertOnSubmit(newclient);
                db.SubmitChanges();
                reload();
            }
            else {
                MessageBox.Show("pone numeros en el id y limite de credito");
            }
        }

        private void updBT_Click(object sender, EventArgs e) {
            int cid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            int newid;
            int newlc;
            if (int.TryParse(textBox1.Text, out newid) && int.TryParse(textBox3.Text, out newlc)) {
                // aca esta con una sintaxis mas resumida, usar la otra se complica:
                var querry = db.clientes.Where(w => w.numclie == cid).FirstOrDefault();
                querry.numclie = newid;
                querry.nombre = textBox2.Text;
                querry.limitecredito = newlc;
                db.SubmitChanges();
            }
            else 
                MessageBox.Show("Fire Fire Ratatatatata");    
        }

        private void delBT_Click(object sender, EventArgs e) {
            int cid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var querry = db.clientes.Where(w => w.numclie == cid).FirstOrDefault();
            db.clientes.DeleteOnSubmit(querry);
            db.SubmitChanges();
            reload();

        }
    }
}