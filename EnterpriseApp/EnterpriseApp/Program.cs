using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnterpriseApp
{
    class Program
    {

        public static void AfiseazaLocuriLibere()
        {

            Utility.AfisareLocuri();
            int locuriLibere = Date.Locuri.Where(x => x.Ocupat == false).Count();

            Console.WriteLine($"\nLocuri Libere:{locuriLibere}");

            Utility.RevenireMenu();
        }


        public static string 
            ValidareInput()
        {
            string input;

            do
            {
                Console.Clear();
                Console.WriteLine("1.Vinde bilete\n2.Returneaza Bilete\n3.Afiseaza situatie locuri libere\n4.Modifica preturile\n5.Iesire");
                input = Console.ReadLine();

            } while (!(input == "1" || input == "2" || input == "3" || input == "4" || input == "5"));

            return input;
        }

        public static void ActivareOptiune(string? optiune)
        {
            //acest switch va chema metoda ce corespunde optiunii alese de utilizator
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
                    Fisiere.UpdateFisierLocuri();
                    Fisiere.UpdateFisierVariables();
                    return;
                    break;

            }
        }

       

        public static void Menu()
        {
            string input;

            do
            {
                //primeste input de la user si valideaza-l
                input = ValidareInput();

                Console.Clear();
                //Cheama functia ce corespunde optiunii alese
                ActivareOptiune(input);
            }
            while (input != "5");
        }

        public static void Main()
        {
            //Verificam daca fisierele 'Locuri.txt' si 'variables.txt' exista
            if (File.Exists(Fisiere.DenumireFisier1) && File.Exists(Fisiere.DenumireFisier2))
            {
                //Daca fisierele 'Locuri.txt' si 'variables.txt' exista, atunci citim datele din acestea si le incarcam in memorie
                Fisiere.CitireDinFisier();

            }
            else
            {
                //daca fisierele 'Locuri.txt' si 'variables.txt' nu exista, atunci initializam tabloul 'Locuri' si il scriem in fisierul 'locuri.txt'
                Date.InitializareLocuri();
                Fisiere.UpdateFisierLocuri();
                //Scriem valoarea celor 4 preturi in fisierul 'variables.txt'
                Fisiere.UpdateFisierVariables();
            }

            Menu();
        }
    }
}
