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

        public Loc(byte rand,byte coloana)
        {
            Coordonate = new Coord(rand, coloana);
            Ocupat = false;
        }


    }
}
