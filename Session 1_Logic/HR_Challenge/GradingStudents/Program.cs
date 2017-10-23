using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingStudents
{
    class Program
    {
 
            static int[] solve(int[] grades){
                int[] resultado = new int[grades.Length];
                int mod = 0;
                for (int i = 0; i < grades.Length; i++)
                {
                    if (grades[i] < 38)
                    {
                        resultado[i] = grades[i];
                    }
                    else
                    {
                        mod = grades[i] % 5;
                        if (mod == 3)
                        {
                            resultado[i] = grades[i] + 2;
                        }
                        else if (mod == 4)
                        {
                            resultado[i] = grades[i] + 1;
                        }
                        else
                        {
                            resultado[i] = grades[i];
                        }
                    }
                }
                return resultado;


            }

            static void Main(String[] args) {
                int n = Convert.ToInt32(Console.ReadLine());
                int[] grades = new int[n];
                for (int grades_i = 0; grades_i < n; grades_i++)
                {
                    grades[grades_i] = Convert.ToInt32(Console.ReadLine());
                }
                int[] result = solve(grades);
                Console.WriteLine(String.Join("\n", result));
            Console.Read();

            }
        }
        
    }

