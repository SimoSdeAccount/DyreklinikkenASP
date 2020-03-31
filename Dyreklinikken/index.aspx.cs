using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Dyreklinikken
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection loginCon = new SqlConnection(ConfigurationManager.ConnectionStrings["AnsatteConnection"].ConnectionString);
            string brugernavnStr = BrugernavnTxt.Text;
            string passwordStr = PasswordTxt.Text;
            AnsatteTabelKlasser.AnsatteLogin login = new AnsatteTabelKlasser.AnsatteLogin(loginCon);
            login.BrugernavnGetSet = brugernavnStr;
            login.KodeordGetSet = passwordStr;
            string loginReturn = login.Login();
            if(loginReturn != "Du har indtastet forkerte logininformationer")
            {
                Session["BrugerID"] = loginReturn;
                Response.Redirect("Sider/IntranetForside.aspx");
            }
            else
            {
                loginErrorLabel.Text = loginReturn;
            }
        }
    }
}