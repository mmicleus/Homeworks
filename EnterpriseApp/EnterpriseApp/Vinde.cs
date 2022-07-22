﻿using System;
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

        public static void SetareCostBilete(List<Loc> locuri,byte pretBilet)
        {
            foreach(Loc l in locuri)
            {
                l.VandutCuPret = pretBilet;
            }
        }


        public static byte GetPret(int alegere)
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
            Console.WriteLine("Introduceti numărul de bilete dorite");
            //to do:   Folosesc TryParse in loc de parse
            int nrBileteSolicitate = int.Parse(Console.ReadLine());

            if (nrBileteSolicitate > libere)
            {
                Console.WriteLine($"Mai avem doar {libere} locuri libere");
               // Console.Clear();
                return;
            }

            int rezervate = 0;
            List<Loc> LocuriRevervate = new List<Loc>();
            int nrBileteDeRezervat = nrBileteSolicitate;
            do
            {
                int rand;
                do
                {
                    Console.WriteLine("Introduceti rândul dorit (intre 1 si 20)");
                    rand = int.Parse(Console.ReadLine());
                } while (!(rand >= 1 && rand <= Date.Randuri));

                //Extragem randul ales de utilizator
                IEnumerable<Loc> randAles = Date.Locuri.Where(x => x.Coordonate.Rand == rand);

                int nrLoc;
                do
                {
                    Console.WriteLine($"Introduceti locul dorit (de pe randul {rand})");
                    nrLoc = int.Parse(Console.ReadLine());
                } while (!(nrLoc >= 1 && nrLoc <= Date.LocuriPeRand));


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
                    AfisareLocuri();
                }

            }while(nrBileteDeRezervat > 0);

            //Console.Clear();

            bool notValid;
            int alegere;
            do
            {
                Console.WriteLine("Precizati categoria biletelor:");

                Console.WriteLine(@$"
1) Pret întreg ({Date.PretIntreg}) 
2) Pret întreg cu ochelari 3D ({Date.PretIntreg3D})
3) Pret redus ({Date.PretRedus})
4) Pret redus cu ochelari 3D ({Date.PretRedus3D})");

                 alegere = int.Parse(Console.ReadLine());
                notValid = (alegere == 1 || alegere == 2 || alegere == 3 || alegere == 4) ? false : true;
                
            }while (notValid);

            byte pretBilet = GetPret(alegere);

            SetareCostBilete(LocuriRevervate, pretBilet);

            //Console.Clear();

            Console.WriteLine($"Suma de plata:{nrBileteSolicitate * pretBilet}");

            /*

            int count = 0;

            for (int i = 0; i < Date.Randuri; i++)
            {
                for (int i2 = 0; i2 < Date.LocuriPeRand; i2++)
                {
                    if (Date.Locuri[count].Ocupat == true)
                    {
                        Console.Write($"{Date.Locuri[count].VandutCuPret}      ");
                    }

                    else
                    {
                        Console.Write("L       ");
                    }
                    count++;
                }
                Console.WriteLine();
            }

            */

            //AfisareLocuri();




            // Console.WriteLine(libere);
        }
    }
}
