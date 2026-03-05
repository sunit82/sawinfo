using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SAWDAL;

namespace MyPages
{
    public partial class Profile : System.Web.UI.Page
    {        
        private const string PAGENAME = "Profile";

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
