using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Serializare2
{
    public class Coord
    {
        public byte Rand { get; set; }

        public byte Coloana { get; set; }

        [JsonConstructor]
        public Coord(byte Rand, byte Coloana)
        {
            this.Rand = Rand;

            this.Coloana = Coloana;
        }

    }

    public class Loc
    {
        //reprezinta randul si coloana locului respectiv
        public Coord Coordonate { get; set; }

        //True daca bilet ptu acest loc a fost deja cumparat, false daca nu
        public bool Ocupat { get; set; }

        //pretul cu care a fost vandut acest bilet
        public int VandutCuPret { get; set; }

        [JsonConstructor]
        public Loc(bool Ocupat,int VandutCuPret,Coord Coordonate)
        {
            this.Coordonate = Coordonate;
            this.Ocupat = Ocupat;
            this.VandutCuPret = VandutCuPret;
        }
    }

    public class Locusor
    {
        //reprezinta randul si coloana locului respectiv
        public byte Rand { get; set; }

        public byte Coloana { get; set;}

        //True daca bilet ptu acest loc a fost deja cumparat, false daca nu
        public bool Ocupat { get; set; }

        //pretul cu care a fost vandut acest bilet
        public int VandutCuPret { get; set; }

        [JsonConstructor]
        public Locusor(byte Rand, byte Coloana, bool Ocupat, int VandutCuPret)
        {
            this.Rand = Rand;
            this.Coloana = Coloana;
            this.Ocupat = Ocupat;
            this.VandutCuPret = VandutCuPret;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Locusor L1 = new Locusor(1, 2, false, 30);
            // Locusor L2 = new Locusor(2, 2, false, 32);
            /*
             Loc L1 = new Loc(false,30, new Coord(1,2));
             Loc L2 = new Loc(false,40, new Coord(2,2));

             Loc[] locuri = new Loc[] { L1, L2 };

             string jsonFormat = JsonSerializer.Serialize<Loc[]>(locuri, new JsonSerializerOptions { WriteIndented = true });

             Console.WriteLine(jsonFormat);

             Loc[] locuriObtinute = JsonSerializer.Deserialize<Loc[]>(jsonFormat);

             Console.WriteLine($"Rand: {locuriObtinute[0].Coordonate.Rand}\nColoana: {locuriObtinute[0].Coordonate.Coloana}   Ocupat:{locuriObtinute[0].Ocupat}   VandutCuPret:{locuriObtinute[0].VandutCuPret}");
             */
            //string jsonString = JsonSerializer.Serialize<Triunghi[]>(trs,new JsonSerializerOptions {WriteIndented = true });


            //string jsonFormat = JsonSerializer.Serialize<int>(Utility.PretIntreg, new JsonSerializerOptions { WriteIndented = true });

            // Console.WriteLine(jsonFormat);

            int[] data = new int[] { Utility.PretIntreg, Utility.PretIntreg3D, Utility.PretRedus, Utility.PretRedus3D };

            string jsonFormat = JsonSerializer.Serialize<int[]>(data, new JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine(jsonFormat);

            int[] locuriObtinute = JsonSerializer.Deserialize<int[]>(jsonFormat);

            for(int i = 0;i < 4;i++)
            {
                Console.WriteLine(locuriObtinute[i]);
            }


        }
    }
}
