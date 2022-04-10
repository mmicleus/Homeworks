using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int[] tablou;
            int min;
            int max;

            Console.WriteLine("Introduceti numarul de elemente in tablou:");
            n = int.Parse(Console.ReadLine());

            tablou = new int[n];

            for (int i = 0; i < n; i++)
            {
                tablou[i] = int.Parse(Console.ReadLine());
            }

            min = tablou[0];
            max = tablou[0];

            for (int i = 0; i < n; i++)
            {
                if (tablou[i] < min)
                    min = tablou[i];

                if (tablou[i] > max)
                    max = tablou[i];
            }

            Console.WriteLine("min:{0}  max{1}", min, max);

        }
    }
}
