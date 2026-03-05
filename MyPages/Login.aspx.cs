using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace MyPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            
            if (!Roles.IsUserInRole(Login1.UserName,"Administrator"))
            {
                Session["NotAdminLoggedIN"] = true;
            }
            else
            {
                Response.Redirect("CMSList.aspx");
            }
        }

    }
}
