using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProyect.Models.Entities;
using MVCProyect.Models;
using MVCProyect.Models.InterfaceRepositories;

namespace MVCProyect.Models.Repositories {
    public class TestRepository : ITestRepository {
        //referencia al modelo.
        GestionEntities _db = new GestionEntities();

        
        public IEnumerable<ClientesEntity> GetList(string sixid, string ord) {
            /*En el caso del primer getlist, voy a mostrar 2 formas de hacerlo
             * tanto con linq como con consulta sql normal. */

            // Comenta o descomenta a eleccion, para ver como se ejecuta cada una


            #region Metodo 1 (con Linq):
            List<ClientesEntity> list = new List<ClientesEntity>();

            try {
                //hago la consulta de linq, guardando el contenido en una variable generica
                // query, va a contener, a (que es el contenido de clientes), 
                //DocNombre, y LocNombre que son los campos agregados.

                var query = from a in _db.Clientes
                            join b in _db.Tipos_Documento on a.ID_Tipo_Documento equals b.ID
                            join c in _db.Localidades on a.ID_Localidad equals c.ID

                            select new {
                                a,
                                DocNombre = b.Nombre,
                                LocNombre = c.Nombre
                            };

                //loopeo en la variable query, creando una ClientesEntity nueva, 
                //con el contenido de cada elemento de query.a y asigno cada docnombre y locnombre a la misma entidad
                //teniendo asi la clientesentity completa, y lista para agregarla a la lista.
                foreach (var item in query) {
                    ClientesEntity Entity = new ClientesEntity(item.a);
                    Entity.DocNombre = item.DocNombre;
                    Entity.LocNombre = item.LocNombre;
                    list.Add(Entity);
                }
                /*
                finalmente, como tengo la lista completa, y es una coleccion que puede pasarse por linq de nuevo
                la ordeno en base al campo que me venga en sixid

                para ordernar por linq tenemos 2 formas: 
                 - haciendo un select case por cada campo la consulta seria algo asi como:
                        list.OrderBy(x => x.Nombre == sixid).ToList();
                 - usar Reflections, para escribir una sentencia linq que
                va a andar con cualquier campo que nos venga en sixid, esto seria asi:

                        list.OrderBy(x => x.GetType().GetProperty(sixid).GetValue(x)).ToList();
                        donde se obtiene el tipo, el nombre de la propiedad, y el valor de x."esapropiedad"

                 */
                //asi que solo hacemos un select case (o un if), para ordenar asc y desc
                switch (ord) {
                    case "asc":
                        list = list.OrderBy(s => s.GetType().GetProperty(sixid).GetValue(s)).ToList();
                        break;
                    case "desc":
                        list = list.OrderByDescending(s => s.GetType().GetProperty(sixid).GetValue(s)).ToList();
                        break;
                }

            }
            catch (Exception) {

                throw;
            }
            #endregion

            #region Metodo 2 (consulta sql)
            //List<ClientesEntity> list = new List<ClientesEntity>();
            //try {


            //    /*
            //    para el ordenamiento, como estamos usando mas de una tabla, tenemos q
            //    ajustar el campo de busqueda para q en la consulta, no tire error,
            //    si nos llega cualqueir campo q esta en cliente, tenemos q poner a."ese campo"
            //    si nos llega DocNombre y LocNombre, tenemos q poner b.Nombre, y C.Nombre respectivamente
            //    asi que hacemos un switch para manejar la porcion de orderby de la consulta
            //     */
            //    string OrderString = "";

            //    switch (sixid) {
            //        case "DocNombre":
            //            OrderString = "ORDER BY b.Nombre " + ord;
            //            break;
            //        case "LocNombre":
            //            OrderString = "ORDER BY c.Nombre " + ord;
            //            break;
            //        default:
            //            OrderString = "ORDER BY a." + sixid + " " + ord;
            //            break;
            //    }

            //    string Querystring = @"SELECT a.*, b.NOMBRE as DocNombre, c.Nombre as LocNombre
            //                           FROM Clientes a
            //                           INNER JOIN Tipos_Documento b on a.ID_Tipo_Documento = b.ID
            //                           Inner JOIN Localidades c on a.ID_Localidad = c.ID "
            //                           + OrderString; 

            //              //en ayj es diferente el comando para poder hacer la consulta, 
            //              //es  _Db.executeStoredQuery<>
            //    list = _db.Database.SqlQuery<ClientesEntity>(Querystring).ToList();

            //}
            //catch (Exception) {

            //    throw;
            //}

            #endregion

            //finalmente, devolvemos list al controlador
            return list;

        //porque no mandamos la excepcion en este caso?, porque aunq tire error, la lista va a estar vacia
        //xq esta inicializada al principio como una lista vacia, asi que va a devolver una lista vacia, que no
        //va a explotar en lo que siga, el error solo se veria al depurar, el usuario final solo veria q no anda.

        }

        public IEnumerable<ClientesEntity> GetList(string searchField, string searchValue, string searchOper,
                                                bool caseSensitive, string sixid = "Nombre", string ord = "ASC") {

            List<ClientesEntity> list = new List<ClientesEntity>();

            //Variables para almacenar la porcion de ordenamiento y de busqueda del string:
            string OrderString = string.Empty;
            string SearchString = "";
            //select case, igual q en el caso anterior, para el string de orden, dependiendo de q campo llega:

            switch (sixid) {
                case "DocNombre": OrderString = "ORDER BY b.Nombre " + ord; break;
                case "LocNombre": OrderString = "ORDER BY c.Nombre " + ord; break;
                default: OrderString = "ORDER BY a." + sixid + " " + ord; break;
            }
            //Lo mismo, pero para el campo de busqueda
            switch (searchField) {
                case "DocNombre": searchField = "b.Nombre"; break;
                case "LocNombre": searchField = "c.Nombre"; break;
                default: searchField = "a." + searchField; break;


            }
            //Trimeamos y mandamos a minuscula el valor buscado
            searchValue = searchValue.ToLower().Trim();
            //Creamos un substring con la porcion del operarador de la busqueda dependiendo de SearchOper
            switch (searchOper) {
                case "bw": searchOper = " LIKE '" + searchValue + "%'"; break;
                case "eq": searchOper = " = '" + searchValue + "'"; break;
                case "ne": searchOper = " <> " + searchValue; break;
                case "lt": searchOper = " < '" + searchValue + "'"; break;
                case "le": searchOper = " <= '" + searchValue + "'"; break;
                case "gt": searchOper = " > '" + searchValue + "'"; break;
                case "ge": searchOper = " >= '" + searchValue + "'"; break;
                case "ew": searchOper = " LIKE '%" + searchValue + "'"; break;
                case "cn": searchOper = " LIKE '%" + searchValue + "%'"; break;
                default: searchOper = ""; break;
            }

            if (searchOper != "")
                SearchString = "WHERE " + "LOWER(" + searchField + ")" + searchOper + " ";

            string Query = @"SELECT a.*, b.NOMBRE as DocNombre, c.Nombre as LocNombre 
                            FROM Clientes a
                            INNER JOIN Tipos_Documento b on a.ID_Tipo_Documento = b.ID
                            Inner JOIN Localidades c on a.ID_Localidad = c.ID " +
                            SearchString + OrderString;

            try {
                list = _db.Database.SqlQuery<ClientesEntity>(Query).ToList();
            }
            catch (Exception) { 

                throw;
            }
            return list;
        }
    }
}