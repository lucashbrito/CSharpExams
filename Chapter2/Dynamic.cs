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

    }
}
