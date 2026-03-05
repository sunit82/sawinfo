using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SAWDAL;
using SAWDAL.Repository;

namespace MyPages
{
    public partial class Default : System.Web.UI.Page
    {
        private const string PAGENAME = "Home";

        public string PageData { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageData = Utility.GetPageContent(PAGENAME);
            }
        }
    }
}
