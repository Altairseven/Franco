using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;

namespace ServiceControl.Classes {
    class Service_Control {

    /*    public class ServiceInfo {
            public string SName { get; set; }
            public string SDisplayName { get; set; }
            public string Status { get; set; }
            public Exception Ex { get; set; }

            public ServiceInfo(string _name) {
                SName = _name;
            }
        }*/
        
        public static List<ServiceController> GetServices(string SortBy) {
            List<ServiceController> services = ServiceController.GetServices().ToList<ServiceController>();
            ServiceListSorting(SortBy,services);
            return services.ToList<ServiceController>();
        }

        public static List<ServiceController> ServiceListSorting(string SortBy, List<ServiceController> S) {
            ServiceController[] services = S.ToArray();
            ServiceController Temp; int shortestStringIndex;
            //Sort using Selection Sort
            for (int j = 0; j < services.Length - 1; j++) {
                shortestStringIndex = j;
                for (int i = j + 1; i < services.Length; i++) {
                    if (SortBy == "ServiceName") {
                        if (services[i].ServiceName.CompareTo(services[shortestStringIndex].ServiceName) < 0)
                            shortestStringIndex = i;
                    }
                    else if (SortBy == "DisplayName") {
                        if (services[i].DisplayName.CompareTo(services[shortestStringIndex].DisplayName) < 0)
                            shortestStringIndex = i;
                    }

                }
                //We only swap with the smallest string
                if (shortestStringIndex != j) {
                    Temp = services[j];
                    services[j] = services[shortestStringIndex];
                    services[shortestStringIndex] = Temp;
                }
            }
            return services.ToList<ServiceController>();
        }

        public static ServiceControllerStatus ServiceStatus(string _serviceName) {
                ServiceController a = new ServiceController(_serviceName);
                return a.Status;
        }



        /*
                public static ServiceInfo ServiceStatus(ServiceInfo a) {
                        try {
                            ServiceController service = new ServiceController(a.SName);
                            a.SDisplayName = service.DisplayName;
                            if (service.Status == ServiceControllerStatus.Running)
                                a.Status = "Running";
                            else if (service.Status == ServiceControllerStatus.Stopped)
                                a.Status = "Stopped";
                            else
                                a.Status = null;
                        }
                        catch (Exception e) {
                            a.Ex = e;
                            throw;
                        }

                    return a;
                }
                */
        public static void StartService(ServiceController service, int timeoutMilliseconds) {
            Exception ex = null;
            try {
                int millisec1 = 0;
                TimeSpan timeout;
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec1));
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch (Exception e) {
                ex = e;
                //Trace.WriteLine(e.Message);
            }
            //ServiceInfo p = ServiceStatus(new ServiceInfo(serviceName));
            //if (ex != null)
            //    p.Ex = ex;
            //return p;
        }
        public static void StopService(ServiceController service, int timeoutMilliseconds) {
            try {
                int millisec1 = 0;
                TimeSpan timeout;
                if (service.Status == ServiceControllerStatus.Running) {
                    millisec1 = Environment.TickCount;
                    timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }


            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
        public static void RestartService(string serviceName, int timeoutMilliseconds) {
            ServiceController service = new ServiceController(serviceName);
            try {
                int millisec1 = 0;
                TimeSpan timeout;
                if (service.Status == ServiceControllerStatus.Running) {
                    millisec1 = Environment.TickCount;
                    timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);

            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }


    }
}
