using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas_Programacion.Classes {
    public class FormData {

        public int CatId;
        public string FormName;
        public string FormTypeName;

        public FormData(int _catId, string _formName, string _formTypeName) {
            CatId = _catId;
            FormName = _formName;
            FormTypeName = _formTypeName;

        }
    }

    class Get_Forms {

        public List<Type> Formlist = new List<Type>();

        public Get_Forms() {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetEntryAssembly();
            Type[] Types = myAssembly.GetTypes();
            Formlist.Clear();
            foreach (Type myType in Types) {
                if (myType.BaseType == null)
                    continue;
                if (myType.BaseType.FullName == "System.Windows.Forms.Form")
                    Formlist.Add(myType);
            }
        }

        public Get_Forms(string target) {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetEntryAssembly();
            Type[] Types = myAssembly.GetTypes();
            Formlist.Clear();
            foreach (Type myType in Types) {
                if (myType.BaseType == null)
                    continue;
                if (myType.BaseType.FullName == target)
                    Formlist.Add(myType);
            }
        }

        public List<string> Exceptions() {
            List<string> exceptions = new List<string>();
            exceptions.Add("Ideas_Main");
            exceptions.Add("Numeros_Form");
            exceptions.Add("Textos_Form");
            exceptions.Add("Red_Form");
            exceptions.Add("EmpresaApp_Form");
            exceptions.Add("Hilos_Form");
            exceptions.Add("Web_Form");
            exceptions.Add("Database_Form");
            exceptions.Add("Media_Form");
            exceptions.Add("Juegos_Form");
            exceptions.Add("Files_Form");
            return exceptions;
        }

        public bool Exceptions_check(Type formToCheck) {
            foreach (string name in Exceptions()) {
                if (formToCheck.Name == name)
                    return true;
            }
            return false;
        }
    }
}
