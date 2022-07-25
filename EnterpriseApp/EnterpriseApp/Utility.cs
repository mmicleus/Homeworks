using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp
{
    public static class Utility
    {
        public static void RevenireMenu()
        {
            //revenim la menu
            Console.WriteLine("Apasati orice tasta pentru a reveni la menu");

            Console.ReadLine();
        }


        public static void AfisareLocuri()
        {

            Console.WriteLine("O - Loc Ocupat");
            Console.WriteLine("L - Loc Liber");
            int count = 0;
            for (int i = 0; i < Date.Randuri; i++)
            {
                for (int i2 = 0; i2 < Date.LocuriPeRand; i2++)
                {
                    if (Date.Locuri[count].Ocupat == true)
                    {
                        Console.Write("O    ");
                    }

                    else
                    {
                        Console.Write("L    ");
                    }
                    count++;
                }
                Console.WriteLine();
            }
        }


    }
}
