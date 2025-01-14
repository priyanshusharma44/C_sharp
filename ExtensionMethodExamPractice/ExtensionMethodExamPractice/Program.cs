namespace ExtensionMethodExamPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
           Calculator c = new Calculator();
            Console.WriteLine(c.sum(10, 20));
            Console.WriteLine(c.sub(10, 20));
            Console.WriteLine(c.showIdentifierValue());
        }
    }
}
