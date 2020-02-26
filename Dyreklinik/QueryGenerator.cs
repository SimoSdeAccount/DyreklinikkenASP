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
        protected string GenerateUpdateStatement(string tabel, List<string> kolonner, string conditionColumn, string condition)
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
            string slutProdukt = Segment01 + " WHERE " + conditionColumn + " = " + condition;
            return slutProdukt;
        }
        protected string GenerateDeleteStatement(string tabel, string betingelsesKolonne, string betingelse)
        {
            return "DELETE FROM " + tabel + " WHERE " + betingelsesKolonne + " = " + betingelse;
        }
    }
}
