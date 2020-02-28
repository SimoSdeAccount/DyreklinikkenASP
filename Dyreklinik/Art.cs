using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dyreklinik
{
    class Art
    {
        public Art(SqlConnection c)
        {
            con = c;
        }
        private SqlConnection con;
        private int id;
        private string navn;
        public int GetSetId
        {
            get { return id; }
            set { id = value; }
        }
        public string GetSetNavn
        {
            get { return navn; }
            set { navn = value; }
        }
        public string Insert()
        {
            DataBind insertBind = new DataBind(con);
            return insertBind.Insert("Art", new List<string> { "Navn" }, new List<object> { GetSetNavn }, "Id");
        }
        public void Update()
        {
            DataBind updateBind = new DataBind(con);
            updateBind.Update("Art", new List<string> { "Navn" }, new List<object> { GetSetNavn }, "Id", GetSetId.ToString());
        }
        public void Delete()
        {
            DataBind deleteBind = new DataBind(con);
            deleteBind.Delete("Art", "Id", GetSetId.ToString());
        }
    }
}
