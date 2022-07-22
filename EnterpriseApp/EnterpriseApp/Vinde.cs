using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp
{
    class Vanzare
    {
        //      to do: mut in clasa 'utilities'
        public static void AfisareLocuri()
        {

            Console.WriteLine("O - Loc Ocupat");
            Console.WriteLine("L - Loc Liber");
            int count = 0;
            for(int i = 0;i < Date.Randuri;i++)
            {
                for(int i2 = 0;i2 < Date.LocuriPeRand;i2++)
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

        public static void VindeBilete()
        {
            //Calculam numarul de locuri libere
            int libere = Date.Locuri.Where(x => x.Ocupat == false).Count();

            if(libere == 0)
            {
                Console.WriteLine("Ne pare rău. Nu mai sunt locuri libere!");
                //revenim la menu
                return;
            }

            AfisareLocuri();
            Console.WriteLine("Introduceți numărul de bilete dorite");
            //to do:   Folosesc TryParse in loc de parse
            int bileteSolicitate = int.Parse(Console.ReadLine());

            if (bileteSolicitate > libere)
            {
                Console.WriteLine($"Mai avem doar {libere} locuri libere");
                return;
            }

            int rezervate = 0;
            int bileteDeRezervat = bileteSolicitate;
            do
            
            {
                int rand;
                do
                {
                    Console.WriteLine("Introduceți rândul dorit (intre 1 si 20)");
                    rand = int.Parse(Console.ReadLine());
                } while (!(rand >= 1 && rand <= Date.Randuri));

                //Extragem randul ales de utilizator
                IEnumerable<Loc> randAles = Date.Locuri.Where(x => x.Coordonate.Rand == rand);

                int nrLoc;
                do
                {
                    Console.WriteLine($"Introduceți locul dorit (de pe randul {rand})");
                    nrLoc = int.Parse(Console.ReadLine());
                } while (!(nrLoc >= 1 && nrLoc <= Date.LocuriPeRand));


                int bileteDeRezervat2 = bileteDeRezervat;
                for (int i = nrLoc; i < (nrLoc + bileteDeRezervat2); i++)
                {
                    Loc? loc = randAles.FirstOrDefault(x => (x.Coordonate.Coloana == i && x.Ocupat == false));

                    if (loc != null)
                    {
                        loc.Ocupat = true;
                        bileteDeRezervat--;

                    }
                    else
                    {
                        break;
                    }
                }

                if (bileteDeRezervat > 0)
                {
                    Console.WriteLine($"Pentru restul de {bileteDeRezervat} locuri rămase selectați vă rog un alt rând");
                    AfisareLocuri();
                }

            } while (bileteDeRezervat > 0);

            //daca sunt destule locuri libere

           

            AfisareLocuri();




            // Console.WriteLine(libere);
        }
    }
}
