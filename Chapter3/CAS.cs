using System;
using System.Security;
using System.Security.Permissions;

namespace Chapter3
{
    public class CAS
    {
        [FileIOPermission(SecurityAction.Demand, AllLocalFiles = FileIOPermissionAccess.Read)]
        public void DeclarativeCAS()
        {
            // Method body
        }

        public void UsingImperativeCAS()
        {
            FileIOPermission f = new FileIOPermission(PermissionState.None)
            {
                AllLocalFiles = FileIOPermissionAccess.Read
            };

            try
            {
                f.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
        }
    }
}
