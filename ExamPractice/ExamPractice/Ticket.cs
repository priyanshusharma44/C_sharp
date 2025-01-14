using ExamPractice;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections.Generic;

namespace ExamPractice
{
    public class student{
       
        public string name { get; set; }
        public string description { get; set; }
    }
    

  /*  public interface IVehicle
    {
        void showBrand();
    }
    public interface IEngine
    {
        void showEngine();
    }*/

   /* public class Car : IVehicle, IEngine
    {
        public string basewala;
        public void showCar()
        {
            Console.WriteLine(basewala);
        }
        public void showBrand() 
        {
            Console.WriteLine("SHOWBRAND");
        }
        public void showEngine() 
        {
            Console.WriteLine("SHOWENGINE");
        }*/
        /* public  string brand { get; set; }

         public void DisplayBrand()
         {
             brand = "hello1";
             Console.WriteLine(brand);
         }*/


    }
/* public static class MyExtension
 {
     public static int DoubleValue(this int number)

     {
         return number*2;

     }

 }*/
/*public class Ticket
{
    public int One { get; set; }
    public Ticket(int first)
    {
        One = first;
    }
    public static int operator +(Ticket a, Ticket b)
    {
        return a.One + b.One;
    } 
}*/
/*enum DaysOfWeek
{
    Sunday,
    Monday
}*/
/*struct Point
{
    public int X;
    public int Y;
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public void Display()
    {
        Console.WriteLine($"{X},{Y}");
    }*/



    /* public class Car2 : Car
     {
        *//* public string models {  get; set; }

         public void second()
         {
             Console.WriteLine(models);
         }*//*

     }*/

    /*  public interface Vehicle
      {
          void showbrand();
      }
      public interface Engine
      {
          void showengine();
      }
      public car: Vehicle, Engine{

          public string brand;
      public string engine;
      public void showbrand()
      {
          Console.WriteLine($"Car brand:{brand}");
      }
      public void showengine()
      {

      }
          }


      */

    /* public class Vehicle
     {
         public string Brand;
         public void ShowBrand()
         {
             Console.WriteLine($"Vehicle brand: {Brand}");
         }  
     }*/
    /* public string Brand;
     // Constructor
     public Car(string Brand)
     {
        this.Brand = Brand;
     }

     public void Detail()
     {
         Console.WriteLine($"Brand:{this.Brand}");
     }*/


    /* public static string M;

     static Car()
     {
         M = "Apple";

     }*/


    /*  public class Student*/
    /* {*/
    /*public int Id { get; set; }
    public string Name { get; set; }*/

    /*  public class Car: Vehicle
      {
          public string Model;
          public void ShowCarDetails()
          {
              Console.WriteLine($"Car model: {Model}");
          }
      }*/




    /* public abstract class Animal
     {
         public abstract void speak();
         public void sleep()
         {
             Console.WriteLine("Sleeping");
         }
     }
     public class Dog: Animal
     {
         public override void speak()
         {
             Console.WriteLine("Dog");
         }
     }
    */


    public class Program
    {

        static void Main(string[] args)
        {


        IList<student> students = new List<student>()
        {
           new student()
           {
               name="Ram", description="Hello"
           },
           new student()
           {
               name="Shyam", description="Hello1"
           }
        };
        foreach (var student in students)
        {

            Console.WriteLine(student.name);
            Console.WriteLine(student.description);
        }

            /*  Car car = new Car();
              car.basewala = "FIRST";
              car.showEngine();*/




            /*  int number = 10;
              int mynumber = number.DoubleValue();*/

            /* Ticket first = new Ticket(2);  // Create first Ticket with value 2
             Ticket second = new Ticket(1); // Create second Ticket with value 1
             int result = first + second;   // Use overloaded '+' operator
             Console.WriteLine($"{first.One} + {second.One} = {result}");*/


            /*                IList<Student> students = new List<Student>()
                             {
                                 new Student() { Id=1 , Name= "RAM" },
                                 new Student() { Id=2 ,Name= "SHYAM" }
                             };*/
            // LINQ query to select the student with Id = 1 and Name = "RAM"
            /* var abc = from obj in students
                       where obj.Id == 1 && obj.Name == "RAM"
                       select obj;

             // Iterating through the results and printing
             foreach (var student in abc)
             {
                 Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
             }*/

            /* var bcd= (from obj in students
                      orderby obj.Id descending, obj.Name descending 
                      select obj).ToList();
             foreach (var student in bcd)
             {
                 Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
             }*/


            /*               // Using LINQ method syntax to filter students
                           var abc = students.Where(obj => obj.Id == 1 && obj.Name == "RAM").ToList();


                            // Iterating over the filtered list
                            foreach (var student in abc)
                            {
                                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
                            }*/
            /*  var abc = students.OrderBy(obj => obj.Id ).ThenByDescending(obj=>obj.Name) .ToList();*/

            /* char[] chars = { 'A', 'B', 'C', 'D' };
              string a= new string(chars);
              string b= new string(chars);
              foreach (char c in a)
              {
                  Console.WriteLine(c);
              }
              foreach (char c in b) 
              {

              Console.WriteLine(c); 


              }
              Console.WriteLine($"the value of a = {a} and b={b}");*/



            /*        StringBuilder sb = new StringBuilder();
                    sb.Append("Hello");
                    sb.Append("");
                    sb.Append("World");
                    Console.WriteLine(sb.ToString());*/

            /* Car car= new Car("Honda");

             Car car2 = new Car(car);
             car2.brand = "Hero";
             Console.WriteLine(car.brand);

             Console.WriteLine(car2.brand);*/

            /* Console.WriteLine(Car.M);*/

            /*            // Create an object of Car
                        Car car = new Car();

                        // Dereference the object, making it eligible for garbage collection
                        car = null;

                        // Force garbage collection to invoke the destructor
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        // Program continues
                                    Console.WriteLine("End of Main");*/
            /* Car car = new Car();*/
            /*                        car.Brand = "Toyota";
                                    car.ShowBrand();
                                    car.Model = "corolla";
                                    car.ShowCarDetails();*/

            /*                Dog dog = new Dog();
                            dog.speak();
            */
            /*  int[] number = { 1, 2, 3, 5, 4, 6, 7, 8 };
              Console.WriteLine(number[0]);
              Console.WriteLine();
              Console.WriteLine(string.Join(",", number));




              Console.WriteLine();

              int[,] b =
              {
                                  {1,2,3},
                                  {7,8,9}

                              };
              Console.WriteLine("element of [1,1]:" + b[1, 1]);
              Console.WriteLine();
              Console.WriteLine();


              int[][] jagged = new int[][] {
                                  new int[] {1,2,3 },
                                  new int[] {4,5,6}
                              };
              Console.WriteLine("Element at [0][1]:" + jagged[0][1]);*/


            /*  DaysOfWeek daysOfWeek = DaysOfWeek.Sunday;
              Console.WriteLine("Today is" + daysOfWeek);*/

            //struct
           /* Point point = new Point(10, 20);
            point.Display();
*/


            //Generic collectrion (List<T>)
            /*            List<int> list = new List<int> { 1,2,3,4,5};
                        list.Sort();
                        foreach (int i in list)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine();
                        list.Add(10);
                        foreach (int i in list)
                        {
                            Console.WriteLine(i);
                        }
                        Console.WriteLine();
                        list.Remove(1);
                        foreach (int i in list)
                        {
                            Console.WriteLine(i);
                        }*/
            // Initializing a Queue with values
            // Initializing a Queue with values
            // Initializing a Queue with values
            /*Queue<int> queue = new Queue<int> { 1, 2, 3, 4 };*/

            // Displaying the elements in the Queue
            /*Console.WriteLine("Queue elements:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            // Enqueue operation (adding an element to the queue)
            queue.Enqueue(5);  // Use Enqueue instead of Add
            Console.WriteLine("\nQueue after Enqueue operation (added 5):");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
    */







        }
    }






    
