using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp
{
    static class ReturnareBilete
    {
        public static int SelectareRand()
        {
            int rand;

            do
            {
                Console.Clear();
                Console.WriteLine("Introduceti rândul(intre 1 si 20)");
                rand = int.Parse(Console.ReadLine());
            } while (!(rand >= 1 && rand <= Date.Randuri));

            return rand;
        }

        public static int SelectareNrBilete()
        {
            int nrBilete;

            do
            {
                Console.Clear();
                Console.WriteLine("Introduceți numărul de bilete returnate");
                nrBilete = int.Parse(Console.ReadLine());


            } while (!(nrBilete > 0));

            return nrBilete;
        }

        public static int SelectareNrLoc()
        {
            int nrLoc;
            do
            {
                Console.Clear();
                Console.WriteLine($"Introduceti numărul primului loc");
                nrLoc = int.Parse(Console.ReadLine());
            } while (!(nrLoc >= 1 && nrLoc <= Date.LocuriPeRand));

            return nrLoc;
        }

        //TO DO: muta aceasta functie in 'Utility' class

        public static void ReturneazaBilete()
        {
            int rand;
            int nrBilete;
            int nrLoc;

            rand = SelectareRand();
            nrBilete = SelectareNrBilete();
            nrLoc = SelectareNrLoc();

            //TO DO - Make some adjustments

            IEnumerable<Loc> locuriRandSelectat = Date.Locuri.Where(x => x.Coordonate.Rand == rand);

            int sum = 0;

            //To do: Modifica un pic acest cod

            for (int i = nrLoc; i < (nrLoc + nrBilete); i++)
            {
                Loc? loc = locuriRandSelectat.FirstOrDefault(x => (x.Coordonate.Coloana == i));

                if (loc != null)
                {
                    sum += loc.VandutCuPret;
                    loc.Ocupat = false;
                }
                else
                {
                    break;
                }
            }

            Console.Clear();

            Console.WriteLine($"Va fost returnata suma de {sum}");

            Utility.RevenireMenu();
        }
    }
}
