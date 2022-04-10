using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max;
            int min;
            int indexMax;
            int indexMin;
            int n;

            Console.WriteLine("Introduceti numarul de siruri:");
            n = int.Parse(Console.ReadLine());

            string[] strings = new string[n];

            for (int i = 0; i < n; i++)
            {
                strings[i] = Console.ReadLine();
            }


            max = strings[0].Length;
            min = strings[0].Length;
            indexMax = 0;
            indexMin = 0;

            for (int i = 0; i < strings.GetLength(0); i++)
            {
                if (strings[i].Length > max)
                {
                    max = strings[i].Length;
                    indexMax = i;
                }

                if (strings[i].Length < min)
                {
                    min = strings[i].Length;
                    indexMin = i;
                }
            }

            Console.Write("The element with the maximum length has index {0}.", indexMax);
            Console.WriteLine("The element with the minimum length has index {0}", indexMin);

        }
    }
}
