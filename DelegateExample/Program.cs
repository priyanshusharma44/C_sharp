namespace DelegateExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Enter First Number:");
            int first = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number");
            int second = Convert.ToInt32(Console.ReadLine());
            MyDelegate dlg = new MyDelegate(Calculation.Add);
            dlg += Calculation.Product;
            dlg += Calculation.Sub;
            dlg(first, second);
            Console.ReadKey();

        }
    }

    public delegate void MyDelegate(int a, int b);
    public class Calculation
    {
        public static void Add(int x, int y)
        {
            Console.WriteLine($"Sum of{x} and {y} is {x + y}");
        }

        public static void Sub(int x, int y)
        {
            Console.WriteLine($"Difference of{x} and {y} is {x - y}");
        }

        public static void Product(int x, int y)
        {
            Console.WriteLine($"Product of{x} and {y} is {x * y}");
        }
    }
}
