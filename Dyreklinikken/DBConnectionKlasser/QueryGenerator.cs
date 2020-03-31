using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dyreklinikken
{
    public class QueryGenerator
    {
        protected string GenerateInsertStatement(string insertTabel, List<string> insertKolonner, string returnKolonne)
        {
            string insertQuery = "INSERT INTO " + insertTabel + " (";
            for (int i = 0; i < insertKolonner.Count; i++)
            {
                if (i != insertKolonner.Count - 1)
                {
                    insertQuery += insertKolonner[i] + ", ";
                }
                else
                {
                    insertQuery += insertKolonner[i];
                }
            }
            insertQuery = insertQuery + ") OUTPUT INSERTED." + returnKolonne + " VALUES (";
            for (int i = 0; i < insertKolonner.Count; i++)
            {
                if (i != insertKolonner.Count - 1)
                {
                    insertQuery += "@" + insertKolonner[i] + ", ";
                }
                else
                {
                    insertQuery += "@" + insertKolonner[i];
                }
            }
            insertQuery = insertQuery + ");";
            return insertQuery;
        }
        protected string GenerateUpdateStatement(string updateTabel, List<string> updateKolonner, string betingelsesKolonne, string betingelse)
        {
            string updateQuery = "UPDATE " + updateTabel + " SET ";
            for (int i = 0; i < updateKolonner.Count; i++)
            {
                if (i != updateKolonner.Count - 1)
                {
                    updateQuery += updateKolonner[i] + "=" + "@" + updateKolonner[i] + ", ";
                }
                else
                {
                    updateQuery += updateKolonner[i] + "=" + "@" + updateKolonner[i];
                }
            }
            updateQuery = updateQuery + " WHERE " + betingelsesKolonne + " = " + betingelse;
            return updateQuery;
        }
        protected string GenerateUpdateStatement(string updateTabel, List<string> updateKolonner, List<string> betingelsesKolonner, List<string> betingelser)
        {
            string updateQuery = "UPDATE " + updateTabel + " SET ";
            for (int i = 0; i < updateKolonner.Count; i++)
            {
                if (i != updateKolonner.Count - 1)
                {
                    updateQuery += updateKolonner[i] + "=" + "@" + updateKolonner[i] + ", ";
                }
                else
                {
                    updateQuery += updateKolonner[i] + "=" + "@" + updateKolonner[i];
                }
            }
            updateQuery = updateQuery + " WHERE ";
            for (int i = 0; i < betingelsesKolonner.Count; i++)
            {
                if (i != betingelsesKolonner.Count - 1)
                {
                    updateQuery += betingelsesKolonner[i] + " = " + betingelser[i] + " AND ";
                }
                else
                {
                    updateQuery += betingelsesKolonner[i] + " = " + betingelser[i];
                }
            }
            return updateQuery;
        }
        protected string GenerateDeleteStatement(string deleteTabel, string betingelsesKolonne, string betingelse)
        {
            return "DELETE FROM " + deleteTabel + " WHERE " + betingelsesKolonne + " = " + betingelse;
        }
        protected string GenerateDeleteStatement(string deleteTabel, List<string> betingelsesKolonner, List<string> betingelser)
        {
            string deleteQuery = "DELETE FROM " + deleteTabel + " WHERE ";
            for (int i = 0; i < betingelsesKolonner.Count; i++)
            {
                if (i != betingelsesKolonner.Count - 1)
                {
                    deleteQuery += betingelsesKolonner[i] + " = " + betingelser[i] + " AND ";
                }
                else
                {
                    deleteQuery += betingelsesKolonner[i] + " = " + betingelser[i];
                }
            }
            return deleteQuery;
        }
    }
}