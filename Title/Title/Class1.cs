using System;

namespace HelloWorld
{
    class Program1
    {
        public static void array1()
        {
            int[] nums = new int[10];
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write($"Enter Number {i + 1}: ");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("\nBEFORE SORTING....");
            foreach (int n in nums)
            {
                Console.WriteLine("{0}\t", n);
            }
            Array.Sort(nums);
            Console.WriteLine("\nAFTER SORTING....");
            foreach (int n in nums)
            {
                Console.WriteLine("{0}\t", n);
            }

            Console.ReadKey();
        }
    }
}
