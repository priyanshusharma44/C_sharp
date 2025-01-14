using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "This is a \"string\" in C#.";
            Console.WriteLine(text);
            string path = @"C:\Users\Shared";
            Console.WriteLine(path);

            Console.WriteLine("Hello World!"); 
            Console.WriteLine("Hello World!");
            Console.WriteLine("I am Learning C#");
            Console.WriteLine("It is awesome!");
            int myInt = 10;
            double myDouble = 5.25;
            bool myBool = true;

            Console.WriteLine(Convert.ToString(myInt));    // convert int to string
            Console.WriteLine(Convert.ToDouble(myInt));    // convert int to double
            Console.WriteLine(Convert.ToInt32(myDouble));  // convert double to int
            Console.WriteLine(Convert.ToString(myBool));   // convert bool to string


            //**********************************************************************

            // Type your username and press enter
            Console.WriteLine("Enter username:");

            // Get user input from the keyboard and store it in the variable
            string? userName = Console.ReadLine(); // Note the use of nullable reference type here
            Console.WriteLine(userName);


            //**********************************************************************
            int x = 5;
            int y = 2;
            Console.WriteLine(x % y);

            //**********************************************************************
            int a = 5;
            int b=10;
            int c = Math.Max(a, b);
            Console.WriteLine(c);

            //**********************************************************************
            string txt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine("The length of the txt string is: " + txt.Length);

            //..
            string firstName = "John ";
            string lastName = "Doe";
            string name = firstName + lastName;
            Console.WriteLine(name);

            //..
            string firstName1 = "John";
            string lastName2 = "Doe";
            string name1 = $"My full name is: {firstName} {lastName}";
            Console.WriteLine(name1);

            //..
            // Full name
            string name2 = "John Doe";

            // Location of the letter D
            int charPos = name.IndexOf("D");

            // Get last name
            string lastName3 = name.Substring(charPos);

            // Print the result
            Console.WriteLine(lastName3);
            MyMethod();
            MyMethod1("RAMESH");
            PlusMethod(20, 30);
            PlusMethod(20.57, 30.67);

        }
        static void MyMethod()
        {
            Console.WriteLine("I just got executed!");
        }
        static void MyMethod1(string fname)
        {
            Console.WriteLine(fname + " Refsnes");
        }
        static int PlusMethod(int x, int y)
        {
            return x + y;
        }

        static double PlusMethod(double x, double y)
        {
            return x + y;
        }
    }


}
