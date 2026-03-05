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
    public partial class Photos : System.Web.UI.Page
    {
        private const string PAGENAME = "PhotosXML";

        public string PageData { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                PageData = Utility.GetPageContent(PAGENAME);
                ds = new DataSet();
                //string portfolioFilePath = Server.MapPath("Photos.xml");
                ds.ReadXml(new System.IO.StringReader(PageData));
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
            
        }
    }
}
