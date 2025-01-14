using System.IO;
using System.Text.Json;
namespace FileExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee>? emps = [];
            string data;
            do
            {
               
                if(File.Exists("emp.json"))
                {
                    data = File.ReadAllText("emp.json");
                    emps = JsonSerializer.Deserialize<List<Employee>>(data);
                }
                Console.WriteLine("Select Your Choice:");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Modify");
                Console.WriteLine("4. List");
                Console.WriteLine("5. Search");
                Console.WriteLine("6. Quit");
                char choice =(char) Console.Read();
                switch (choice)
                {
                    case '1':
                        Employee e1 = new Employee { Id = 101, Name = "Itahari", Salary = 40000 };
                        break;
                    case '2': break;
                    case '3': break;
                    case '4': break;
                    case '5': break;
                    case '6': goto down;  


                }
            }
            while (true);
            down:
            data =JsonSerializer.Serialize(emps);
            File.WriteAllText("emp.json", data);
        }
    }
}
