using System;

namespace IndexerExample
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Fee { get; set; }
        public DateTime DoB { get; set; }
        public bool IsDisabled { get; set; }

        public Student() { }

        public Student(int id, string name, decimal fee,
            DateTime doB, bool isDisabled)
        {
            Id = id;
            Name = name;
            Fee = fee;
            DoB = doB;
            IsDisabled = isDisabled;
        }

        // String-based indexer
        public object this[string index]
        {
            get
            {
                if (index == "Id") return Id;
                else if (index == "Name") return Name;
                else if (index == "Fee") return Fee;
                else if (index == "DoB") return DoB;
                else if (index == "IsDisabled") return IsDisabled;
                else throw new ArgumentException("Invalid index");
            }
            set
            {
                if (index == "Id") Id = Convert.ToInt32(value);
                else if (index == "Name") Name = Convert.ToString(value);
                else if (index == "Fee") Fee = Convert.ToDecimal(value);
                else if (index == "DoB") DoB = Convert.ToDateTime(value);
                else if (index == "IsDisabled") IsDisabled = Convert.ToBoolean(value);
                else throw new ArgumentException("Invalid index");
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(101, "Bhojraj", 2300,
                new DateTime(2001, 2, 23), false);

            Student s2 = new Student();

            // Using string-based indexer
            s2["Id"] = 102;
            s2["Name"] = "Bhojea";
            s2["Fee"] = 2000;
            s2["DoB"] = new DateTime(2003, 2, 2);
            s2["IsDisabled"] = false;

            Console.Clear();
            Console.WriteLine($"Student Details:\n" +
                              $"Name: {s2["Name"]}\n" +
                              $"Date Of Birth: {((DateTime)s2["DoB"]).ToShortDateString()}\n" +
                              $"Fee: {s2["Fee"]}\n" +
                              $"Is Disabled: {s2["IsDisabled"]}");
        }
    }
}
