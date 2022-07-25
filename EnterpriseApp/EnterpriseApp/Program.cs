using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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


        public static string ValidareInput()
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
        /*
        public static string? GetInput(string? input)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1.Vinde bilete\n2.Returneaza Bilete\n3.Afiseaza situatie locuri libere\n4.Modifica preturile\n5.Iesire");
                input = ValidareInput();

            } while (input == null);

            return input;
        }
        */
        public static void ActivareOptiune(string? optiune)
        {
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

        public static void CitireDinFisier()
        {
            string jsonString = File.ReadAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\locuri.txt");
            Date.Locuri = JsonSerializer.Deserialize<Loc[]>(jsonString);

            jsonString = File.ReadAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\variables.txt");
            int[] variabile = JsonSerializer.Deserialize<int[]>(jsonString);

            Date.PretIntreg = variabile[0];
            Date.PretIntreg3D = variabile[1];
            Date.PretRedus = variabile[2];
            Date.PretRedus3D = variabile[3];
        }

        





        public static void Main()
        {
            /*
            string jsonString = JsonSerializer.Serialize<Loc[]>(Date.Locuri, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\locuri.txt", jsonString);

            int[] variables = new int[4] { Date.PretIntreg, Date.PretIntreg3D, Date.PretRedus, Date.PretRedus3D };
            jsonString = JsonSerializer.Serialize<int[]>(variables, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\variables.txt", jsonString);
            */


            if(File.Exists(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\locuri.txt") && File.Exists(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\variables.txt"))
            {
                Console.WriteLine("Files exist");
                Console.ReadLine();
                CitireDinFisier();
            }
            else
            {
                Console.WriteLine("Files don't exist!");
                Console.ReadLine();
                Date.InitializareLocuri();
                Fisiere.UpdateFisierLocuri();
                Fisiere.UpdateFisierVariables();
            }

            Menu();
        }
    }
}
