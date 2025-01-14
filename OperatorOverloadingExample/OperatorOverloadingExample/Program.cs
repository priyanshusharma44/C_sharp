using System;

namespace OperatorOverloadingExample
{
    public class Ticket
    {
        public int Row { get; set; } // Property names should be PascalCase
        public int Col { get; set; }

        // Constructor
        public Ticket(int row, int col)
        {
            Row = row;
            Col = col;
        }

        // Overloading the + operator
        public static Ticket operator +(Ticket t1, Ticket t2)
        {
            return new Ticket(t1.Row + t2.Row, t1.Col + t2.Col); // Corrected to add both Row and Col
        }

        // Method to display the ticket information
        public void Display()
        {
            Console.WriteLine($"Row: {Row}, Col: {Col}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Ticket ticket1 = new Ticket(10, 20);
            Ticket ticket2 = new Ticket(30, 15);
            Ticket total = ticket1 + ticket2; // Using the overloaded + operator

            total.Display(); // Displaying the total ticket details
        }
    }
}
