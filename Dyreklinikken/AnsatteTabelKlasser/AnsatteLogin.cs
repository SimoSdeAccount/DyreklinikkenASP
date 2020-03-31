using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dyreklinikken.AnsatteTabelKlasser
{
    public class AnsatteLogin
    {
        public AnsatteLogin(SqlConnection c)
        {
            con = c;
        }
        SqlConnection con;
        private int AnsatteId;
        private string Brugernavn;
        private string Kodeord;
        public int AnsatteIdGetSet
        {
            get { return AnsatteId; }
            set { AnsatteId = value; }
        }
        public string BrugernavnGetSet
        {
            get { return Brugernavn; }
            set { Brugernavn = value; }
        }
        public string KodeordGetSet
        {
            get { return Kodeord; }
            set { Kodeord = value; }
        }
        public string Login()
        {
            string loginReturnStr = string.Empty;
            string LoginVali = "SELECT AnsatID FROM AnsatteLogin WHERE Brugernavn = @Brugernavn AND Kodeord = @Kodeord;";
            SqlCommand loginCmd = new SqlCommand(LoginVali, con);
            loginCmd.Parameters.AddWithValue("@Brugernavn", BrugernavnGetSet);
            loginCmd.Parameters.AddWithValue("@Kodeord", KodeordGetSet);
            try
            {
                con.Open();
                loginReturnStr = loginCmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch
            {
                loginReturnStr = "Du har indtastet forkerte logininformationer";
            }
            return loginReturnStr;
        }
    }
}