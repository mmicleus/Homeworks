using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadratic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            int delta;
            float x1, x2, x;

            Console.WriteLine("a = ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("b = ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("c=");
            c = int.Parse(Console.ReadLine());

            if (a == 0)
            {
                x = ((float)c / b) * (-1);

                Console.WriteLine("x = {0}", x);
            }
            else
            {
                delta = b * b - 4 * a * c;

                if (delta == 0)
                {
                    x = -((float)b / (2 * a));
                    Console.WriteLine("x = {0}", x);
                }
                else if (delta > 0)
                {
                    x1 = (-b + (float)Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b - (float)Math.Sqrt(delta)) / (2 * a);

                    Console.WriteLine("x1={0}   x2 = {1}", x1, x2);

                }
                else
                {
                    Console.WriteLine("Ecuatia nu are solutii reale");
                }
            }

        }
    }
}
