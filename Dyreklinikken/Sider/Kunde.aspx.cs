using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dyreklinikken
{
    public partial class Kunde : System.Web.UI.Page
    {
        SqlConnection con;
        static List<object> inputVærdier = new List<object>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Postnumre.Items.Clear();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["KlinikDataConnection"].ConnectionString);
            string allPostnumreQuery = "SELECT Postnummer FROM PostNummer";
            SqlCommand loadAllPostnummerCmd = new SqlCommand(allPostnumreQuery, con);
            con.Open();
            SqlDataReader readPostnumre = loadAllPostnummerCmd.ExecuteReader();
            while (readPostnumre.Read())
            {
                Postnumre.Items.Add(readPostnumre["Postnummer"].ToString());
            }
            readPostnumre.Close();
            con.Close();
            SqlCommand loadKundercmd = new SqlCommand("SELECT * FROM Kunder", con);
            SqlDataAdapter loadKundersda = new SqlDataAdapter();
            DataTable kunderdt = new DataTable();
            loadKundersda.SelectCommand = loadKundercmd;
            loadKundersda.Fill(kunderdt);
            Kundeliste.DataSource = kunderdt;
            Kundeliste.DataBind();
        }
        protected void Kundeliste_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow selectedrow = Kundeliste.SelectedRow;
            navnTxt.Text = HttpUtility.HtmlDecode(selectedrow.Cells[2].Text);
            alderTxt.Text = selectedrow.Cells[3].Text;
            vejTxt.Text = HttpUtility.HtmlDecode(selectedrow.Cells[4].Text);
            telefonTxt.Text = selectedrow.Cells[5].Text;
            emailTxt.Text = HttpUtility.HtmlDecode(selectedrow.Cells[6].Text);
            for (int i = 0; i < Postnumre.Items.Count; i++)
            {
                if(Postnumre.Items[i].Text == selectedrow.Cells[7].Text)
                {
                    Postnumre.Items[i].Selected = true;
                }
            }
            string[] tidspunkt01txtFeltVaerdier = { navnTxt.Text, alderTxt.Text, vejTxt.Text, telefonTxt.Text, emailTxt.Text, Postnumre.SelectedValue };
            if(SubmitList.SelectedItem.Text == "Rediger")
            {
                for (int i = 0; i < tidspunkt01txtFeltVaerdier.Length; i++)
                {
                    inputVærdier.Add(tidspunkt01txtFeltVaerdier[i]);
                }
            }
        }
        protected void SubmitList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(SubmitList.SelectedItem.Text)
            {
                case "Opret": 
                    OpretValgt();
                    VisTekstFelter();
                    break;
                case "Rediger": 
                    OpdaterValgt();
                    VisTekstFelter();
                    break;
                case "Slet": 
                    SletValgt();
                    VisTekstFelter();
                    break;
            }
        }
        private void OpretValgt()
        {
            Kundeliste.Visible = false;
            opretBtn.Visible = true;
            OpdaterBtn.Visible = false;
            SletBtn.Visible = false;
            navnTxt.Text = "Navn";
            alderTxt.Text = "Alder";
            vejTxt.Text = "Vej";
            telefonTxt.Text = "Telefon";
            emailTxt.Text = "Email";
        }
        private void OpdaterValgt()
        {
            Kundeliste.Visible = true;
            OpdaterBtn.Visible = true;
            opretBtn.Visible = false;
            SletBtn.Visible = false;
            clearTekstFelter();
        }
        private void SletValgt()
        {
            Kundeliste.Visible = true;
            SletBtn.Visible = true;
            opretBtn.Visible = false;
            OpdaterBtn.Visible = false;
            clearTekstFelter();
        }
        private void VisTekstFelter()
        {
            navnTxt.Visible = true;
            alderTxt.Visible = true;
            vejTxt.Visible = true;
            telefonTxt.Visible = true;
            emailTxt.Visible = true;
            Postnumre.Visible = true;
        }
        private void clearTekstFelter()
        {
            navnTxt.Text = "";
            alderTxt.Text = "";
            vejTxt.Text = "";
            telefonTxt.Text = "";
            emailTxt.Text = "";
        }
        protected void opretBtn_Click(object sender, EventArgs e)
        {
            Kunder nyKunde = new Kunder(con);
            nyKunde.GetSetNavn = navnTxt.Text;
            nyKunde.GetSetAlder = int.Parse(alderTxt.Text);
            nyKunde.GetSetVej = vejTxt.Text;
            nyKunde.GetSetTelefon = telefonTxt.Text;
            nyKunde.GetSetEmail = emailTxt.Text;
            nyKunde.GetSetPostNummer = Postnumre.SelectedValue;
            nyKunde.Insert();
        }
        protected void opdaterBtn_Click(object sender, EventArgs e)
        {
            List<string> updateKolonner = new List<string>();
            List<string> muligeKolonner = new List<string> { "Navn", "Alder", "Vej", "Telefon", "email", "Postnummer" };
            string[] tidspunkt02FeltVaerdier = { navnTxt.Text, alderTxt.Text, vejTxt.Text, telefonTxt.Text, emailTxt.Text, Postnumre.SelectedValue };
            for (int i = 0; i < tidspunkt02FeltVaerdier.Length; i++)
            {
                if(tidspunkt02FeltVaerdier[i] != inputVærdier[i].ToString())
                {
                    updateKolonner.Add(muligeKolonner[i]);
                }
            }
            Kunder redigerKunde = new Kunder(con);
            GridViewRow selectedrow = Kundeliste.SelectedRow;
            redigerKunde.GetSetId = int.Parse(selectedrow.Cells[1].Text);
            redigerKunde.GetSetNavn = navnTxt.Text;
            redigerKunde.GetSetAlder = int.Parse(alderTxt.Text);
            redigerKunde.GetSetVej = vejTxt.Text;
            redigerKunde.GetSetTelefon = telefonTxt.Text;
            redigerKunde.GetSetEmail = emailTxt.Text;
            redigerKunde.GetSetPostNummer = Postnumre.SelectedValue;
            redigerKunde.Update(updateKolonner);
        }
        protected void sletBtn_Click(object sender, EventArgs e)
        {
            GridViewRow selectedrow = Kundeliste.SelectedRow;
            Kunder sletKunde = new Kunder(con);
            sletKunde.GetSetId = int.Parse(selectedrow.Cells[1].Text);
            sletKunde.Delete();
        }
    }
}