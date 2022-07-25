//using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnterpriseApp
{
    public class Loc
    {
        //reprezinta randul si coloana locului respectiv
        public Coord Coordonate { get; set; }

        //True daca bilet ptu acest loc a fost deja cumparat, false daca nu
        public bool Ocupat { get; set; }

        //pretul cu care a fost vandut acest bilet
        public int VandutCuPret { get; set; }

        [JsonConstructor]
        public Loc(Coord Coordonate,bool Ocupat,int VandutCuPret)
        {
            this.Coordonate = Coordonate;
            this.Ocupat = Ocupat;
            this.VandutCuPret = VandutCuPret;
        }


    }
}
