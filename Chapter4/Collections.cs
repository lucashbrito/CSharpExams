using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public class Collections : List<Person>
    {

        public void UsingArray()
        {
            int[][] arrayOfInt = { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 } };

            for (int x = 0; x < arrayOfInt.Length; x++)
            {
                arrayOfInt[x][x] = x;
                Console.Write(arrayOfInt[x][x]);
            }
        }

        public void UsingList()
        {
            List<string> listOfStrings = new List<string> { "A", "B", "C", "D", "E" };

            for (int x = 0; x < listOfStrings.Count; x++)
                Console.Write(listOfStrings[x]); // Displays: ABCDE

            listOfStrings.Remove("A");

            Console.WriteLine(listOfStrings[0]); // Displays: B

            listOfStrings.Add("F");

            Console.WriteLine(listOfStrings.Count); // Displays: 5

            bool hasC = listOfStrings.Contains("C");

            Console.WriteLine(hasC); // Displays: true
        }

        public void UsingDictionary()
        {
            Person p1 = new Person { Id = 1, Name = "Name1" };
            Person p2 = new Person { Id = 2, Name = "Name2" };
            Person p3 = new Person { Id = 3, Name = "Name3" };

            var dict = new Dictionary<int, Person>();

            dict.Add(p1.Id, p1);
            dict.Add(p2.Id, p2);
            dict.Add(p3.Id, p3);

            foreach (KeyValuePair<int, Person> v in dict)
            {
                Console.WriteLine("{ 0}: { 1}", v.Key, v.Value.Name);
            }

            dict[0] = new Person { Id = 4, Name = "Name4" };

            Person result;

            if (!dict.TryGetValue(5, out result))
            {
                Console.WriteLine("No person with a key of 5 can be found");
            }
        }

        public void UsingHashSet()
        {
            HashSet<int> oddSet = new HashSet<int>();
            HashSet<int> evenSet = new HashSet<int>();

            for (int x = 1; x <= 10000; x++)
            {
                if (x % 2 == 0)
                    evenSet.Add(x);
                else
                    oddSet.Add(x);
            }

            DisplaySet(oddSet);

            DisplaySet(evenSet);


            oddSet.UnionWith(evenSet);
            DisplaySet(oddSet);

        }

        public void UsingQueue()
        {
            Queue<string> myQueue = new Queue<string>();

            myQueue.Enqueue("Hello");
            myQueue.Enqueue("World");
            myQueue.Enqueue("From");
            myQueue.Enqueue("A");
            myQueue.Enqueue("Queue");
            foreach (string s in myQueue)
                Console.Write(s + " ");
            // Displays: Hello World From A Queue
        }

        public void UsingStack()
        {
            Stack<string> myStack = new Stack<string>();
            myStack.Push("Hello");
            myStack.Push("World");
            myStack.Push("From");
            myStack.Push("A");
            myStack.Push("Queue");
            foreach (string s in myStack)
                Console.Write(s + " ");
            // Displays: Queue A From World Hello
        }

        public void RemoveByAge(int age)
        {
            for (int index = this.Count - 1; index >= 0; index--)
            {
                if (this[index].Age == age)
                {
                    this.RemoveAt(index);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var person in this)
            {
                sb.AppendFormat($"{person.Name} is {person.Age}");
            }

            return sb.ToString();
        }

        private void DisplaySet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (int i in set)
            {
                Console.Write($" {i}");
            }
            Console.WriteLine(" }");
        }
    }
}
