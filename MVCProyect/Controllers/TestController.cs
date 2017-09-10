using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProyect.Models.Entities;
using MVCProyect.Models.Repositories;
using MVCProyect.Models.InterfaceRepositories;


namespace MVCProyect.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        ITestRepository _repository = new TestRepository();
        

        public JsonResult GetList(int page, int rows, string[] sidx, string[] sord, string[] searchField,
                                    string[] searchString, string[] searchOper, object sortorder) {
            IEnumerable<ClientesEntity> Entidades = new List<ClientesEntity>();

            //Comprueba si las de por que campo ordenar y si asc o desc, estan o no nulas
            //en caso de q esten, las convierte en string vacio, para q no tire error despues, ya q no deben ser nulas

            string _sixid;
            if (sidx == null)
                _sixid = string.Empty;
            else
                _sixid = sidx[0];

            string _ord;
            if (sord == null)
                _ord = string.Empty;
            else
                _ord = sord[0];

            string test = "";
            //si existen campos de busqueda, dirige los datos a la getlist con busqueda, y sino a la normal.
            if (searchField == null)
                Entidades = _repository.GetList(_sixid, _ord);
            else
                if (searchField[0] == "")
                    Entidades = _repository.GetList(_sixid, _ord);
                else
                    Entidades = _repository.GetList(searchField[0], searchString[0], searchOper[0], caseSensitive: false, sixid: _sixid, ord: _ord);

            //ahora en entidades, tenemos la lista de elementos q nos trajo el repositorio


            //de aca en adelante, se acomodan los datos que van a ser devueltos a la vista:

            //Los parametros row y page (pasados por la vista) determinan cuantos items va a mostrar  la jqgrid y en q pagina
            //va a estar parada.

            //esto sirve para indicar el total de paginas q va a haber (que se muestra en el navgrid de la jqgrid
            int _count = Entidades.Count();
            
            int _resto = (_count % rows);
            decimal _total = _count / rows;
            if (_resto > 0)
                _total = (int)_total + 1;

            //esto calcula los elementos previos a la pagina deseada
            int rowsxpage = rows * page - rows;
            //para que esta linea, agarre la lista, salte los elementos, y tome los proximos x items, determinados por "rows"
            Entidades = Entidades.Skip(rowsxpage).Take(rows).ToList();

            /*ejemplo : Entidades.Skip(20).Take(10).ToList();
             salta los primeros 20 registros, y toma los 10 que siguen.. es decir..
             me muestra la tercer pagina de resultados, si las paginas son de 10 elementos cada una.
             * */

            Dictionary<string, object> _responseInt = new Dictionary<string, object>();
            Dictionary<string, object> _response;
            List<object> _response2 = new List<object>();
            List<string> cells;

            foreach (ClientesEntity p in Entidades) {
                _response = new Dictionary<string, object>();
                cells = new List<string>();
                _response.Add("id", p.ID);
                /*
                 Aca agregamos los campos que queremos mostrar en la tabla, no necesariamente
                 tienen q ser todos, ya que no necesito mostrar el id de documento o el id de localidad
                 y como vamos a usar un formulario de edicion propio en la jqgrid, 
                 no necesitamos tmpc llevarlos para despues usarlos ahi, ya que vamos a
                 hacer otra llamada al controlador para obtener los datos q mostramos ahi.
                 */
                cells.Add(p.ID.ToString());
                cells.Add(p.Nombre);
                cells.Add(p.Apellido);
                cells.Add(p.DocNombre);
                cells.Add(p.Documento);
                cells.Add(p.Direccion);
                cells.Add(p.LocNombre);
                cells.Add(p.Telefono);
                cells.Add(p.Celular);
                cells.Add(p.Email);

                _response.Add("cell", cells);
                _response2.Add(_response);
            }

            _responseInt.Add("rows", _response2);
            _responseInt.Add("records", _count);

            _responseInt.Add("total", System.Math.Ceiling(_total));
            _responseInt.Add("page", page);

            return Json(_responseInt, JsonRequestBehavior.AllowGet);
        }
    }
}