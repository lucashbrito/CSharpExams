using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Chapter2
{
    public class StringClass
    {

        public void UsingString()
        {
            string str = string.Empty;

            for (int i = 0; i < 10000; i++)
            {
                str += "X";
            }
        }

        public void UsingStringBuilder()
        {
            var sb = new StringBuilder("A initial value");
            sb[0] = 'B';

            for (int i = 0; i < 100000; i++)
            {
                sb.Append("X");
            }
        }

        public void UsingStringWriter()
        {
            var stringWriter = new StringWriter();
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
            {
                xmlWriter.WriteStartElement("book");
                xmlWriter.WriteElementString("price", "19.95");
                xmlWriter.WriteEndElement();
                xmlWriter.Flush();
            }

            var xml = stringWriter.ToString();

            UsingStringReader(xml);
        }

        public void UsingStringReader(string xml)
        {
            var stringReader = new StringReader(xml);

            using (var reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = decimal.Parse(reader.ReadInnerXml(), new CultureInfo("en-US"));
            }
        }

        public void UsingIndexOf()
        {
            string value = "My sample value";
            int indexOf = value.IndexOf('p');
            int lastindexOf = value.LastIndexOf('m');
        }

        public void UsingStartWithAndEndsWith()
        {
            string value = "<mycustominput>";
            if (value.StartsWith("<") || value.EndsWith(">"))
            {

            }
        }

        public void UsingSubStrings()
        {
            string value = "My sample value";
            int indexOf = value.IndexOf('p');
            int lastindexOf = value.LastIndexOf('m');
            string result = value.Substring(indexOf, lastindexOf);
        }

        public void UsingRegularExpression()
        {
            string pattern = "(Mr\\.? | Mrs\\.? | Miss | Ms\\.? )";
            string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", "Abraham Adams", "Ms. Nicole Norris" };

            foreach (var name in names)
            {
                Console.WriteLine(Regex.Replace(name, pattern, string.Empty));
            }
        }

        public void UsingDisplayANumber()
        {
            double cost = 100023.45;
            Console.WriteLine(cost.ToString("C", new CultureInfo("en-US")));
        }
    }
}
