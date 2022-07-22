﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp
{
    public static class Date
    {
        public const byte LocuriPeRand = 20;

        public const byte Randuri = 20;
        //Pret intreg
        public const byte PretIntreg = 30;

        //Pret intreg cu ochelari 3D
        public const byte PretIntreg3D = 32;

        //Pret redus
        public const byte PretRedus = 20;

        //Pret redus cu ochelari 3D

        public const byte PretRedus3D = 22;

        // public static Loc[,] Locuri;

        public static Loc[] Locuri;

        static Date()
        {
            int count = 0;
            //initializam tabloul bidimensional 'Locuri'
            Locuri = new Loc[Randuri * LocuriPeRand];
            for(byte i = 1;i <= Randuri;i++)
                for(byte i2 = 1;i2 <= LocuriPeRand;i2++)
                {
                    Locuri[count++] = new Loc(i,i2);
                }
        }

    }
}