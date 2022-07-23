using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseApp
{

    

    static class ModificarePreturi
    {
        public static string denumirePret(int alegere)
        {
            switch (alegere)
            {
                case 1:
                    return "pretul întreg";
                case 2:
                    return "pretul cu ochelari 3D";
                case 3:
                    return "pretul redus";
                case 4:
                    return "pretul redus cu ochelari 3D";
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


            switch (alegere)
            {
                case 1:
                    Console.WriteLine(Date.PretIntreg);
                    break;
                case 2:
                    Console.WriteLine(Date.PretIntreg3D);
                    break;
                case 3:
                    Console.WriteLine(Date.PretRedus);
                    break;
                case 4:
                    Console.WriteLine(Date.PretRedus3D);
                    break;
            }
        }


        public static void ModificaPreturile()
        {
            int alegere;
            bool notValid;
            int valoare;


            do
            {
                Console.WriteLine(@"
1) Modificati pretul întreg
2) Modificati pretul cu ochelari 3D
3) Modificati pretul redus
4) Modificati pretul redus cu ochelari 3D");

                alegere = int.Parse(Console.ReadLine());
                notValid = (alegere == 1 || alegere == 2 || alegere == 3 || alegere == 4) ? false : true;

            }while(notValid);

            do
            {
                Console.WriteLine($"Introduceti noua valoare pentru {denumirePret(alegere)}:");
                valoare = int.Parse(Console.ReadLine());
                notValid = !(valoare > 0); 
            } while (notValid);

            SeteazaValoareNoua(alegere,valoare);

            







            
        }
    }
}
