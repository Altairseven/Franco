using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceControl;

namespace ServiceControl.Classes {

    public class ConfigfileStatus {
        public List<string> List = new List<string>();
        public Exception Ex;

        public ConfigfileStatus(List<string> _list, Exception _ex) {
            if (_list != null) List = _list;
            if (_ex != null) Ex = _ex;
        }

    }

     public class List_Control {

        public static string DefaultsPath = "ServiceControl.Selected.list";
        public static string SelectedServicesPath = "./Selected.list";

        public static List<ServiceController> GetSelected(int exCode) {
            List<ServiceController> listAll = Service_Control.GetServices("ServiceName");
            ConfigfileStatus F = List_Control.ReadFromFile(List_Control.SelectedServicesPath);
            if (F.Ex == null) {
                List<string> Selected = new List<string>();
                return GetSelected(listAll, F.List, Selected, exCode);
            }
            else return null;
        }

        public static List<ServiceController> GetSelected(List<ServiceController> listAll, List<string> fromFile, List<string> Selected,int exCode) {
            List<ServiceController> _listSelected = new List<ServiceController>();
            List<string> _strings = new List<string>();
            foreach (string a in fromFile)
                _strings.Add(a);
            foreach (string b in Selected)
                _strings.Add(b);
            foreach (string c in _strings) {

                int Iresult = List_Control.SearchInList(c, listAll);
                if (Iresult == -1)
                    exCode = 404;
                else
                    MoveSingleService(Iresult, listAll, _listSelected);
            }
            return _listSelected;
        }

        public static void ApplyFormat(DataGridView dtgv) {
            for (int i = dtgv.Columns.Count - 1; i > -1; i--)
                if (dtgv.Columns[i].Name != "DisplayName" && dtgv.Columns[i].Name != "Status")
                    dtgv.Columns[i].Visible = false;
            dtgv.Columns["Status"].DisplayIndex = 0;
            dtgv.Columns["Status"].Width = 60;
            dtgv.Columns["DisplayName"].DisplayIndex = 1;
            dtgv.Columns["DisplayName"].Width = 220;
            foreach (DataGridViewRow row in dtgv.Rows) {
                if (row.Cells["Status"].Value.ToString() == "Running")
                    row.Cells["Status"].Style.BackColor = System.Drawing.Color.LightGreen;
                if (row.Cells["Status"].Value.ToString() == "Stopped")
                    row.Cells["Status"].Style.BackColor = System.Drawing.Color.LightSalmon;
            }

        }

        public static void MoveSingleService(int i, List<ServiceController> L_From, List<ServiceController> L_To) {
            ServiceController a = L_From[i];
            L_To.Add(a);
            L_From.Remove(a);
        }

        public static void AddMultipleToSelected(DataGridView dtgv,List<string> list) {
            foreach (DataGridViewRow row in dtgv.SelectedRows) {
                string _name = row.Cells["ServiceName"].Value.ToString();
                list.Add(_name);
            }
        }

        public static void RemoveMultipleFromSelected(DataGridView dtgv, List<string> list1, List<string> list2) {
            List<string> toremove = new List<string>();
            foreach (DataGridViewRow row in dtgv.SelectedRows) {
                for (int i = list1.Count - 1; i >= 0; i--)
                    if (row.Cells["ServiceName"].Value.ToString() == list1[i])
                        list1.RemoveAt(i);
                for (int i = list2.Count - 1; i >= 0; i--)
                    if (row.Cells["ServiceName"].Value.ToString() == list2[i])
                        list2.RemoveAt(i);
            }
            
        }

        public static int SearchInList(string SearchValue, List<ServiceController> list) {
            //Binary Search of strings in a sorted array.

            ServiceController[] a = list.ToArray();

            int[] sbounds = new int[2] { 0, a.Length - 1 }; //Stores the bounds of the search.
            int middle; //for storing midpoint of searchbounds
            string val; //for storing the value of midpoint 

            int resultindex = -1; //for storing the index of the result
            bool found = false; //inficates if the search has finished.

            while (found == false && sbounds[0] <= sbounds[1]) {
                middle = (sbounds[0] + sbounds[1]) / 2;
                val = a[middle].ServiceName;
                if (val == SearchValue) {
                    resultindex = middle;
                    found = true;
                }
                else if (val.CompareTo(SearchValue) > 0)
                    sbounds[1] = middle - 1;
                else
                    sbounds[0] = middle + 1;
                if (found == false) {

                }
            }
            return resultindex;
        }

        public static ConfigfileStatus ReadFromFile(string Path) {
            StreamReader Reader;
            List<string> Lista = new List<string>();
            try {
                Reader = new StreamReader(Path);
                string line;
                while ((line = Reader.ReadLine()) != null) {
                    if (!line.StartsWith("#") && line != "")
                        Lista.Add(line);
                }
                Reader.Close();
                return new ConfigfileStatus(Lista,null);
            }

            catch (Exception Ex) {
                return new ConfigfileStatus(null, Ex);
            }
        }

        public static bool WriteConfigToFile(List<ServiceController> list) {

            string toWrite = "#Esta lista contiene los Nombres de los servicios que se@" +
                             "#agregaran automaticamente a la lista de seleccionados.";
            if (list != null) {
                foreach (ServiceController a in list) {
                    toWrite = toWrite + "@#" + a.DisplayName + ":";
                    toWrite = toWrite + "@" + a.ServiceName;
                    
                }
            }
            toWrite = toWrite.Replace("@", "" + Environment.NewLine);
            try {
                using (StreamWriter outputFile = new StreamWriter("./Selected.list")) {
                    outputFile.Write(toWrite);
                }
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void EmbededToFile(string resourceName, string fileName) {
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)) {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                    resource.CopyTo(file);
                }
            }
        }
    }
}
