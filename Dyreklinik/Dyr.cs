using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyreklinik
{
    class Dyr
    {
        private string navn;
        private int alder;
        private int ejerid;
        private int kønid;
        private int artid;

        public string GetSetNavn
        {
            get { return navn; }
            set { navn = value; }
        }
        public int GetSetAlder
        {
            get { return alder; }
            set { alder = value; }
        }
        public int GetSetEjerid
        {
            get { return ejerid; }
            set { ejerid = value; }
        }
        public int GetSetKønId
        {
            get { return kønid; }
            set { kønid = value; }
        }
        public int GetSetArtId
        {
            get { return artid; }
            set { artid = value; }
        }
    }
}
