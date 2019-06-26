using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aspnet.UI.Controllers
{
    public class TraceController : Controller
    {
        // GET: Trace
        public ActionResult Index()
        {
            var test= "test"
            
            Trace.WriteLine("Message");

            Trace.WriteLine("Write line");

            Trace.WriteIf(string.IsNullOrEmpty(test), "There isn't value here");

            Trace.WriteLineIf(string.IsNullOrEmpty(test), "There isn't value here, write line");

            return null;
        }

        protected override void OnException(ExceptionContext exceptionContext)
        {
            if (exceptionContext.IsChildAction)
            {
                //we don't want to display the error screen if it is a child action,
                base.OnException(exceptionContext);
                return;
            }
            // log the exception in your configured logger
           // Logger.Log(exceptionContext.Exception);
            //handle when the app is not configured to use the custom error path
            if (!exceptionContext.HttpContext.IsCustomErrorEnabled)
            {
                exceptionContext.ExceptionHandled = true;
                this.View("ErrorManager").ExecuteResult(this.ControllerContext);
            }
        }
    }
}