using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProyect.Models.Entities;
using MVCProyect.Models;
using MVCProyect.Models.InterfaceRepositories;

namespace MVCProyect.Models.Repositories {
    public class Tipos_DocumentoRepository {

        GestionEntities _db = new GestionEntities();

        public List<Tipos_DocumentoEntity> GetList() {
            List<Tipos_DocumentoEntity> List = new List<Tipos_DocumentoEntity>();
            foreach (Tipos_Documento tipo in _db.Tipos_Documento.OrderBy(x => x.Nombre).ToList()) {
                List.Add(new Tipos_DocumentoEntity(tipo));
            }
            return List;
        }


    }
}