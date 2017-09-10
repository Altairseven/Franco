using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProyect.Models.Entities {
    public class Tipos_DocumentoEntity {
        public decimal ID { get; set; }
        public string Nombre { get; set; }

        public Tipos_DocumentoEntity() {

        }

        public Tipos_DocumentoEntity(Tipos_Documento x) {
            ID = x.ID;
            Nombre = x.Nombre;

        }

    }
}