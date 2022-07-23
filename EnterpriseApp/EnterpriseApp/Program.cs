using System;
using System.Collections.Generic;

namespace EnterpriseApp
{
    class Program
    {

        public static void VindeBilete()
        {

        }

        public static void ReturneazaBilete()
        {

        }

        public static void AfiseazaLocuriLibere()
        {
            Console.Clear();
            
            Console.WriteLine("O - Loc Ocupat");
            Console.WriteLine("L - Loc Liber");
            Console.WriteLine();
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

            int locuriLibere = Date.Locuri.Where(x => x.Ocupat == false).Count();
            Console.WriteLine();

            Console.WriteLine($"Locuri Libere:{locuriLibere}");
        }

        /*
        public static void ModificaPreturile()
        {


        }

        */

        public static void Iesire()
        {

        }
        public static void AfisareMenu()
        {
            Console.WriteLine("1.Vinde bilete\n2.Returneaza Bilete\n3.Afiseaza situatie locuri libere\n4.Modifica preturile\n5.Iesire");
        } 

        public static string? GetInput()
        {
            string rez = Console.ReadLine();

            switch (rez)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    return rez;
                default:
                    return null;
            }
        }

        public static void ActivareOptiune(string? optiune)
        {
            //-----------------------------to do: Creez un do-while loop---------------------------------
            switch(optiune)
            {
                case "1":
                    Vanzare.VindeBilete();
                    break;
                case "2":
                    ReturneazaBilete();
                    break;
                case "3":
                    AfiseazaLocuriLibere();
                    break;
                case "4":
                    ModificarePreturi.ModificaPreturile();
                    break;
                case "5":
                    Iesire();
                    break;

            }
        }

       

        public static void Menu()
        {
            string? input;
            //primeste input de la user si valideaza-l
            do
            {
                AfisareMenu();
                input = GetInput();

            } while (input == null);

            //Cheama functia ce corespunde optiunii alese
            ActivareOptiune(input);
            
        }



        public static void Main()
        {
            Menu();
            /*
            int count = 0;
            for(byte i = 0; i < 20;i++)
            {
                for(byte i2 = 0;i2 < 20;i2++)
                {
                    Console.Write($" ({Date.Locuri[count].Coordonate.Rand},{Date.Locuri[count].Coordonate.Coloana}) ");
                    count++;
                }
                Console.WriteLine("\n");
            }
            */
        }
    }
}
