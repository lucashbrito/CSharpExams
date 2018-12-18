using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    public class EntityFramework : DbContext
    {
        public IDbSet<Person> People { get; set; }

        public EntityFramework()
        {
            using (EntityFramework ctx = new EntityFramework())
            {
                ctx.People.Add(new Person() { Age = 12, Name = "lucas" });
                ctx.SaveChanges();
            }

            using (EntityFramework ctx = new EntityFramework())
            {
                var person = ctx.People.SingleOrDefault(p => p.Age == 12);
                Console.WriteLine(person.Name);
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
