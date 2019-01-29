using System.Dynamic;

namespace Chapter2
{
    public class Dynamic : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }

        public void UsingExpandoObject()
        {

            //A program can add ExpandoObject properties to an ExpandoObject to
            //create nested data structures. An ExpandoObject can also be queried using
            //LINQ and can exposes the IDictionary interface to allow its contents to be
            //queried and items to be removed.ExpandoObject is especially useful when
            //    creating data structures from markup languages, for example when reading a
            //JSON or XML document.
            dynamic person = new ExpandoObject();

            person.Name = "Lucas Brito";
            person.Age = 26;

        }

    }
}
