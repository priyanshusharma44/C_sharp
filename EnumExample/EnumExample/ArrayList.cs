using System;
using System.Collections;

namespace ArrayListCollection
{
    public class ArrayListExample
    {
        public static void array2()
        {
            ArrayList al = new ArrayList(); // Creating ArrayList collection using default constructor

            Console.WriteLine("Initial Capacity: " + al.Capacity);

            al.Add(10);
            Console.WriteLine("Capacity after adding first item: " + al.Capacity);

            al.Add("hello");
            al.Add(true);
            al.Add(3.14f);
            Console.WriteLine("Capacity after adding fourth item: " + al.Capacity);

            // Printing the ArrayList elements using for loop
            for (int i = 0; i < al.Count; i++)
            {
                Console.Write(al[i] + " ");
            }
            Console.WriteLine();

            // Removing the values from the middle of the ArrayList
            al.Remove(true); // Removing by value
            // al.RemoveAt(2); // You can also remove element by using index position

            // Inserting values into the middle of the ArrayList collection
            al.Insert(2, false);

            // Creating new ArrayList collection by passing the old ArrayList as parameter
            ArrayList coll = new ArrayList(al);
            Console.WriteLine("Initial capacity of new array list collection: " + coll.Capacity);

            // Printing the values of the new array list collection using foreach loop
            foreach (object obj in coll)
            {
                Console.Write(obj + " ");
            }
            Console.WriteLine();

            // Wait for a key press before closing the console window
            Console.ReadKey();
        }
    }
}
