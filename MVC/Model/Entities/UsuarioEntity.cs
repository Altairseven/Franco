using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Model;

namespace MVC.Model.Entities {
    public class UsuarioEntity {

        public decimal ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string SALT { get; set; }
        public string USERFULLNAME { get; set; }
        public string EMAIL { get; set; }
        public DateTime? LASTLOGIN { get; set; }
        public string ACCOUNTTYPE { get; set; }

        public UsuarioEntity() {

        }

        public UsuarioEntity(users a) {
            ID = a.ID;
            USERNAME = a.
            PASSWORD = a.PASSWORD;
            SALT = a.SALT;
            USERFULLNAME = a.USERFULLNAME;
            EMAIL = a.EMAIL;
            LASTLOGIN = a.LASTLOGIN;
            ACCOUNTTYPE = a.ACCOUNTTYPE;
        }

    }
}