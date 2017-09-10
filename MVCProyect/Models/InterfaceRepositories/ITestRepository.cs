using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCProyect.Models.Entities;


namespace MVCProyect.Models.InterfaceRepositories {
    interface ITestRepository {

        IEnumerable<ClientesEntity> GetList(string sixid, string ord);
        IEnumerable<ClientesEntity> GetList(string searchField, string searchValue, string searchOper,
                                                bool caseSensitive, string sixid = "Nombre", string ord = "ASC");
        


    }
}
