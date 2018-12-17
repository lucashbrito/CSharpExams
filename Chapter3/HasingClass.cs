using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    public class HasingClass1
    {
        public void UsingSHA256()
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();

            SHA256 sha256 = SHA256.Create();

            string data = "A paragraph of text";

            byte[] hashA = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of changed text";

            byte[] hashB = sha256.ComputeHash(byteConverter.GetBytes(data));

            data = "A paragraph of text";

            byte[] hashC = sha256.ComputeHash(byteConverter.GetBytes(data));

            Console.WriteLine(hashA.SequenceEqual(hashB)); // Displays: false
            Console.WriteLine(hashA.SequenceEqual(hashC)); // Displays: true
        }
    }
    public class HasingClass<T>
    {
        private List<T> list = new List<T>();

        public void Insert(T item)
        {
            if (!Contains(item))
                list.Add(item);
        }

        public bool Contains(T item)
        {
            foreach (T member in list)
                if (member.Equals(item))
                    return true;
            return false;
        }
    }

    public class Set<T>
    {
        private List<T>[] buckets = new List<T>[100];

        public void Insert(T item)
        {
            int bucket = GetBucket(item.GetHashCode());
            if (Contains(item, bucket))
                return;
            if (buckets[bucket] == null)
                buckets[bucket] = new List<T>();
            buckets[bucket].Add(item);
        }

        public bool Contains(T item)
        {
            return Contains(item, GetBucket(item.GetHashCode()));
        }

        private int GetBucket(int hashcode)
        {
            // A Hash code can be negative. To make sure that you end up with a positive
            // value cast the value to an unsigned int. The unchecked block makes sure that
            // you can cast a value larger then int to an int safely.
            unchecked
            {
                return (int)((uint)hashcode % (uint)buckets.Length);
            }
        }

        private bool Contains(T item, int bucket)
        {
            if (buckets[bucket] != null)
                foreach (T member in buckets[bucket])
                    if (member.Equals(item))
                        return true;
            return false;
        }
    }
}

