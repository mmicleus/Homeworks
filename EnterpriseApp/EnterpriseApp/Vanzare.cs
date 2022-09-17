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

        //Cerem utilizatorului sa introduca randul dorit de la tastatura si validam input-ul
        public static int ValidareRand()
        {
            int rand;

            //aceasta bucla se va executa atata timp cat user-ul nu a introdus un numar valid (intre 1 si 20)
            do
            {
                Console.WriteLine("Introduceti rândul dorit (intre 1 si 20)");
            }while (!(int.TryParse(Console.ReadLine(),out rand)) || !(rand >= 1 && rand <= Date.Randuri));

            return rand;
        }

        public static int ValidareCategorieBilet()
        {
            int alegere;
            do
            {
                Console.Clear();
                Console.WriteLine("Precizati categoria biletelor:");

                Console.WriteLine($"1) Pret întreg ({Date.PretIntreg})\n2) Pret întreg cu ochelari 3D ({Date.PretIntreg3D})\n3) Pret redus ({Date.PretRedus})\n4) Pret redus cu ochelari 3D ({Date.PretRedus3D})");

            } while(!(int.TryParse(Console.ReadLine(),out alegere)) || !(alegere == 1 || alegere == 2 || alegere == 3 || alegere == 4));

            return alegere;
        }

        public static int ValidareLoc(int rand)
        {
            int nrLoc;
            do
            {
                Console.WriteLine($"Introduceti numarul primului loc dorit (de pe randul {rand})");
            } while ( !(int.TryParse(Console.ReadLine(),out nrLoc)) || !(nrLoc >= 1 && nrLoc <= Date.LocuriPeRand));

            return nrLoc;
        }

        public static int ValidareNrBileteSolicitate()
        {
            int nrBileteSolicitate;

            do
            {
                //Console.Clear();
                Console.WriteLine("Introduceti numărul de bilete dorite (un numar pozitiv)");
            }
            while (!(int.TryParse(Console.ReadLine(), out nrBileteSolicitate)) || nrBileteSolicitate <= 0);

            return nrBileteSolicitate;
        }

        /*
        public static string Alegere()
        {
            string rasp;
            do
            {
                Console.Clear();
                Console.WriteLine("1) Introducere numar de bilete dorite\n2) Revenire la ecranul anterior");
                rasp = Console.ReadLine();
            } while (!(rasp == "1" || rasp == "2"));

            return rasp;
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

            int nrBileteSolicitate = ValidareNrBileteSolicitate();

            if (nrBileteSolicitate == 0)
            {
                Console.Clear();
                return;
            }

            
            if (nrBileteSolicitate > libere)
            {
                Console.Clear();
                Console.WriteLine($"Mai avem doar {libere} locuri libere");

                Utility.RevenireMenu();
                return;
            }
            

            List<Loc> LocuriRevervate = new List<Loc>();
            int nrBileteDeRezervat = nrBileteSolicitate;

            //acest cod se va executa atata timp cat utilizatorul mai are locuri de rezervat
            do
            {

               int rand = ValidareRand();

                //Extragem randul ales de utilizator
                //'randAles' este o colectie de obiecte de tip 'loc' aflate pe randul ales de utilizator
                IEnumerable<Loc> randAles = Date.Locuri.Where(x => x.Coordonate.Rand == rand);

                int nrLoc = ValidareLoc(rand);
                
                int bileteDeRezervat2 = nrBileteDeRezervat;
                for (int i = nrLoc; i < (nrLoc + bileteDeRezervat2); i++)
                {
                    Loc? loc = randAles.FirstOrDefault(x => (x.Coordonate.Coloana == i && x.Ocupat == false));

                    //din moment ce am gasit un loc ce corespunde cerintelor utilizatorului, il adaugam in lista 'LocuriRezervate' si setam
                    //campul 'Ocupat' pe true
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
                //Daca au mai ramas bilete de rezervat, mai efectuam o iteratie
                if (nrBileteDeRezervat > 0)
                {
                    Utility.AfisareLocuri();
                    Console.WriteLine($"Pentru restul de {nrBileteDeRezervat} locuri rămase selectati vă rog un alt rând");
                }

            }while(nrBileteDeRezervat > 0);


            int alegere = ValidareCategorieBilet();
            

            int pretBilet = GetPret(alegere);

            SetareCostBilete(LocuriRevervate, pretBilet);

            //modificam fisierul 'locuri.txt
            Fisiere.UpdateFisierLocuri();

            Console.Clear();

            Console.WriteLine($"Suma de plata:{nrBileteSolicitate * pretBilet}");

            Utility.RevenireMenu();
            return;
        }

        
    }
}
