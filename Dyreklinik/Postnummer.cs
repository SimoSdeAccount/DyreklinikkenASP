using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Dyreklinik
{
    class PostNummer
    {
        public PostNummer(SqlConnection c)
        {
            con = c;
        }
        private SqlConnection con;
        private string Postnummer;
        private string By;
        public string GetSetPostNummer
        {
            get { return Postnummer; }
            set { Postnummer = value; }
        }
        public string GetSetBy
        {
            get { return By; }
            set { By = value; }
        }
        public string Insert()
        {
            DataBind insertBind = new DataBind(con);
            return insertBind.Insert("PostNummer", new List<string> { "Postnummer", "Bynavn" }, new List<object> { GetSetPostNummer, GetSetBy }, "Postnummer");;
        }
        public void Update()
        {
            DataBind updateBind = new DataBind(con);
            updateBind.Update("Postnummer", new List<string> { "Bynavn" }, new List<object> { GetSetBy }, "Postnummer", GetSetPostNummer);
        }
        public void Delete()
        {
            DataBind deleteBind = new DataBind(con);
            deleteBind.Delete("PostNummer", "Postnummer", GetSetPostNummer);
        }
        public void Read()
        {
            string selectQuery = "SELECT * FROM PostNummer";
            SqlCommand SelectCmd = new SqlCommand(selectQuery);
            SelectCmd.Connection = con;
            con.Open();
            SqlDataReader readPostnumre = SelectCmd.ExecuteReader();
            while(readPostnumre.Read())
            {
                Console.WriteLine(readPostnumre["Postnummer"]);
                Console.WriteLine(readPostnumre["Bynavn"]);
            }
            readPostnumre.Close();
            con.Close();
        }
    }
}
