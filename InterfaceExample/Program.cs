using System.Security.Cryptography.X509Certificates;

namespace InterfaceExample
{
    public interface IPerson
    {
        public void Register();
        public void Remove();
        
    }
    public class Student:IPerson
    {
        public int Id { get; set; } 
        public string Name { get; set; }   
        public String Address { get; set; } 
        public Student()
        {
            Name = "NA";
            Address = "NA";
            Id = 0;
        }
        public void Register()
        {
            Console.WriteLine("Student Registered Sucessfully!");
        }
        public void Remove()
        {
            Console.WriteLine("Student Removed Sucessfully");
        }
    }
    public class Teacher :IPerson 
    {
        public void Register()
        {
            Console.WriteLine("Teacher Registered Sucessfully!");
        }
        public void Remove()
        {
            Console.WriteLine("Teacher Removed Sucessfully");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IPerson p = new Student();
            p.Register();

           
        }
    }
}