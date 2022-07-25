using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnterpriseApp
{
    public static class Date
    {
        public const byte LocuriPeRand = 20;

        public const byte Randuri = 20;
        //Pret intreg
        public static int PretIntreg = 30;

        //Pret intreg cu ochelari 3D
        public static int PretIntreg3D = 32;

        //Pret redus
        public static int PretRedus = 20;

        //Pret redus cu ochelari 3D

        public static int PretRedus3D = 22;

        // public static Loc[,] Locuri;


        //Consider making this a list
        public static Loc[] Locuri;

        public static void InitializareLocuri()
        {
            int count = 0;


            Locuri = new Loc[Randuri * LocuriPeRand];
            for (byte i = 1; i <= Randuri; i++)
                for (byte i2 = 1; i2 <= LocuriPeRand; i2++)
                {
                    Locuri[count++] = new Loc(new Coord(i,i2),false,0);
                }
        }

        static Date()
        {
            int count = 0;
            /*
            //initializam tabloul bidimensional 'Locuri'
            string jsonString = File.ReadAllText("locuri.json");
            Locuri = JsonSerializer.Deserialize<Loc[]>(jsonString, new JsonSerializerOptions { WriteIndented = true });

            jsonString = File.ReadAllText("variabile.json");

            int[] variabile = JsonSerializer.Deserialize<int[]>(jsonString, new JsonSerializerOptions { WriteIndented = true });

            PretIntreg = variabile[0];
            PretIntreg3D = variabile[1];
            PretRedus = variabile[2];
            PretRedus3D = variabile[3];

            */
            /*
            Locuri = new Loc[Randuri * LocuriPeRand];
            for(byte i = 1;i <= Randuri;i++)
                for(byte i2 = 1;i2 <= LocuriPeRand;i2++)
                {
                    Locuri[count++] = new Loc(i,i2);
                }
            */

            /*
            string jsonString = JsonSerializer.Serialize<Loc[]>(Locuri, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\locuri.txt", jsonString);

            int[] variables = new int[4] { PretIntreg, PretIntreg3D, PretRedus, PretRedus3D };
            jsonString = JsonSerializer.Serialize<int[]>(variables, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(@"D:\Visual Studio\Homeworks\EnterpriseApp\EnterpriseApp\variables.txt", "fosfor");

            */


        }

    }
}
