using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp
{
    static class ReturnareBilete
    {
        public static int ValidareRand()
        {
            int rand;

            do
            {
                Console.Clear();
                Console.WriteLine("Introduceti rândul(intre 1 si 20)");
            } while (!(int.TryParse(Console.ReadLine(),out rand)) || !(rand >= 1 && rand <= Date.Randuri));

            return rand;
        }

        public static int ValidareNrBilete()
        {
            int nrBilete;

            do
            {
                Console.Clear();
                Console.WriteLine("Introduceți numărul de bilete returnate");
            }while (!(int.TryParse(Console.ReadLine(), out nrBilete)) || !(nrBilete > 0));

            return nrBilete;
        }

        public static int ValidareNrLoc()
        {
            int nrLoc;
            do
            {
                Console.Clear();
                Console.WriteLine($"Introduceti numărul primului loc");
            } while (!(int.TryParse(Console.ReadLine(), out nrLoc)) || !(nrLoc >= 1 && nrLoc <= Date.LocuriPeRand));

            return nrLoc;
        }

        //TO DO: muta aceasta functie in 'Utility' class

        public static void ReturneazaBilete()
        {
            int rand;
            int nrBilete;
            int nrLoc;

            rand = ValidareRand();
            nrBilete = ValidareNrBilete();
            nrLoc = ValidareNrLoc();

            //TO DO - Make some adjustments

            IEnumerable<Loc> locuriRandSelectat = Date.Locuri.Where(x => x.Coordonate.Rand == rand);

            int sum = 0;

            //To do: Modifica un pic acest cod

            for (int i = nrLoc; i < (nrLoc + nrBilete); i++)
            {
                Loc? loc = locuriRandSelectat.FirstOrDefault(x => (x.Coordonate.Coloana == i && x.Ocupat == true));

                if (loc != null)
                {
                    sum += loc.VandutCuPret;
                    loc.Ocupat = false;
                    loc.VandutCuPret = 0;
                }
                else
                {
                    break;
                }
            }

            Fisiere.UpdateFisierLocuri();

            Console.Clear();

            Console.WriteLine($"Va fost returnata suma de {sum}");

            Utility.RevenireMenu();
        }
    }
}
