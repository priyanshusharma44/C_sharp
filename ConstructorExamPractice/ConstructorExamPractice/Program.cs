using System;

public interface IAnimal
{
    
   void Speak();

}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Dog says: Woof!");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Cat says: Meow!");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        IAnimal dog = new Dog();
        dog.Speak();

        IAnimal cat = new Cat();
        cat.Speak();
    }
}
