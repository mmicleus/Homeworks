using System;

namespace NearestCity
{


    class Program
    {

        public static City Search(string name,City[] cities)
        {
            foreach(City c in cities)
            {
                if (c.Name == name)
                    return c;
            }

            return null;
        }

        public static double GetDistance(City c1, City c2)
        {
            return Math.Sqrt(Math.Pow(c1.Coord.x - c2.Coord.x,2) + Math.Pow(c1.Coord.y - c2.Coord.y, 2));
        }

        public static void Afisare(City[] cities)
        {
            foreach(City c in cities)
            {
                Console.Write($"{c.Name}({c.Coord.x},{c.Coord.y})   ");
            }


            Console.WriteLine();
                
        }


        public static void Main(string[] strs)
        {
            City[] cities = new City[] {
                new City("Chisinau",(70,30)),
                new City("Warsaw",(900,1900)),
                new City("Amsterdam",(500,500)),
                new City("Budapest",(10000,1))
            };
            double[] distances = new double[cities.Length];
            City chosenCity;
            string chosen;


            Console.Write("Cities:");
            Afisare(cities);


            do
            {
                Console.WriteLine("Choose a city from input:");
                chosen = Console.ReadLine();
            } while ((chosenCity = Search(chosen,cities)) == null);

            for (int i = 0; i < cities.Length; i++)
            {
                distances[i] = GetDistance(chosenCity, cities[i]);
                if(distances[i] != 0)
                    Console.WriteLine($"From {chosenCity.Name} to {cities[i].Name}: {distances[i]}");
            }


            double minim = double.MaxValue;
            int index = 0;

            for(int i = 0;i < distances.Length;i++)
            {
                if (distances[i] < minim && distances[i] != 0)
                {
                    minim = distances[i];
                    index = i;
                }
            }


            Console.WriteLine("Nearest City:{0}",cities[index].Name);
            
        }
    }
}
