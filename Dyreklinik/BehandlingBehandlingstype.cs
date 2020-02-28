using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dyreklinik
{
    class BehandlingBehandlingstype : KolonneSelektor
    {
        public BehandlingBehandlingstype(SqlConnection c)
        {
            con = c;
        }
        private SqlConnection con;
        private int behandlingId;
        private string behandlingsType;
        private static List<string> Kolonner = new List<string> { "BehandlingId", "Behandlingstype"};
        public int GetSetBehandlingId
        {
            get { return behandlingId; }
            set { behandlingId = value; }
        }
        public string GetSetBehandlingsType
        {
            get { return behandlingsType; }
            set { behandlingsType = value; }
        }
        public string Insert()
        {
            List<object> getSetters = new List<object> { GetSetBehandlingId, GetSetBehandlingsType};
            DataBind insertBind = new DataBind(con);
            return insertBind.Insert("BehandlingBehandlingsType", Kolonner, getSetters, "BehandlingId");
        }
        public void Update(List<string> kolonner, List<string> betingelser)
        {
            List<string> UpdateKolonner = GetUpdateKolonner(kolonner, Kolonner);
            List<object> UpdateGetSetters = GetUpdateGetSetters(kolonner, Kolonner, new List<object> { GetSetBehandlingId, GetSetBehandlingsType });
            DataBind updateBind = new DataBind(con);
            updateBind.Update("BehandlingBehandlingsType", UpdateKolonner, UpdateGetSetters, new List<string> {"BehandlingId", "Behandlingstype" }, betingelser);
        }
        public void Delete()
        {
            DataBind deleteBind = new DataBind(con);
            deleteBind.Delete("BehandlingBehandlingsType", "BehandlingId", GetSetBehandlingId.ToString());
        }
    }
}
