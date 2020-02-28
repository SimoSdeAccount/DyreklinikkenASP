using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyreklinik
{
    class QueryGenerator
    {
        protected string GenerateInsertStatement(string tabel, List<string> kolonner, string returnId)
        {
            string segment01 = "INSERT INTO " + tabel + " (";
            for (int i = 0; i < kolonner.Count; i++)
            {
                if (i != kolonner.Count - 1)
                {
                    segment01 += kolonner[i] + ", ";
                }
                else
                {
                    segment01 += kolonner[i];
                }
            }
            string segment02 = segment01 + ") OUTPUT INSERTED."+returnId+" VALUES (";
            for (int i = 0; i < kolonner.Count; i++)
            {
                if (i != kolonner.Count - 1)
                {
                    segment02 += "@" + kolonner[i] + ", ";
                }
                else
                {
                    segment02 += "@" + kolonner[i];
                }
            }
            string slutProdukt = segment02 + ");";
            return slutProdukt;
        }
        protected string GenerateUpdateStatement(string tabel, List<string> kolonner, string betingelsesKolonner, string betingelser)
        {
            string Segment01 = "UPDATE " + tabel + " SET " ;
            for (int i = 0; i < kolonner.Count; i++)
            {
                if (i != kolonner.Count - 1)
                {
                    Segment01 += kolonner[i] + "=" + "@" + kolonner[i] + ", ";
                }
                else
                {
                    Segment01 += kolonner[i] + "=" + "@" + kolonner[i];
                }
            }
            string slutProdukt = Segment01 + " WHERE " + betingelsesKolonner + " = " + betingelser;
            return slutProdukt;
        }
        protected string GenerateUpdateStatement(string tabel, List<string> kolonner, List<string> betingelsesKolonner, List<string> betingelser)
        {
            string Segment01 = "UPDATE " + tabel + " SET ";
            for (int i = 0; i < kolonner.Count; i++)
            {
                if (i != kolonner.Count - 1)
                {
                    Segment01 += kolonner[i] + "=" + "@" + kolonner[i] + ", ";
                }
                else
                {
                    Segment01 += kolonner[i] + "=" + "@" + kolonner[i];
                }
            }
            string Segment02 = Segment01 + " WHERE ";
            for (int i = 0; i < betingelsesKolonner.Count; i++)
            {
                if(i != betingelsesKolonner.Count - 1)
                {
                    Segment02 += betingelsesKolonner[i] + " = " + betingelser[i] + " AND ";
                }
                else
                {
                    Segment02 += betingelsesKolonner[i] + " = " + betingelser[i];
                }
            }
            return Segment02;
        }
        protected string GenerateDeleteStatement(string tabel, string betingelsesKolonne, string betingelse)
        {
            return "DELETE FROM " + tabel + " WHERE " + betingelsesKolonne + " = " + betingelse;
        }
    }
}
