using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion.Classes {
    class listapotente {

        public int id { get; set; }
        public string Nombre { get; set; }
        public float temperatura { get; set; }

        public listapotente(int ID, string NOMBRE, float TEMP) {
            this.id = ID;
            Nombre = NOMBRE;
            temperatura = TEMP;

        }

    }
}
