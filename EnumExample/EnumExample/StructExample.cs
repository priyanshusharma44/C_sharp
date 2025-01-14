using System;

namespace EnumAndStructExamples
{
    // Define a struct for a point in 2D space
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        // Constructor to initialize the point
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Method to display the point
        public void Display()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
        }
    }

    public class StructExample
    {
        public static void array1()
        {
            // Create an instance of the Point struct
            Point p1 = new Point(10, 20);
            // Display the point
            p1.Display();

            // Modify the point's coordinates
            p1.X = 30;
            p1.Y = 40;
            // Display the modified point
            p1.Display();

            // Create another instance using object initializer
            Point p2 = new Point { X = 50, Y = 60 };
            // Display the second point
            p2.Display();
        }
    }
}
