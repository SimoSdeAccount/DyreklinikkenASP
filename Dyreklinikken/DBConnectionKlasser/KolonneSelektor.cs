using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dyreklinikken
{
    public class KolonneSelektor
    {
        protected List<string> GetUpdateKolonner(List<string> valgtKolonner, List<string> muligeKolonner)
        {
            List<string> UpdateKolonner = new List<string>();
            for (int i = 0; i < valgtKolonner.Count; i++)
            {
                for (int j = 0; j < muligeKolonner.Count; j++)
                {
                    if (valgtKolonner[i] == muligeKolonner[j])
                    {
                        UpdateKolonner.Add(valgtKolonner[i]);
                    }
                }
            }
            return UpdateKolonner;
        }
        protected List<object> GetUpdateVærdier(List<string> valgteKolonner, List<string> muligeKolonner, List<object> muligeVærdier)
        {
            List<object> værdier = new List<object>();
            for (int i = 0; i < valgteKolonner.Count; i++)
            {
                for (int j = 0; j < muligeKolonner.Count; j++)
                {
                    if (valgteKolonner[i] == muligeKolonner[j])
                    {
                        værdier.Add(muligeVærdier[j]);
                    }
                }
            }
            return værdier;
        }
    }
}