using System.ComponentModel;

namespace IndexerYoutube
{
    public class A
    {
        private string[] peoples = new string[3];

        public string this[int i]
        {
            get 
            {
                return peoples[i];
            }
            set
            {
                peoples[i] = value;

            }


        }

        public class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                a[0] = "Ram";
                a[1] = "Shyam";
                a[2] = "Hari";

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(a[i]);
                }
            }
        }
    }
}
