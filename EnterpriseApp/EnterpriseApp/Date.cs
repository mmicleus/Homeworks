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
        //numarul de locuri pe un rand
        public const byte LocuriPeRand = 20;
        //numarul de randuri
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

    }
}
