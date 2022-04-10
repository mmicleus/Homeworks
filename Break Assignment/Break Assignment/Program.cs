using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tab;
            int index;
            ushort n;
            int elem;
            bool found = false;

            Console.WriteLine("Introduceti numarul de elemente in tablou de la tastatura");
            n = ushort.Parse(Console.ReadLine());


            tab = new int[n];
            for (int i = 0; i < n; i++)
            {
                tab[i] = int.Parse(Console.ReadLine());
            }


            Console.WriteLine("Introduceti elementul cautat de la tastatura");
            elem = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (tab[i] == elem)
                {
                    Console.WriteLine("{0} este index-ul elementului cautat", i);
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                Console.WriteLine("{0} nu a fost gasit in tablou", elem);
            }

        }
    }
}
