using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion {
    static class Program {

        //Guarda el string de conexion que sera usado globalmente por cualqueir form que lo requiera
        public static string Global_ConString { get; set; }

        //guarda los 2 strings de conexion. que seran asignados a la variable de arriba desde 2 posibles lugares: 
        //el settings form, y aca mismo, en el main.
        public static string[] _conString = new string[2] {
            @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=P:\Visual Studio\Franco\Gestion\Data\Gestion.mdf;Integrated Security = True",
            @"Data Source=FRANCO-ROG\ALTAIRSQL;Initial Catalog=Gestion;Integrated Security=True"
            };

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            switch (Properties.Settings.Default.ConString) {
                case 0: Program.Global_ConString = _conString[0]; break;
                case 1: Program.Global_ConString = _conString[1]; break;
            }

            switch (Properties.Settings.Default.StartForm) {
                case 0: Application.Run(new MainForm()); break;
                case 1: Application.Run(new MainDockForm()); break;
                case 2: Application.Run(new Forms.Principal()); break;
            }

            
        }
    }


}
