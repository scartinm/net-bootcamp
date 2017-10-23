using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marsExploration
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = Console.ReadLine();
            int cant = S.Length / 3;
            int result = 0;
            int j = 0;
            string[] newS = new string[cant];

            for (int i = 0; i < cant; i++)
            {

                newS[i] = S.Substring(j, 3);
                j += 3;
            }
            for (int i = 0; i < cant; i++)
            {
                if (newS[i].Substring(0, 1) != "S")
                {
                    result += 1;
                }
                if (newS[i].Substring(1, 1) != "O")
                {
                    result += 1;
                }
                if (newS[i].Substring(2, 1) != "S")
                {
                    result += 1;
                }
            }

            Console.WriteLine(result);
            Console.Read();
        }
    }
}
