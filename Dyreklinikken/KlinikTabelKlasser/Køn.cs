﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dyreklinikken
{
    public class Køn
    {
        public Køn(SqlConnection c)
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
            return insertBind.Insert("Køn", new List<string> { "Navn" }, new List<object> { GetSetNavn }, "Id");
        }
        public void Update()
        {
            DataBind updateBind = new DataBind(con);
            updateBind.Update("Køn", new List<string> { "Navn" }, new List<object> { GetSetNavn }, "Id", GetSetId.ToString());
        }
        public void Delete()
        {
            DataBind deleteBind = new DataBind(con);
            deleteBind.Delete("Køn", "Id", GetSetId.ToString());
        }
    }
}