using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dyreklinik
{
    class DataBind : QueryGenerator
    {
        private SqlConnection con;
        public DataBind(SqlConnection c) {
            con = c;
        }
        public string Insert(string Tabel, List<string> kolonneNavne, List<object> getSetterVærdier, string returnId)
        {
            string insertQuery = GenerateInsertStatement(Tabel, kolonneNavne, returnId);
            SqlCommand InsertCmd = new SqlCommand(insertQuery, con);
            for (int i = 0; i < kolonneNavne.Count; i++)
            {
                InsertCmd.Parameters.AddWithValue("@" + kolonneNavne[i], getSetterVærdier[i]);
            }
            return Executer(InsertCmd, false);
        }
        public void Update(string Tabel, List<string> kolonneNavne, List<object> getSetterVærdier, string BetingelsesKolonne, string Betingelse)
        {
            string UpdateQuery = GenerateUpdateStatement(Tabel, kolonneNavne,  BetingelsesKolonne, Betingelse);
            SqlCommand UpdateCmd = new SqlCommand(UpdateQuery, con);
            for (int i = 0; i < kolonneNavne.Count; i++)
            {
                UpdateCmd.Parameters.AddWithValue("@" + kolonneNavne[i], getSetterVærdier[i]);
            }
            Executer(UpdateCmd, true);
        }
        public void Delete(string Tabel, string BetingelsesKolonne, string Betingelse)
        {
            string deleteQuery = GenerateDeleteStatement(Tabel, BetingelsesKolonne, Betingelse);
            SqlCommand DeleteCmd = new SqlCommand(deleteQuery, con);
            Executer(DeleteCmd, true);
        }
        private string Executer(SqlCommand cmd, bool Void)
        {
            string returner = string.Empty;
            if(Void)
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                con.Open();
                returner = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            return returner;
        }
    }
}
