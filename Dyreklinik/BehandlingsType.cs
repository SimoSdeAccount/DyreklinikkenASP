using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyreklinik
{
    class BehandlingsType
    {
        private string behandlingsType;
        private int pris;

        public string GetSetBehandlingsType
        {
            get { return behandlingsType; }
            set { behandlingsType = value; }
        }
        public int GetSetPris
        {
            get { return pris; }
            set { pris = value; }
        }
    }
}
