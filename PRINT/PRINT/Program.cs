using System;

namespace PRINT
{
    class program1
    {
        public static void Main(string[] args)
        {
            // Convert '3' to a string and concatenate it with itself
            /* Console.WriteLine(new string('3', 2));
            Console.WriteLine("HI BHOJRAJ");
            Console.ReadKey(); // like getch()
            */
            int firstnum, secondnum, sum;
            Console.Clear();
            Console.WriteLine("enter first number"); //if write then in same line and can use /n at
            //last to make wirteLin manually
            firstnum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter second number");
            secondnum = Convert.ToInt32(Console.ReadLine());
            sum = firstnum + secondnum;
            Console.WriteLine("sum is :" +sum);
            Console.ReadKey();
        }
    }
}
