using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter2
{
    public class Yields
    {
        public void CallPerson()
        {
            Person[] person = new Person[12];
            for (int i = 0; i < 11; i++)
            {
                person[i].LastName = $"Brito.";
                person[i].Name = $"Sr{i}";
            }
            var people = new People(person);

            Console.WriteLine(people.GetEnumerator().ToString());

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return Name + LastName;
        }
    }

    public class People : IEnumerable<Person>
    {
        Person[] people;

        public People(Person[] people)
        {
            this.people = people;
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < people.Length; i++)
            {
                yield return people[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

