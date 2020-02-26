using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyreklinik
{
    class Behandling
    {
        private string dato;
        private string tid;
        private int dyrid;
        public string GetSetDato
        {
            get { return dato; }
            set { dato = value; }
        }
        public string GetSetTid
        {
            get { return tid; }
            set { tid = value; }
        }
        public int GetSetDyrId
        {
            get { return dyrid; }
            set { dyrid = value; }
        }
    }
}
