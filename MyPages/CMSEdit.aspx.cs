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
    public partial class CMSEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Administrator"))
            {
                Response.Redirect("Login.aspx");
            }
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                if (Session["CMS_Page_Edit"] != null)
                {
                    DataSet ds = new DataSet();
                    List<SqlParameter> lstSP = new List<SqlParameter>();
                    lstSP.Add(new SqlParameter("@PageId", Session["CMS_Page_Edit"].ToString()));

                    ds = SAWDB.GetDataset("SAW_GetCMSPageData", CommandType.StoredProcedure,
                        lstSP);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPageName.Text = ds.Tables[0].Rows[0]["PageName"].ToString();
                        txtPageContent.Text = ds.Tables[0].Rows[0]["PageContent"].ToString();
                        chkIsSubContent.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsSubContent"].ToString());
                        if (chkIsSubContent.Checked)
                            txtPageName.ReadOnly = false;
                        else
                            txtPageName.ReadOnly = true;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int pageId = 0;
            if (Session["CMS_Page_Edit"] != null)
            {
                pageId = Convert.ToInt32(Session["CMS_Page_Edit"]);
            }
            List<SqlParameter> lstSP = new List<SqlParameter>();
            lstSP.Add(new SqlParameter("@PageId", pageId));
            lstSP.Add(new SqlParameter("@PageName", txtPageName.Text.Trim()));
            lstSP.Add(new SqlParameter("@PageContent", txtPageContent.Text.Trim()));
            lstSP.Add(new SqlParameter("@IsSubContent", chkIsSubContent.Checked));
            lstSP.Add(new SqlParameter("@UserId", this.User.Identity.Name));
            lstSP.Add(new SqlParameter("@ModifiedOn", DateTime.Now));
            SqlParameter pageIdOut = new SqlParameter("@PageIdOut", this.User.Identity.Name);
            pageIdOut.Direction = ParameterDirection.Output;
            pageIdOut.DbType = DbType.Int32;
            lstSP.Add(pageIdOut);
            int rec = SAWDB.Excecute("SAW_SaveCMSPage", CommandType.StoredProcedure, lstSP);
            if (rec > 0)
            {
                Session["CMS_Page_Edit"] = SAWDB.cmd.Parameters["@PageIdOut"].Value.ToString();
                lblMessage.Text = "Data Saved Successfully";
            }

        }
    }
}
