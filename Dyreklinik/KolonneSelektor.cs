using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyreklinik
{
    class KolonneSelektor
    {
        protected List<string> GetUpdateKolonner(List<string> kolonner, List<string> muligeKolonner)
        {
            List<string> UpdateKolonner = new List<string>();
            for (int i = 0; i < kolonner.Count; i++)
            {
                for (int j = 0; j < muligeKolonner.Count; j++)
                {
                    if (kolonner[i] == muligeKolonner[j])
                    {
                        UpdateKolonner.Add(kolonner[i]);
                    }
                }
            }
            return UpdateKolonner;
        }
        protected List<object> GetUpdateGetSetters(List<string> valgteKolonner, List<string> muligeKolonner, List<object> getSetters)
        {
            List<object> UpdateGetSetters = new List<object>();
            for (int i = 0; i < valgteKolonner.Count; i++)
            {
                for (int j = 0; j < muligeKolonner.Count; j++)
                {
                    if (valgteKolonner[i] == muligeKolonner[j])
                    {
                        UpdateGetSetters.Add(getSetters[j]);
                    }
                }
            }
            return UpdateGetSetters;
        }
    }
}
