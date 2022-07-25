using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnterpriseApp
{
    static class Vanzare
    {
        //      to do: mut in clasa 'utilities'
        /*
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
        */
        public static void SetareCostBilete(List<Loc> locuri,int pretBilet)
        {
            foreach(Loc l in locuri)
            {
                l.VandutCuPret = pretBilet;
            }
        }


        public static int GetPret(int alegere)
        {
            switch (alegere)
            {
                case 1:
                    return Date.PretIntreg;
                    break;
                case 2:
                    return Date.PretIntreg3D;
                    break;
                case 3:
                    return Date.PretRedus;
                    break;
                case 4:
                    return Date.PretRedus3D;
                    break;
                default:
                    return 0;
            }
        }


        public static int ValidareRand()
        {
            int rand;

            do
            {
                Console.WriteLine("Introduceti rândul dorit (intre 1 si 20)");
                rand = int.Parse(Console.ReadLine());
            }while (!(rand >= 1 && rand <= Date.Randuri));

            return rand;
        }

        public static int ValidareCategorieBilet()
        {
            int alegere;
            do
            {
                Console.WriteLine("Precizati categoria biletelor:");

                Console.WriteLine($"1) Pret întreg ({Date.PretIntreg})\n2) Pret întreg cu ochelari 3D ({Date.PretIntreg3D})\n3) Pret redus ({Date.PretRedus})\n4) Pret redus cu ochelari 3D ({Date.PretRedus3D})");

                alegere = int.Parse(Console.ReadLine());

            } while(!(alegere == 1 || alegere == 2 || alegere == 3 || alegere == 4));

            return alegere;
        }

        public static int ValidareLoc(int rand)
        {
            int nrLoc;
            do
            {
                Console.WriteLine($"Introduceti numarul primului loc dorit (de pe randul {rand})");
                nrLoc = int.Parse(Console.ReadLine());
            } while (!(nrLoc >= 1 && nrLoc <= Date.LocuriPeRand));

            return nrLoc;
        }

        /*
        public  static void UpdateFisierLocuri()
        {
            string jsonString = JsonSerializer.Serialize<Loc[]>(Date.Locuri, new JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine(jsonString);

            File.WriteAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\locuri.txt",jsonString);

            Console.ReadLine();
        }
        */

        /*
        public static void RevenireMenu()
        {
            //revenim la menu
            Console.WriteLine("Apasati orice tasta pentru a reveni la menu");

            Console.ReadLine();
        }
        */


        public static void VindeBilete()
        {
            //Calculam numarul de locuri libere
            int libere = Date.Locuri.Where(x => x.Ocupat == false).Count();

            if(libere == 0)
            {
                Console.Clear();
                Console.WriteLine("Ne pare rău. Nu mai sunt locuri libere!");
                Utility.RevenireMenu();
                return;
            }

            Utility.AfisareLocuri();
            Console.WriteLine("Introduceti numărul de bilete dorite");
            //to do:   Folosesc TryParse in loc de parse
            int nrBileteSolicitate = int.Parse(Console.ReadLine());

            if (nrBileteSolicitate > libere)
            {
                Console.Clear();
                Console.WriteLine($"Mai avem doar {libere} locuri libere");

                Utility.RevenireMenu();
                // Console.Clear();
                return;
            }

            List<Loc> LocuriRevervate = new List<Loc>();
            int nrBileteDeRezervat = nrBileteSolicitate;
            do
            {

               int rand = ValidareRand();

                //Extragem randul ales de utilizator
                IEnumerable<Loc> randAles = Date.Locuri.Where(x => x.Coordonate.Rand == rand);

                int nrLoc = ValidareLoc(rand);
                
                int bileteDeRezervat2 = nrBileteDeRezervat;
                for (int i = nrLoc; i < (nrLoc + bileteDeRezervat2); i++)
                {
                    Loc? loc = randAles.FirstOrDefault(x => (x.Coordonate.Coloana == i && x.Ocupat == false));

                    if (loc != null)
                    {
                        loc.Ocupat = true;
                        LocuriRevervate.Add(loc);
                        nrBileteDeRezervat--;

                    }
                    else
                    {
                        break;
                    }
                }

                if (nrBileteDeRezervat > 0)
                {
                    Console.WriteLine($"Pentru restul de {nrBileteDeRezervat} locuri rămase selectati vă rog un alt rând");
                    Utility.AfisareLocuri();
                }

            }while(nrBileteDeRezervat > 0);

            //Console.Clear();

            int alegere = ValidareCategorieBilet();
            

            int pretBilet = GetPret(alegere);

            SetareCostBilete(LocuriRevervate, pretBilet);

            Fisiere.UpdateFisierLocuri();

            Console.Clear();

            Console.WriteLine($"Suma de plata:{nrBileteSolicitate * pretBilet}");

            Utility.RevenireMenu();
            return;
        }

        
    }
}
