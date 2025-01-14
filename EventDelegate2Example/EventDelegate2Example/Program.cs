namespace EventDelegate2Example
{
    public class Bell
    {
        public delegate void BellRing(string teacher, string day);

        public event BellRing BellRang;

        public void Rining(string day,string teacher)
        {
            Console.WriteLine("Going on.......!");
            BellRang?.Invoke(teacher, day);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Bell bell = new Bell();

            bell.BellRang += Teacher;
            bell.BellRang += Student;


            bell.Rining("Teacher", "Chandra");
            bell.Rining("Student", "Sujal");
            


        }
        public static void Teacher(string name, string day)
        {
            Console.WriteLine($"{name}{day}");
        }
        public static void Student(string name, string day)
        {
         Console.WriteLine($"{name}{day}");
        }

    }
}
