using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcsCakeWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] calories_temp = Console.ReadLine().Split(' ');
            int[] calories = Array.ConvertAll(calories_temp, Int32.Parse);
            // your code goes here

            double result = 0;

            Array.Sort(calories);
            Array.Reverse(calories);

            for (int i = 0; i < n; i++)
            {
                result += calories[i] * Math.Pow(2, i);
            }
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
