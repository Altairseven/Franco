using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Model;

namespace MVC.Model.Entities {
    public class ClientesEntity {

        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int ID_Tipo_Documento { get; set; }
        public string Documento { get; set; }
        public int? CUIT { get; set; }
        public string Direccion { get; set; }
        public int ID_Localidad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string DocNombre { get; set; }
        public string LocNombre { get; set; }


        public ClientesEntity() {

        }
        public ClientesEntity(Clientes c) {
            ID = c.ID;
            Nombre = c.Nombre;
            Apellido = c.Apellido;
            ID_Tipo_Documento = c.ID_Tipo_Documento;
            Documento = c.Documento;
            CUIT = c.CUIT;
            Direccion = c.Direccion;
            ID_Localidad = c.ID_Localidad;
            Telefono = c.Telefono;
            Celular = c.Celular;
            Email = c.Email;

        }
    }
}
