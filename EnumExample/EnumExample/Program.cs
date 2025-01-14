using System;
using EnumAndStructExamples;
using ArrayListCollection;

namespace EnumExample
{
    public enum Days
    {
        Sunday = 1,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum Sizes
    {
        Small = 1,
        Medium,
        Large,
        ExtraLarge
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Call methods from other classes
            StructExample.array1();
            ArrayListExample.array2();
            Program4.list();

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Days of the Week:");
            foreach (string s in Enum.GetNames(typeof(Days)))
            {
                Console.WriteLine(s);
            }

            foreach (Days n in Enum.GetValues(typeof(Days)))
            {
                Console.WriteLine((int)n);
            }

            Days myDay = (Days)1;
            Console.WriteLine($"Day from integer 1: {myDay}");

            Console.WriteLine("\nSizes:");
            foreach (string s in Enum.GetNames(typeof(Sizes)))
            {
                Console.WriteLine(s);
            }

            foreach (Sizes size in Enum.GetValues(typeof(Sizes)))
            {
                Console.WriteLine((int)size);
            }

            Sizes mySize = (Sizes)1;
            Console.WriteLine($"Size from integer 1: {mySize}");

            Console.ReadKey(); // Move this outside the loops to pause the console at the end.
        }
    }
}

