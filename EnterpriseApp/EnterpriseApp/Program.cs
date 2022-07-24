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

        //Mut aceasta functie in 'Utility' class
        public static void AfiseazaLocuriLibere()
        {

            Utility.AfisareLocuri();
            int locuriLibere = Date.Locuri.Where(x => x.Ocupat == false).Count();

            Console.WriteLine($"\nLocuri Libere:{locuriLibere}");

            Utility.RevenireMenu();
        }


        public static void Iesire()
        {

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
            Console.Clear();
            //-----------------------------to do: Creez un do-while loop---------------------------------
            switch(optiune)
            {
                case "1":
                    Vanzare.VindeBilete();
                    break;
                case "2":
                    ReturnareBilete.ReturneazaBilete();
                    break;
                case "3":
                    AfiseazaLocuriLibere();
                    break;
                case "4":
                    ModificarePreturi.ModificaPreturile();
                    break;
                case "5":
                    return;
                    break;

            }
        }

       

        public static void Menu()
        {
            string? input;

            do
            {
                //primeste input de la user si valideaza-l
                do
                {
                    Console.Clear();
                    Console.WriteLine("1.Vinde bilete\n2.Returneaza Bilete\n3.Afiseaza situatie locuri libere\n4.Modifica preturile\n5.Iesire");
                    input = GetInput();

                } while (input == null);

                //Cheama functia ce corespunde optiunii alese
                ActivareOptiune(input);
            }
            while (input != "5");
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
