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

        /*
        public static string Alegere()
        {
            string rasp;
            do
            {
                Console.Clear();
                Console.WriteLine("1) Introducere rand\n2) Revenire la ecranul anterior");
                rasp = Console.ReadLine();
            } while (!(rasp == "1" || rasp == "2"));

            return rasp;
        }
        */

        public static void ReturneazaBilete()
        {
            int rand;
            int nrBilete;
            int nrLoc;

            rand = ValidareRand();
            nrBilete = ValidareNrBilete();
            nrLoc = ValidareNrLoc();


            IEnumerable<Loc> locuriRandSelectat = Date.Locuri.Where(x => x.Coordonate.Rand == rand);

            int sum = 0;


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
