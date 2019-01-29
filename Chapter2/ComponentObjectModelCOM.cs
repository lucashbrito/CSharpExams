using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    public class ComponentObjectModelCOM
    {
        //The Component Object Model(COM) is a mechanism that allows software
        //    components to interact.The model describes how to express an interface to
        //which other objects can connect.COM is interesting to programmers because a
        //    great many resources you would like to use are exposed via COM interfaces.
        //    The code inside a COM object runs as unmanaged code, having direct access
        //to the underlying system.While it is possible to run.NET applications in an
        //    unmanaged mode, .NET applications usually run inside a managed environment,
        //    limiting the level of access that the applications have to the underlying system.
        //    When a .NET application wants to interact with a COM object it has to
        //perform the following:
        //1. Convert any parameters for the COM object into an appropriate format
        //2. Switch to unmanaged execution for the COM behavior
        //3. Invoke the COM behavior
        //4. Switch back to managed execution upon completion of the COM behavior
        //5. Convert any results of the COM request into the correct types of .NET
        //objects

        //This is performed by a component called the Primary Interop Assembly(PIA)
        //that is supplied along with the COM object. The results returned by the PIA can
        //    be managed as dynamic objects, so that the type of the values can be inferred
        //    rather than having to be specified directly.As long as your program uses the
        //returned values in the correct way, the program will work correctly.You add a
        //    Primary Interop Assembly to an application as you would any other assembly.


        //Embedding Type Information from assemblies
        //    You can create applications that interact with different versions of Microsoft
        //Office by embedding the Primary Interop Assembly in the application.This is
        //achieved by setting the Embed Interop Types option of the assembly reference to
        //    True. This removes the need for any interop assemblies on the machine running
        //    the application.

    }
}
