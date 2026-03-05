using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;

namespace MyPages
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Administrator"))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SmtpClient objSMTP = new SmtpClient("smtpserver_name", 25);
            objSMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
            objSMTP.Timeout = 600000;
            objSMTP.Credentials = new System.Net.NetworkCredential("username", "password");
             
            MailMessage objMsg = new MailMessage(txtFrom.Text, txtTo.Text, txtSubject.Text, txtBody.Text);
            objMsg.CC.Add(txtCC.Text);
            objMsg.Bcc.Add(txtBCC.Text);
            objSMTP.Send(objMsg);
        }
    }
}
