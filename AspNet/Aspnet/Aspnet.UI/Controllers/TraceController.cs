using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Web.Mvc;

namespace Aspnet.UI.Controllers
{
    public class TraceController : Controller
    {
        public int Id { get; set; }
        // GET: Trace
        public ActionResult Index()
        {
            var test = "test";
            
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

        internal void GetArticle(int id)
        {
            System.Diagnostics.Contracts.Contract.Requires(id > 0);
            //In this case, debug mode provides more information about the thrown exception than does the ArgumentException from
        }

        [ContractInvariantMethod]
        protected void ManageInvariant()
        {
            System.Diagnostics.Contracts.Contract.Invariant(this.Id < 0);
            //An invariant check ensures that a class does not get to an invalid state. To use invariant
            //checks on a class, you must create a method to manage the check.This method can be
            //called anything you want; the contracts subsystem will know what it is for because it has been
            //decorated with the ContractInvariantMethod attribute.In the method, you need to call the
            //    rules you are concerned about.The only time the application can violate these rules is when it
            //is doing work in private methods.
        }

    
        internal void PostCondition(int id)
        {
            //A postcondition checks that the value out of a method meets expected criteria—it validates
            //the outcome of a method.Consider the example used for the precondition check.You
            //can add a postcondition to it by using the Ensures static method.In this case, the contract
            //guarantees there will not be a null Article returned from the method:
            System.Diagnostics.Contracts.Contract.Requires(id > 0);
           // System.Diagnostics.Contracts.Contract.Ensures(Contract.Requires<int>(this.Id!=null));
            // some work here
        }

}
}