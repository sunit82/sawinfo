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
    public partial class Content : System.Web.UI.Page
    {
        private const string PAGENAME = "DefaultContent";

        public string PageData { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["ID"] != null)
                {
                //    DataSet ds = new DataSet();
                //    List<SqlParameter> lstSP = new List<SqlParameter>();
                //    lstSP.Add(new SqlParameter("@PageName", Request["ID"].ToString()));

                //    ds = SAWDB.GetDataset("SAW_GetCMSPageDataByName", CommandType.StoredProcedure,
                //        lstSP);
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        PageData = ds.Tables[0].Rows[0]["PageContent"].ToString();
                //    }
                    string pageName = Request["ID"].ToString();
                    PageData = Utility.GetPageContent(pageName);

                }
                else
                {
                    PageData = Utility.GetPageContent(PAGENAME);
                }
            }
        }

        //private void GetDefaultData()
        //{
        //    DataSet ds = new DataSet();
        //    List<SqlParameter> lstSP = new List<SqlParameter>();
        //    lstSP.Add(new SqlParameter("@PageName", PAGENAME));

        //    ds = SAWDB.GetDataset("SAW_GetCMSPageDataByName", CommandType.StoredProcedure,
        //        lstSP);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        PageData = ds.Tables[0].Rows[0]["PageContent"].ToString();
        //    }
        //}
    }
}
