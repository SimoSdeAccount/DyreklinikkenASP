using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dyreklinik
{
    class Program
    {
        static void Main(string[] args)
        {

            //OpretPostnummer();
            //   OpdaterPostnummer();
            //DeletePostnummer();
            //   OpretKunde();
             UpdateKunde();
          //  DeleteKunde();
            Console.ReadLine();
        }
        static void DeleteKunde()
        {
            Kunder deleteKunde = new Kunder(Con());
            deleteKunde.GetSetId = 2;
            deleteKunde.Delete();
        }
        static void UpdateKunde()
        {
            Kunder updateKunde = new Kunder(Con());
            updateKunde.GetSetNavn = "Karsten";
            updateKunde.GetSetVej = "Karstenvej 2";
            updateKunde.GetSetEmail = "Karsten@Email.dk";
            updateKunde.GetSetId = 3;
            List<string> kolonner = new List<string> { "Navn", "Vej", "email" };
            updateKunde.Update(kolonner);
        }
        static void OpretKunde()
        {
            Kunder nyKunde = new Kunder(Con());
            nyKunde.GetSetNavn = "Matilde";
            nyKunde.GetSetAlder = 22;
            nyKunde.GetSetVej = "Matildevej 2";
            nyKunde.GetSetTelefon = "11223344";
            nyKunde.GetSetEmail = "Matilde@mail.dk";
            nyKunde.GetSetPostNummer = "9000";
            Console.WriteLine(nyKunde.Insert());
        }
    /*    static void OpretPostnummer()
        {
            PostNummer PostNummer = new PostNummer(Con());
            PostNummer.GetSetPostNummer = "6500";
            PostNummer.GetSetBy = "børgeby";
            Console.WriteLine(PostNummer.Insert());
        }
        static void OpdaterPostnummer()
        {
            PostNummer PostNummer = new PostNummer(Con());
            PostNummer.GetSetPostNummer = "6500";
            PostNummer.GetSetBy = "SvendbentBy";
            PostNummer.Update();
        }
        static void DeletePostnummer()
        {
            PostNummer PostNummer = new PostNummer(Con());
            PostNummer.GetSetPostNummer = "6500";
            PostNummer.Delete();
        }*/
        static SqlConnection Con()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DyreKlinikDB"].ConnectionString);;
        }
    }
}
