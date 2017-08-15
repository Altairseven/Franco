using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion.Forms.Hechos_En_Clase;
using Gestion.Forms.Propios;

namespace Gestion.Forms.Propios {
    public partial class Dock_Form_As_Panel : OwnForm {
        public Dock_Form_As_Panel() {
            InitializeComponent();
        }

        #region Descripcion (Para Mostrar en MainForm).
        private static string descripcion =
            "Este formulario demuestra como podemos instanciar formularios directamente adentro del mismo, ya sea " +
            "como ventana movible, o dockeado en un panel, lo que nos permite crear interfaces dinamicas con contenido cambiante," +
            "esto ultimo, tambien puede aplicarse a una vista con pestañas";

        public static string Descripcion { get { return descripcion; } }
        #endregion

        private void Dock_Form_As_Panel_Load(object sender, EventArgs e) {
            textBox1.Text = descripcion; textBox1.Select(0,0);
        }

        private void button1_Click(object sender, EventArgs e) {

            //Lo normal.. instanceamos un form, y lo mostramos
            DD_arbolMenu_Propio ABM = new DD_arbolMenu_Propio();
            ABM.Show();  //podriamos usar .ShowDialog() para dialogo q trabe la ventana actual.

            #region Reseteo y estetica (Ignorar)

            trashlist.Add(ABM);

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            button5.Visible = true;
            #endregion
        }

        private void button2_Click(object sender, EventArgs e) {

            //De la misma manera instanciamos un form
            DD_arbolMenu_Propio ABM = new DD_arbolMenu_Propio();

            //seteamos la propiedad TopLevel en falso, ya que sino el form no nos 
            //permite hacerlo hijo de otro control.
            ABM.TopLevel = false;

            //agregamos el form al formulario actual, como un control cualquiera.
            this.Controls.Add(ABM);

            //lo mostramos.
            ABM.Show();

            //Lo traemos al frente, para que no aparesca atras de otros controles
            ABM.BringToFront();

            #region Reseteo y estetica (Ignorar)

            trashlist.Add(ABM);

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            button5.Visible = true;
            #endregion
        }

        private void button3_Click(object sender, EventArgs e) {
            DD_arbolMenu_Propio ABM = new DD_arbolMenu_Propio();
            ABM.TopLevel = false;
            //Como esta vez vamos a colocarlo en un panel.. tenemos que 
            //remover los bordes del form, y dockearlo(para que se estire) 
            //en el padre que va a tener
            ABM.FormBorderStyle = FormBorderStyle.None;
            ABM.Dock = DockStyle.Fill;
            ABM.AutoScroll = true; //Permite barras de desplazamiento

            //lo agregamos al panel, como le pusismos el docke en Fill, se va a estirar
            //ocupando todo el tamaño del panel.
            this.panel1.Controls.Add(ABM);
            //lo mostramos.
            ABM.Show();

            //NOTA: al diseñar el formulario que vamos a anclar en un panel tenemos q considerar
            //setear bien la propiedad anchor de sus diferentes controles, para que en caso de que 
            //se redimensione el formulario (que en este caso seguramente va a hacer), 
            //no queden chicos, o fuera de lugar los mismos.



            #region Reseteo y estetica (Ignorar)

            trashlist.Add(ABM);

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            button5.Visible = true;
            #endregion



        }

        private void button4_Click(object sender, EventArgs e) {
            // instanceamos 3 formularios
            DD_arbolMenu_Propio ABM = new DD_arbolMenu_Propio();
            Metodo_Burbuja Burbuja = new Metodo_Burbuja();
            Busqueda_Dicotomica BDic = new Busqueda_Dicotomica();

            //Como queremos mostrarlos en diferentes pestañas, y en formulario 
            //solo tenemos un panel, instanciamos un TabControl y lo dockeamos en el panel:
            TabControl TabCon = new TabControl();
            TabCon.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(TabCon);
            TabCon.Show();

            //instanciamos 3 pestañas vacias:
            TabPage tab1 = new TabPage();
            TabPage tab2 = new TabPage();
            TabPage tab3 = new TabPage();

            //Asignamos cada formulario a una pestaña, seteandolo como en los casos anteriores
            //Pestaña 1
            ABM.TopLevel = false;
            ABM.FormBorderStyle = FormBorderStyle.None;
            ABM.Dock = DockStyle.Fill;
            ABM.AutoScroll = true;
            tab1.Text = ABM.Text;
            tab1.Controls.Add(ABM);
            ABM.Show();


            //Pestaña 2
            Burbuja.TopLevel = false;
            Burbuja.FormBorderStyle = FormBorderStyle.None;
            Burbuja.Dock = DockStyle.Fill;
            Burbuja.AutoScroll = true;
            tab2.Text = Burbuja.Text;
            tab2.Controls.Add(Burbuja);
            Burbuja.Show();


            //Pestaña 3
            BDic.TopLevel = false;
            BDic.FormBorderStyle = FormBorderStyle.None;
            BDic.Dock = DockStyle.Fill;
            BDic.AutoScroll = true;
            tab3.Text = BDic.Text;
            tab3.Controls.Add(BDic);
            BDic.Show();


            //Finalmente, asignamos las 3 pestañas al TabControl:
            TabCon.TabPages.Add(tab1);
            TabCon.TabPages.Add(tab2);
            TabCon.TabPages.Add(tab3);

            #region Reseteo y estetica (Ignorar)

            trashlist.Add(ABM);
            trashlist.Add(Burbuja);
            trashlist.Add(BDic);
            trashlist.Add(TabCon);
            trashlist.Add(tab1);
            trashlist.Add(tab2);
            trashlist.Add(tab3);

            panel1.BackColor = System.Drawing.SystemColors.Control;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            button5.Visible = true;
            #endregion


        }

        #region Reseteo y estetica (Ignorar)

        List<object> trashlist = new List<object>();

        public void DisposeAll(IEnumerable set) {
            foreach (Object obj in set) {
                IDisposable disp = obj as IDisposable;
                if (disp != null) { disp.Dispose(); }
            }
        }
        private void button5_Click(object sender, EventArgs e) {
            panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;

            DisposeAll(trashlist);
            trashlist.Clear();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            button5.Visible = false;

        }

        #endregion


    }
}
