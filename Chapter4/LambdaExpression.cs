using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chapter4
{
    public class LambdaExpression
    {
        string xml = @"<? xml version =""1.0"" encoding =""utf - 8"" ?>
                < people >
                < person firstname =""john"" lastname =""doe"">
                < contactdetails >
                < emailaddress > john@unknown.com </ emailaddress >
                </ contactdetails >
                </ person >
                < person firstname =""jane"" lastname =""doe"">
                < contactdetails >
                < emailaddress > jane@unknown.com </ emailaddress >
                < phonenumber > 001122334455 </ phonenumber >
                </ contactdetails >
                </ person >
                </ people >";
        public void UsingAnonymous()
        {
            Func<int, int> myDelegate = delegate (int x) { return x * 3; };

            Console.WriteLine(myDelegate(23));

            Func<int, int> myDelegateLambda = x => x * 3;

            Console.WriteLine(myDelegateLambda(43));

            int y = 23;

            Console.WriteLine(y.Multiply(23));
        }

        public void CreateAnonymousType()
        {
            var person = new { FirstName = "Lucas ", LastName = "Brito" };

            Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.GetType().Name);
        }

        public void UsingLinqQueries()
        {
            int[] data = { 1, 2, 3, 4, 5, 6, 234, 45, 4, 3, 345, 23, 2, 123, 123, };
            int[] data2 = { 1, 2, 3, 4, 5, 6, 234, 45, 4, 3, 345, 23, 2, 123, 123, };


            var result = from d in data where d % 2 == 0 select d;

            foreach (var i in result)
            {
                Console.WriteLine(i);
            }

            var resultLambda = data.Where(d => d % 2 == 0);

            foreach (var i in resultLambda)
            {
                Console.WriteLine(i);
            }

            var result3 = from d in data
                          where d > 5
                          select d;
            Console.WriteLine(string.Join(",", ",", result));

            var result4 = from d1 in data
                          from d2 in data2
                          select d1 * d2;

            Console.WriteLine(string.Join(",", result4));
        }

        public void QueryLinqXml()
        {
            XDocument doc = XDocument.Parse(xml);
            IEnumerable<string> personNames = from p in doc.Descendants("Person")
                                              select (string)p.Attribute("firstName") + " " + (string)p.Attribute("lastName");

            foreach (var personName in personNames)
            {
                Console.WriteLine(personName);
            }

            IEnumerable<string> personNamesOrderBy = from p in doc.Descendants("Person ")
                                                     where p.Descendants("PhoneNumber").Any()
                                                     let name = (string)p.Attribute("firstName") + " " + (string)p.Attribute("lastName")
                                                     orderby name
                                                     select name;

            foreach (var personName in personNamesOrderBy)
            {
                Console.WriteLine(personName);
            }

        }

        public void CreateXmlXElement()
        {
            XElement root = new XElement("Root",
            new List<XElement>
            {
                new XElement("Child1"),
                new XElement("Child2"),
                new XElement("Child3")
            },
            new XAttribute("MyAttribute", 42));
            root.Save("test.xml");
        }

        public void UpdateXmlElement()
        {
            XElement root = XElement.Parse(xml);
            foreach (XElement p in root.Descendants("Person"))
            {
                string name = (string)p.Attribute("firstName") + (string)p.Attribute("lastName");
                p.Add(new XAttribute("IsMale", name.Contains("John")));
                XElement contactDetails = p.Element("ContactDetails");
                if (!contactDetails.Descendants("PhoneNumber").Any())
                {
                    contactDetails.Add(new XElement("PhoneNumber", "001122334455"));
                }
            }
        }

        public void UpdateXmlProceduralWay()
        {
            XElement root = XElement.Parse(xml);

            XElement newTree = new XElement("People",
            from p in root.Descendants("Person")
            let name = (string)p.Attribute("firstName") + (string)p.Attribute("lastName")
            let contactDetails = p.Element("ContactDetails")
            select new XElement("Person",
            new XAttribute("IsMale", name.Contains("John")),
            p.Attributes(),
            new XElement("ContactDetails",
            contactDetails.Element("EmailAddress"),
            contactDetails.Element("PhoneNumber")
                ?? new XElement("PhoneNumber", "112233455")
                )));
        }
    }

    //The magical keyword in this code listing is the yield return statement. Because the yield
    //statement is an implementation of the iterator pattern, the code is not executed until the first
    //call to MoveNext is made.This is called deferred execution.A LINQ query is not executed until
    //it is iterated, until that moment the query does nothing.A lot of errors when working with
    //LINQ queries happen because people forget when their query is executed.
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
    public static class IntExtensions
    {
        public static int Multiply(this int x, int y)
        {
            return x * y;
        }
    }
}
