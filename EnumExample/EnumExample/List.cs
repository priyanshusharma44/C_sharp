using System;
using System.Collections.Generic;

public class Program4
{
    public static void list()
    {
        List<int> list = new List<int> { 2, 3, 7 };

        list.Add(12); // Add one more value
        list.Insert(3, 40); // Insert at specified index
        list.Remove(3); // Remove an item from the list

        Console.WriteLine("Capacity of the list: " + list.Capacity);
        Console.WriteLine("Count of items in the list: " + list.Count);

        // Part A: Loop through List with foreach.
        foreach (int prime in list)
        {
            // Part B: Access each element with name.
            Console.WriteLine("ELEMENT: {0}", prime);
        }
    }
}
