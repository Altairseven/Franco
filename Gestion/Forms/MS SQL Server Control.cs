using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;
using Gestion.Classes;

namespace Gestion.Forms {
    public partial class MS_SQL_Server_Control : OwnForm {
        public MS_SQL_Server_Control() {
            InitializeComponent();
        }
        string[] Servicios = new String[4] { "MSSQL$ALTAIRSQL",
                                             "SQLTELEMETRY$ALTAIRSQL" ,
                                             "MSSQLLaunchpad$ALTAIRSQL",
                                             "ReportServer$ALTAIRSQL" };

        private Timer timer1;

        public void InitTimer() {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Init_List(1);
        }
        private void MS_SQL_Server_Control_Load(object sender, EventArgs e) {
            Init_List(1);
            InitTimer();
        }
        private void Init_List(int actionNumber) {
            if (actionNumber == 1)
                checkedListBox1.Items.Clear();
            List<Service_Control.ServiceInfo> list = new List<Service_Control.ServiceInfo>();
            for (int i = 0; i < Servicios.Length; i++) {
                Service_Control.ServiceInfo a = Service_Control.ServiceStatus(new Service_Control.ServiceInfo(Servicios[i]));
                Actions(actionNumber, i, a);
            }
        }
        private void Actions(int action,int indice, Service_Control.ServiceInfo a) {
            switch (action) {
                case 1: 
                        checkedListBox1.Items.Add(a.SDisplayName);
                        if (a.Status == "Running")
                            checkedListBox1.SetItemChecked(indice, true);
                        else
                            checkedListBox1.SetItemChecked(indice, false);
                    break;
                case 2: 
                        if (a.Status == "Stopped")
                            Service_Control.StartService(a.SName, 1000);
                    break;
                case 3: 
                        if (a.Status == "Running")
                            Service_Control.StopService(a.SName, 1000);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Init_List(2);
        }

        private void button2_Click(object sender, EventArgs e) {
            Init_List(3);
        }

        private void button3_Click(object sender, EventArgs e) {
            List<Service_Control.ServiceInfo> a = Service_Control.GetServices();
            foreach (Service_Control.ServiceInfo service in a) {
                listBox1.Items.Add(service.SDisplayName);
            }
        }
    }
        
    
}
