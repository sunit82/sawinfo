using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyPages
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string ResolvePath 
        {
            get
            {
                return Page.ResolveUrl("~/");
            }
        }
        public string WriteLogURl
        {
            get
            {
                return @"""background: url('" + Page.ResolveUrl("~/images/logo.jpg") + @"') no-repeat;""";
            }
        }
        public string MasterMessage
        {            
            set
            {
                lblMasterMessage.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = ResolvePath;
            MasterMessage = "";
            if (Session["NotAdminLoggedIN"] != null)
            {
                bool b = (bool)Session["NotAdminLoggedIN"];
                if (b)
                {
                    MasterMessage = "Only Administrators can access SAWCMS";
                    Session["NotAdminLoggedIN"] = false;
                }
            }
        }
    }
}
