using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp
{
    static class ModificarePreturi
    {
        public static string DenumirePret(int alegere)
        {
            switch (alegere)
            {
                case 1:
                    return "Pretul întreg";
                case 2:
                    return "Pretul cu ochelari 3D";
                case 3:
                    return "Pretul redus";
                case 4:
                    return "Pretul redus cu ochelari 3D";
                default:
                    return "";
            }
        }


        public static void SeteazaValoareNoua(int alegere, int valoare)
        {

            switch(alegere)
            {
                case 1:
                    Date.PretIntreg = valoare;
                    break;
                case 2:
                    Date.PretIntreg3D = valoare;
                    break;
                case 3:
                    Date.PretRedus = valoare;

                    break;
                case 4:
                    Date.PretRedus3D = valoare;
                    break;
            }
        }

        public static int ValidareAlegere()
        {
            int alegere;

            do
            {
                Console.Clear();
                Console.WriteLine("1) Modificati pretul întreg\n2) Modificati pretul cu ochelari 3D\n3) Modificati pretul redus\n4) Modificati pretul redus cu ochelari 3D");

                alegere = int.Parse(Console.ReadLine());

            } while (!(alegere == 1 || alegere == 2 || alegere == 3 || alegere == 4));

            return alegere;
        }


        public static int ValidarePretNou(int alegere)
        {
            int valoare;
            do
            {
                Console.Clear();
                Console.WriteLine($"Introduceti noua valoare pentru {DenumirePret(alegere)}:");
                valoare = int.Parse(Console.ReadLine());
            }
            while (!(valoare > 0));

            return valoare;
        }


        public static void ModificaPreturile()
        {
            int alegere;
            int valoare;


            alegere = ValidareAlegere();
            valoare = ValidarePretNou(alegere);

            SeteazaValoareNoua(alegere,valoare);

            Fisiere.UpdateFisierVariables();

            Console.Clear();
            Console.WriteLine($"{DenumirePret(alegere)} este acum egal cu {valoare}");

            Utility.RevenireMenu();
        }
    }
}
