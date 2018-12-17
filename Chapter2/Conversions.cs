using System;
using System.IO;
using System.Net.Http;

namespace Chapter2
{
    public class Conversions
    {
        public void ImplicitConversion()
        {
            int i = 43;
            double d = i;

            Console.WriteLine($"int i ={i}; double d={d}");

            HttpClient client = new HttpClient();
            object obj = client;
            IDisposable idDisposable = client;

            Money money = new Money(43.43M);

            Console.WriteLine($"money= {money}");

            decimal amount = money;
            Console.WriteLine($"money decimal/money= {amount}/{money}");

            int truncanteAmount = (int)money;
            Console.WriteLine($"money decimal/money= {truncanteAmount}/{money}");
        }

        public void ExplicitConversion()
        {
            double d = 123.23;
            int i;
            i = (int)d;

            Object stream = new MemoryStream();
            MemoryStream meoMemoryStream = (MemoryStream)stream;

            Console.WriteLine(" ExplicitConversion has worked as exptected.");
        }

        public void ConversionsWithHelperClass()
        {
            int value = Convert.ToInt32("23");
            value = int.Parse("32");
            bool success = int.TryParse("23", out value);

            Console.WriteLine($"Conversion using helperclass is {success}");
        }

        public void UsingAs(Stream stream)
        {
            MemoryStream memory = stream as MemoryStream;

            if (memory != null)
            {
                Console.WriteLine("Conversion has worked as exptected. Using AS");
            }
        }

        public void UsingIs(Stream stream)
        {
            var memory = stream is MemoryStream;

            if (memory)
            {
                Console.WriteLine("Stream can be converted by MemoryStream. Using IS");
            }
        }

    }

    public class Money
    {
        public decimal Amount { get; set; }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        public static implicit operator decimal(Money money)
        {
            return money.Amount;
        }

        public static implicit operator int(Money money)
        {
            return (int)money.Amount;
        }
    }
}
