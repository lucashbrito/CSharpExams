using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Xml.Serialization;

namespace Chapter4
{
    class SerializerAndDeserializer
    {
        public void UsingSerializeWithXmlSerializer()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(People));
            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                People p = new People
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 42
                };
                serializer.Serialize(stringWriter, p);
                xml = stringWriter.ToString();
            }
            Console.WriteLine(xml);
            using (StringReader stringReader = new StringReader(xml))
            {
                People p = (People)serializer.Deserialize(stringReader);
                Console.WriteLine("{ 0} { 1} is { 2} years old", p.FirstName, p.LastName, p.Age);
            }
        }

        public void UsingSerializeADerivedClassToXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Order), new Type[] { typeof(VIPOrder) });
            string xml;

            using (StringWriter stringWriter = new StringWriter())
            {
                Order order = CreateOrder();
                serializer.Serialize(stringWriter, order);
                xml = stringWriter.ToString();
            }

            using (StringReader stringReader = new StringReader(xml))
            {
                Order o = (Order)serializer.Deserialize(stringReader);
                Console.WriteLine(o);
            }
        }

        public void UsingBinarySerialization()
        {
            var p = new People()
            {
                Age = 1,
                FirstName = "John Doe"
            };
            IFormatter formatter = new BinaryFormatter();

            using (Stream stream = new FileStream("data.bin", FileMode.Create))
            {
                formatter.Serialize(stream, p);
            }
            using (Stream stream = new FileStream("data.bin", FileMode.Open))
            {
                Person dp = (Person)formatter.Deserialize(stream);
            }
        }

        private static Order CreateOrder()
        {
            Product p1 = new Product { ID = 1, Description = "p2", Price = 9 };
            Product p2 = new Product { ID = 2, Description = "p3", Price = 6 };
            Order order = new VIPOrder
            {
                ID = 4,
                Description = "Order for John Doe. Use the nice giftwrap",
                OrderLines = new List<OrderLine>
                {
                    new OrderLine { ID = 5, Amount = 1, Product = p1},
                    new OrderLine { ID = 6 ,Amount = 10, Product = p2},
                }
            };
            return order;
        }

    }

    public class PersonComplex : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool isDirty = false;

        public PersonComplex() { }

        protected PersonComplex(SerializationInfo info, StreamingContext context)
        {
            Id = info.GetInt32("Value1");
            Name = info.GetString("Value2");
            isDirty = info.GetBoolean("Value3");
        }

        [SecurityPermission(SecurityAction.Demand,SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value1", Id);
            info.AddValue("Value2", Name);
            info.AddValue("Value3", isDirty);
        }
    }
}
