using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dyreklinikken
{
    public class DataBind : QueryGenerator
    {
        private SqlConnection con;
        public DataBind(SqlConnection c)
        {
            con = c;
        }
        public string Insert(string insertTabel, List<string> insertKolonner, List<object> insertVærdier, string returnKolonne)
        {
            string insertQuery = GenerateInsertStatement(insertTabel, insertKolonner, returnKolonne);
            SqlCommand InsertCmd = new SqlCommand(insertQuery, con);
            for (int i = 0; i < insertKolonner.Count; i++)
            {
                InsertCmd.Parameters.AddWithValue("@" + insertKolonner[i], insertVærdier[i]);
            }
            return Executer(InsertCmd, false);
        }
        public void Update(string updateTabel, List<string> updateKolonner, List<object> updateVærdier, string BetingelsesKolonne, string Betingelse)
        {
            string UpdateQuery = GenerateUpdateStatement(updateTabel, updateKolonner, BetingelsesKolonne, Betingelse);
            SqlCommand UpdateCmd = new SqlCommand(UpdateQuery, con);
            for (int i = 0; i < updateKolonner.Count; i++)
            {
                UpdateCmd.Parameters.AddWithValue("@" + updateKolonner[i], updateVærdier[i]);
            }
            Executer(UpdateCmd, true);
        }
        public void Update(string updateTabel, List<string> updateKolonner, List<object> updateVærdier, List<string> BetingelsesKolonner, List<string> Betingelser)
        {
            string UpdateQuery = GenerateUpdateStatement(updateTabel, updateKolonner, BetingelsesKolonner, Betingelser);
            SqlCommand UpdateCmd = new SqlCommand(UpdateQuery, con);
            for (int i = 0; i < updateKolonner.Count; i++)
            {
                UpdateCmd.Parameters.AddWithValue("@" + updateKolonner[i], updateVærdier[i]);
            }
            Executer(UpdateCmd, true);
        }
        public void Delete(string deleteTabel, string betingelsesKolonne, string betingelse)
        {
            string deleteQuery = GenerateDeleteStatement(deleteTabel, betingelsesKolonne, betingelse);
            SqlCommand DeleteCmd = new SqlCommand(deleteQuery, con);
            Executer(DeleteCmd, true);
        }
        public void Delete(string Tabel, List<string> BetingelsesKolonner, List<string> Betingelser)
        {
            string deleteQuery = GenerateDeleteStatement(Tabel, BetingelsesKolonner, Betingelser);
            SqlCommand DeleteCmd = new SqlCommand(deleteQuery, con);
            Executer(DeleteCmd, true);
        }
        private string Executer(SqlCommand cmd, bool Void)
        {
            string returVærdi = string.Empty;
            if (Void)
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                returVærdi = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            return returVærdi;
        }
    }
}