using System;

namespace swap
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10; int b = 20;
            int c = a; //c=10
             a = b; //a=20
             b = c; //b=10
            Console.WriteLine("a:"+ a);
            Console.WriteLine();
            Console.WriteLine("b:"+b);
            Console.WriteLine();
            Console.WriteLine();
            int d = 10;
            int e = 20;
             d = d + e;
             e= d - e;
             d = d - e;
            Console.WriteLine("d:" + d);
            Console.WriteLine();
            Console.WriteLine("e:" + e);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}