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
    public class Tipos_DocumentoController : Controller
    {
        //En este caso no hice una interfaz..
        Tipos_DocumentoRepository _repository = new Tipos_DocumentoRepository();

        public JsonResult GetList() {
            List<Tipos_DocumentoEntity> _list = _repository.GetList();
            return Json(_list, JsonRequestBehavior.AllowGet); 
        }




    }
}