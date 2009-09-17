namespace BSD.C4.Tlaxcala.Sai.Mapa
{
    ///<summary>
    ///</summary>
    public class CMapa
    {
        ///<summary>
        ///</summary>
        public int Count { get; set; }

        ///<summary>
        ///</summary>
        public CCapa[] Capas { get; set; }

        ///<summary>
        ///</summary>
        ///<param name="_count"></param>
        public CMapa(int _count)
        {
            Capas = new CCapa[_count];
            Count = _count;
        }
    }
}