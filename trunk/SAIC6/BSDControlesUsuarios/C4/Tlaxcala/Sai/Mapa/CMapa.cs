namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    public class CMapa
    {
        public int Count { get; set; }

        public CCapa[] Capas { get; set; }

        public CMapa(int _count)
        {
            Capas = new CCapa[_count];
            Count = _count;
        }        
    }
}
