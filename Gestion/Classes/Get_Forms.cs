using System;
using System.Collections.Generic;

//using System.Reflection; //Descomentar esto me permitira abreviar en la linea 11 y 22, Poniendo solamemente
//Assembly, en vez de System.Reflection.Assembly

namespace Gestion {
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

    public class Get_Forms {
        
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

        public virtual List<string> Exceptions() {
            List<string> exceptions = new List<string>();
                exceptions.Add("MainForm");
                exceptions.Add("EnClasesForm");
                exceptions.Add("OwnForm");
                exceptions.Add("MainForm");

            //Formularios que son hijos de otros formualarios, 
            //y por ende no deberian aparecer en el main form:
                
                exceptions.Add("ABM_Ficha_Busqueda_Cliente");


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

    public class Get_Forms_ByNameSpace {

        System.Reflection.Assembly myAssembly;
        Type[] Types;

        public List<List<Type>> FormLists = new List<List<Type>>();

        public Get_Forms_ByNameSpace() {
            myAssembly = System.Reflection.Assembly.GetEntryAssembly();
            Types = myAssembly.GetTypes();
        }

        public void AddFormList(string target) {
            List<Type> FormLst = new List<Type>();
            foreach (Type myType in Types) {
                if (myType.FullName.StartsWith(target + "."))
                    foreach (string AT in AllowedTypes())
                        if (myType.BaseType.FullName == AT)
                            FormLst.Add(myType);

            }
            FormLists.Add(FormLst);
        }

        public void AddUncategorizedFormList() {
            List<Type> FormLst = new List<Type>();
            foreach (Type myType in Types) {
                if (myType.BaseType == null)
                    continue;
                else 
                    foreach (string AT in AllowedTypes())
                        if (myType.BaseType.FullName == AT)
                            FormLst.Add(myType);
            }
            foreach (List<Type> FormCatList in FormLists)
                foreach(Type form in FormCatList)
                    for (int i = 0; i < FormLst.Count; i++) {
                        if (FormLst[i] == form)
                            FormLst.Remove(FormLst[i]);
                    }
            FormLists.Add(FormLst);



        }
        //public List<Type> Formlist = new List<Type>();

        //public Get_Forms_ByNameSpace(string target) {
        //    System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetEntryAssembly();
        //    Type[] Types = myAssembly.GetTypes();
        //    Formlist.Clear();
        //    foreach (Type myType in Types) {
        //        if (myType.FullName.StartsWith(target + "."))
        //            foreach (string AT in AllowedTypes())
        //                if (myType.BaseType.FullName == AT)
        //                    Formlist.Add(myType);

        //    }
        //}
        public virtual List<string> AllowedTypes() {
            List<string> allowed = new List<string>();
            allowed.Add("Gestion.Forms.EnClasesForm");
            allowed.Add("Gestion.Forms.OwnForm");
            allowed.Add("System.Windows.Forms.Form");
            allowed.Add("System.Windows.Forms");

            return allowed;
        }

        public virtual List<string> Exceptions() {
            List<string> exceptions = new List<string>();
            exceptions.Add("MainForm");
            exceptions.Add("EnClasesForm");
            exceptions.Add("OwnForm");
            exceptions.Add("MainForm");

            //Formularios que son hijos de otros formualarios, 
            //y por ende no deberian aparecer en el main form:

            exceptions.Add("ABM_Ficha_Busqueda_Cliente");


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
