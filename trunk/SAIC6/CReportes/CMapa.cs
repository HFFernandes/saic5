using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BSD.C4.Tlaxcala.Sai
{
    class CMapa
    {
        private int count;
        private CCapa[] capas;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public CCapa[] Capas
        {
            get { return capas; }
            set { capas = value; }
        }
        public CMapa(int _count)
        {
            capas = new CCapa[_count];
            count = _count;
        }        
    }
}
