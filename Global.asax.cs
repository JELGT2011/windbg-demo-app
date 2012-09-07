using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Windows.Forms;

namespace WinDbgDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Log(Server.GetLastError());
        }

        private void Log(Exception ex)
        {
            // Several layers of function calls here..
            var logFile = ConfigurationManager.AppSettings.Get("logFile");
            // Several more layers here..
            Debug.Assert(logFile != null);
            // And there was one more here..
            using (var log = new StreamWriter(logFile, true))
                log.WriteLine("{0} [{1}]: Exception ({2}): {3}\nStack:\n{4}{5}",
                    DateTime.Now,
                    Process.GetCurrentProcess().Id,
                    ex.GetType(),
                    ex.Message,
                    ex.StackTrace,
                    ex.InnerException == null ? "" : string.Format("\nInner ({0}): {1}\nInner stack:\n{2}",
                        ex.InnerException.GetType(),
                        ex.InnerException.Message,
                        ex.InnerException.StackTrace));
        }
    }
}