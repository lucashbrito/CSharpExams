using System;

namespace Chapter2
{
    public class EnumClass
    {
        public void CompareEnums()
        {
            var day = Days.Sun;

            if ((byte)day == 1)
            {
                Console.WriteLine($"Today is day {day}");
            }

            var gender = Gender.Male;

            Console.WriteLine(gender);
        }
    }
}
