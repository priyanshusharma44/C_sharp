using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            Program1.array1();
            Console.WriteLine("\nEnter Sentence:");
            string sentence = Console.ReadLine();
            string result = TitleCase(sentence);
            Console.WriteLine(result);
        }

        static string TitleCase(string sen)
        {
            bool isFirstLetter = true;
            char[] result = new char[sen.Length];

            for (int i = 0; i < sen.Length; i++)
            {
                if (char.IsWhiteSpace(sen[i]))
                {
                    isFirstLetter = true;
                    result[i] = sen[i];
                }
                else if (isFirstLetter)
                {
                    result[i] = char.ToUpper(sen[i]);
                    isFirstLetter = false;
                }
                else
                {
                    result[i] = char.ToLower(sen[i]);
                }
            }

            return new string(result);
        }
    }
}
