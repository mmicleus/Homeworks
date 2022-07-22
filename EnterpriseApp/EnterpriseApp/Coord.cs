namespace EnterpriseApp
{
    public class Coord
    {
        public byte Rand { get; set; }

        public byte Coloana { get; set; }

        public Coord(byte rand,byte coloana)
        {
            this.Rand = rand;

            this.Coloana = coloana;
        }

    }
}
