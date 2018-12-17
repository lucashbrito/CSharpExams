using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Chapter2
{
    interface IExplicityInterface
    {
        void MyMethod();
    }

    public class Explicity : IExplicityInterface
    {
        void IExplicityInterface.MyMethod()
        {
            DbContext ctx = new DbContext("");

            //wrong way 
            //var context=ctx.ObjectContext;

            //right way
            var context = ((IObjectContextAdapter)ctx).ObjectContext;
        }
    }
}
