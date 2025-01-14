namespace ExtensionMethodExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Sum(5,2));
            Console.WriteLine(calculator.Sub(5,4));
            Console.WriteLine(calculator.Identifier1());    
            Console.ReadLine();
        }
    }
}
