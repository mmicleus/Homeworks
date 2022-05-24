using System;
using System.Linq;

namespace Light
{
    public class Program
   {
        public static void AfisareStare(Candelabru cd, Candelabru cd2)
        {
            if (cd._Aprins)
                Console.WriteLine("Candelabru 1 e aprins");
            else
                Console.WriteLine("Candelabru 1 e stins");

            if (cd2._Aprins)
                Console.WriteLine("Candelabru 2 e aprins");
            else
                Console.WriteLine("Candelabru 2 e stins");
        }
        public static void Main(string[] strs)
        {
            Candelabru cd = new Candelabru(60,75,100);

            Candelabru cd2 = new Candelabru(40,60,75,75,100);


            
            AfisareStare(cd, cd2);
            

            Console.WriteLine($"Putere Maxima Candelabru 1:{cd._PutereMaxima}\nPutere Maxima Candelabru 2:{cd2._PutereMaxima}");

            cd.Aprinde();
            cd2.Aprinde();

            AfisareStare(cd, cd2);


            Console.WriteLine($"Putere Curenta Candelabru 1:{cd._PutereCurenta}\nPutere Curenta Candelabru 2:{cd2._PutereCurenta}");

            cd.Stinge();
            cd2.Stinge();

            AfisareStare(cd, cd2);

            cd.MaresteLumina(80);
            cd2.MaresteLumina(80);

            AfisareStare(cd, cd2);


            Console.WriteLine($"Putere Curenta Candelabru 1:{cd._PutereCurenta}\nPutere Curenta Candelabru 2:{cd2._PutereCurenta}");


            cd.ReduceLumina(50);
            cd2.ReduceLumina(50);


            AfisareStare(cd, cd2);


            Console.WriteLine($"Putere Curenta Candelabru 1:{cd._PutereCurenta}\nPutere Curenta Candelabru 2:{cd2._PutereCurenta}");
           
        }
   }
}
