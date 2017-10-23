using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(String[] args)
        {
            int diagonal1 = 0;
            int diagonal2 = 0;
            int resultado = 0;

            int n = Convert.ToInt32(Console.ReadLine());
            int[][] a = new int[n][];
            for (int a_i = 0; a_i < n; a_i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
            }

            for (int i = 0; i < a.Length; i++)
            {
                diagonal1 += a[i][i];
                diagonal2 += a[i][n - i - 1];
            }
            resultado = diagonal1 - diagonal2;
            resultado = Math.Abs(resultado);
            Console.WriteLine(resultado);
            Console.Read();
        }
    }
}
