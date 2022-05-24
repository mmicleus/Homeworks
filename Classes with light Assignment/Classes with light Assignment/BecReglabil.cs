namespace Light
{
    public class BecReglabil
    {
        public int _Maxim { get; }
        private int _curent;

        public bool _Aprins => _Curent > 0;

        public BecReglabil(int maxim,int curent)
        {
            _Maxim = maxim;
            _Curent = curent;
        }
        
        public int _Curent
        {
            get
            {
                return _curent;
            }
            set
            {
                _curent = Math.Clamp(value, 0, _Maxim);
            }
        }

        public void Aprinde() 
        {
            _Curent = _Maxim;
        }

        public void Stinge()
        {
            _Curent = 0;
        }

        public void MaresteLumina(int putere)
        {
            _Curent = _Curent + putere;
        }

        public void ReduceLumina(int putere)
        {
            _Curent = _Curent - putere;
        }
    }
}
