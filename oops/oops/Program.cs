using System;
namespace oops
{
    public class Car
    {
        string color = "red";  
        int maxSpeed = 200;         
        public void fullThrottle()
        {
            Console.WriteLine("Color:" + color);
            Console.WriteLine("MaxSpeed:" + maxSpeed);
        }

        public static void Main(string[] args)
        {
            Car myObj1 = new Car();
            myObj1.fullThrottle();
        }
    }

}