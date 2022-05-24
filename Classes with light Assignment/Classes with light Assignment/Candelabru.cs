namespace Light
{
    public class Candelabru
    {
        public BecReglabil[] _Becuri { get; set; }
        public bool _Aprins => _Becuri.Any(x => x._Aprins == true);
        public int _PutereCurenta => _Becuri.Sum(x => x._Curent);
        public int _PutereMaxima => _Becuri.Sum(x => x._Maxim);


        public Candelabru(params int[] valori)
        {
            _Becuri = new BecReglabil[valori.Length];

            for(int i = 0;i < _Becuri.Length;i++)
            {
                _Becuri[i] = new BecReglabil(valori[i],0);
            }
        }

        public void Aprinde()
        {
            foreach (BecReglabil b in _Becuri)
                b.Aprinde();
        }

        public void Stinge()
        {
            foreach (BecReglabil b in _Becuri)
                b.Stinge();
        }

        public void MaresteLumina(int putere)
        {
            foreach (BecReglabil b in _Becuri)
                b.MaresteLumina(putere);
        }

        public void ReduceLumina(int putere)
        {
            foreach (BecReglabil b in _Becuri)
                b.ReduceLumina(putere);
        }
    }
}
