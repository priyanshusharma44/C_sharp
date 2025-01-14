namespace LinqExample
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public short Roll { get; set; }
        public decimal Fee { get; set; }

        public class Program
        {
            static void Main(string[] args)
            {
                List<Student> list = new List<Student>()
                {
                    new Student(){Id=1,Name="Ram",Roll=101,Fee=25000},
                    new Student(){Id=2,Name="Sam",Roll=102,Fee=43000},
                    new Student(){Id=3,Name="Haam",Roll=103,Fee=25000},
                    new Student(){Id=4,Name="Mam",Roll=104,Fee=2500},
                    new Student(){Id=5,Name="Lam",Roll=105,Fee=2000},
                    new Student(){Id=6,Name="Gam",Roll=106,Fee=55000},
                };

                // Query syntax to select student names
                var nameList = from a in list
                               select a.Name;

                // Output names from query syntax
                Console.WriteLine("Names from query syntax:");
                foreach (var a in nameList)
                {
                    Console.WriteLine(a);
                }

                // Query to select student rolls
                var rollList = from a in list
                               select a.Roll;

                Console.WriteLine("\nRoll from query:");
                foreach (var a in rollList)
                {
                    Console.WriteLine(a);
                }

                // Method syntax to filter students with Fee > 5000
                var nameListMethod = list.Where(b => b.Fee > 5000);

                // Output student details from method syntax
                Console.WriteLine("\nStudents with Fee > 5000 from method syntax:");
                foreach (var b in nameListMethod)
                {
                    Console.WriteLine($"Name: {b.Name}, Fee: {b.Fee}");
                }

                // Sorting students in alphabetical order by name, then by fee
                Console.WriteLine("\nStudents in alphabetical order by name and then by fee:");
                foreach (var student in list.OrderBy(s => s.Fee).ThenByDescending(s => s.Name))
                {
                    Console.WriteLine($"Name: {student.Name}, Fee: {student.Fee}");
                }

                // Without LINQ (just for reference)
                /*
                List<string> nList = new List<string>();
                foreach (Student a in list)
                {
                    nList.Add(a.Name);
                }
                */


                List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
                Console.WriteLine("1,2,3,4,5,6");
                // Get the 4th and 5th elements (skip the first 3, take the next 2)
                var subset = numbers.Skip(3).Take(2);

                foreach (var num in subset)
                {

                    Console.WriteLine(num); // Output: 4, 5
                }

                //select() method data transformation
                //convert complex obj to required obj only











                //highest fee list.Max(a=>a.fee));
                //smalles fee list.Max(a=>a.fee));
                //total list.Sum(a=>a.fee));
                //count list.Count());
                //list.where(a=>a.Fee>20000 && a.Fee<50000).First().Name);
                //list.where(a=>a.Fee>20000 && a.Fee<50000).Last().Name);
                //GroupBy()
                var groupByFee = list.GroupBy(a => a.Fee);
                Console.WriteLine("Students grouped by Fee:");
                foreach (var group in groupByFee)
                {
                    Console.WriteLine($"\nFee Group: {group.Key}");
                    foreach (var student in group)
                    {
                        Console.WriteLine($"  Name: {student.Name}, Roll: {student.Roll}");
                    }
                }

            }
        }
    }
}
