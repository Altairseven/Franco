using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion.Classes
{ 
    public class Tools
    {
        public string replicate(string car, int cant)
        {
            string ret = "";
            for (int i = 1; i <= cant; i++)
            {
                ret += car; // ret = ret + car
            }
            return ret;
        }
    }
}
