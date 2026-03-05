using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using SAWDAL;

namespace MyPages
{
    /// <summary>
    /// Summary description for sawCMS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class sawCMS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public  string GetContentPageList()
        {
            string strResult = string.Empty;
            DataSet ds = new DataSet();
            List<SqlParameter> lstSP = new List<SqlParameter>();
            strResult = "<center><u><b>SAWINFO</b><br/>Updates</u></center><br/>";
            //ds = SAWDB.GetDataset("SAW_GetContentPageList", CommandType.StoredProcedure,
            //    lstSP);


            var data = Utility.GetContentPageList();
            //if (ds.Tables[0].Rows.Count == 0)
            //{
            //    strResult = strResult +
            //        "<p>No new updates.<br/><br/> Keep watching this space for more updates from sawinfotech.com.</p>";
            //}
            //foreach (DataRow dr in ds.Tables[0].Rows)
            //{
            //    strResult = strResult + "- <a href='Content.aspx?ID=" + dr["PageName"].ToString() +
            //        "' >" + dr["PageName"].ToString() + "</a><br/>";
            //}

            if(data.Count == 0)
            {
                strResult = strResult +
                    "<p>No new updates.<br/><br/> Keep watching this space for more updates from sawinfotech.com.</p>";
            }
            foreach (var page in data)
            {
                strResult = strResult + "- <a href='Content.aspx?ID=" + page.PageName +
                    "' >" + page.PageName + "</a><br/>";
            }
            return strResult;
        }
    }
}
