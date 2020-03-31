using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyreklinikken
{
    public partial class MenuMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ForsideBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("IntranetForside.aspx");
        }
        protected void KundeBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("Kunde.aspx");
        }
        protected void BehandlingBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("Behandling.aspx");
        }
        protected void PatientBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("Patient.aspx");
        }
        protected void FakturaBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("Faktura.aspx");
        }
        protected void HistorikBtnClick(object sender, EventArgs e)
        {
            Response.Redirect("Historik.aspx");
        }
        protected void LogUdBtnClick(object sender, EventArgs e)
        {

        }
    }
}