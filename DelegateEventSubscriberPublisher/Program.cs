using System;

namespace DelegateEventSubscriberPublisher
{
    public delegate void PersonDelegate();

    public class Person
    {
        public event PersonDelegate? NameChanged;

        private string name = null!;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value) // Only fire the event if the name actually changes
                {
                    if (NameChanged != null) // If the event is subscribed by the user, then fire the event
                    {
                        NameChanged();
                    }
                    name = value;
                }
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            // Subscribe to the NameChanged event
            p.NameChanged += Name_Changed;

            // Change the name to trigger the event
            p.Name = "Roman";
            Console.WriteLine($"Hola {p.Name}, How Are You?");

            // Change the name again to trigger the event again
            p.Name = "Goman";

            
        }

        public static void Name_Changed()
        {
            // Write anything you want to do on the name change of the person
            Console.WriteLine("Your name changed");
        }
    }
}
