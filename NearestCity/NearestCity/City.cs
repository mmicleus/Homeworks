namespace NearestCity
{
    public class City
    {
        public string Name { get; set; }

        public (int x, int y) Coord { get; set; }

        public City(string name,(int x,int y) coord)
        {
            Name = name;
            Coord = coord;
        }
    }
}
