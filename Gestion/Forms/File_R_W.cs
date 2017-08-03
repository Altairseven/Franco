using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Gestion.Forms {
    public partial class File_R_W : OwnForm {
        public File_R_W() {
            InitializeComponent();
        }

        private void readFromEmbeded() {
            Assembly _assembly;
            StreamReader _textStreamReader;

            try {
                List<string> Lista = new List<string>();
                _assembly = Assembly.GetExecutingAssembly();
                _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("Gestion.Data.Services.list"));
                string line;
                while ((line = _textStreamReader.ReadLine()) != null) {
                    Lista.Add(line);
                }
                listBox1.DataSource = Lista;
            }
            catch {
                MessageBox.Show("Error accessing resources!");
            }

        }
        private bool ReadFromFile() {
            StreamReader Reader;
            List<string> Lista = new List<string>();
            try {
                Reader = new StreamReader("./Services.cfg");
                string line;
                while ((line = Reader.ReadLine()) != null) {
                    Lista.Add(line);
                }
                listBox1.DataSource = Lista;
                return true;
            }
            catch (Exception) {
                return false;
            }

        }
        public void LoadConfig() {
            bool success = ReadFromFile();
            if (!success) {
                MessageBox.Show("Ajustes Predeterminados Cargados");
                EmbededToFile("Gestion.Data.Services.list", "Services.cfg");
                LoadConfig();
            }

        }
        public void EmbededToFile(string resourceName, string fileName) {
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)) {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write)) {
                    resource.CopyTo(file);
                }
            }
        }

        private void File_R_W_Load(object sender, EventArgs e) {
            LoadConfig();
        }

        private void button1_Click(object sender, EventArgs e) {
            EmbededToFile("Gestion.Data.Services.list", "Services.cfg");
        }
    }
}
