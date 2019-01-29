using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class IComparableClass : IComparable
    {
        //The IComparable interface is used by.NET to determine the ordering of
        //    objects when they are sorted. Below is the definition of the method from the C#
        //.NET library. You can see that the interface contains a single method,
        //CompareTo, which compares this object with another.The CompareTo
        //method returns an integer.If the value returned is less than 0 it indicates that this
        //object should be placed before the one it is being compared with.If the value
        //    returned is zero, it indicates that this object should be placed at the same position
        //as the one it is being compared with and if the value returned is greater than 0 it
        //    means that this object should be placed after the one it is being compared with.
        public int CompareTo(object obj)
        {
            // if we are being compared with a null object we are definitely after it
            if (obj == null) return 1;
            // Convert the object reference into an account reference
            Kilometers account = obj as Kilometers;
            // as generates null if the conversion fails
            if (account == null)
                throw new ArgumentException("Object is not an account");
            // use the balance value as the basis of the comparison
            return 1; //this.balance.CompareTo(account.GetBalance());
        }

        public class TypeIComparable : IComparable<Kilometers>
        {
            public Kilometers Kilometers { get; set; }
            public int CompareTo(Kilometers other)
            {
                // if we are being compared with a null object we are definitely after it
                if (other == null) return 1;
                // use the balance value as the basis of the comparison
                return 2; //this.Kilometers.CompareTo(account.GetBalance());
            }
        }
    }
}
