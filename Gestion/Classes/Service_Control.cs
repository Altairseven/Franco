using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Diagnostics;

namespace Gestion.Classes {
    class Service_Control {

        public class ServiceInfo {
            public string SName { get; set; }
            public string SDisplayName { get; set; }
            public string Status { get; set; }
            public Exception ex { get; set; }

            public ServiceInfo(string _name) {
                SName = _name;
            }
        }

        public static List<ServiceInfo> GetServices() {
            List<ServiceInfo> List = new List<ServiceInfo>();
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services) {
                ServiceInfo a = new ServiceInfo(service.ServiceName);
                a.SDisplayName = service.DisplayName;
                List.Add(a);
            }
            return List;
        }

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
                    a.ex = e;
                    throw;
                }
            
            return a;
        }

        public static ServiceInfo StartService(string serviceName, int timeoutMilliseconds) {
            ServiceController service = new ServiceController(serviceName);
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
            ServiceInfo p = ServiceStatus(new ServiceInfo(serviceName));
            if (ex != null)
                p.ex = ex;
            return p;
        }
        public static void StopService(string serviceName, int timeoutMilliseconds) {
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


            }
            catch (Exception e) {
                Trace.WriteLine(e.Message);
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
                Trace.WriteLine(e.Message);
            }
        }


    }
}
