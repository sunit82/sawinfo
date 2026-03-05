using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.YouTube;



namespace MyPages
{
    public partial class Videos : System.Web.UI.Page
    {
        string[,] strArr = {{
                                "gLBE5QAYXp8",
                                 "Story of Stuff, Full Version; How Things Work, About Stuff "
                            },
                            {
                                "421jDx4ROZg",
                                "Pattie Maes & Pranav Mistry: Unveiling the \"Sixth Sense\" "
                            },
                            {
                                "????",
                                "????"
                            }
                           };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("VidName");
                dt.Columns.Add("Title");
                dt.Columns.Add("Desc");
                dt.Columns.Add("Time");

                Google.YouTube.YouTubeRequestSettings objYTReqSettings = new YouTubeRequestSettings("sawinfotech.com",
                    "AI39si5pab85KjS82ppaFueylgB_Od5ytRkvCGh0BKryXcWxL2fRed20PFi6IRKsHylf0x96TkIIUMIv1CyG1C3bZemrJApMVw");
                Google.YouTube.YouTubeRequest objYTRequest = new YouTubeRequest(objYTReqSettings);
                Feed<Video> lstFavVids = objYTRequest.GetFavoriteFeed("sunit82");
                foreach (Video v in lstFavVids.Entries)
                {
                    DataRow dr = dt.NewRow();
                    dr["VidName"] = v.VideoId; //"http://lh3.ggpht.com/_Vx-A-qGl3mQ/SdoB0umTbaE/AAAAAAAAAcQ/gCkroTH9AdE/s144-c/DesertSafari.jpg";
                    string desc = v.Description;
                    //if(desc.Length >200)
                    //    desc =  desc.Substring(0,200) + "...";
                    dr["Desc"] = desc; //"AD Desert Safari";
                    dr["Title"] = v.Title;
                    int time = Convert.ToInt32(v.Media.Duration.Seconds);

                    dr["Time"] = (time / 60).ToString("00") + ":" + (time % 60).ToString("00");

                    dt.Rows.Add(dr);
                }

                DataList1.DataSource = dt;
                DataList1.DataBind();
                ViewState["YouTubeVids"] = dt;

                DataTable dtOrkut = dt.Clone();
                for (int i = 0; i < strArr.Length/2; i++)
                {
                    DataRow dr = dtOrkut.NewRow();
                    dr["VidName"] = strArr[i, 0];
                    dr["Desc"] = "";
                    dr["Title"] = strArr[i,1];
                    dr["Time"] = "--:--";
                    dtOrkut.Rows.Add(dr);
                }

                ViewState["OrkutVids"] = dtOrkut;
                DataTable dtGoogle = dt.Clone();
                ViewState["GoogleVids"] = dtGoogle;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            int tabIndex = 0;
            if (ViewState["vidTabIndex"] != null)
                tabIndex = Convert.ToInt32(ViewState["vidTabIndex"]);
            tabItems.Items[tabIndex].Attributes.Add("ID", "current");
            base.Render(writer);
        }

        protected void tabItems_Click(object sender, BulletedListEventArgs e)
        {
            ViewState["vidTabIndex"] = e.Index;
            DataTable dt;
            switch (e.Index)
            {
                case 1:
                    dt = (DataTable)ViewState["OrkutVids"];
                    break;
                case 2:
                    dt = (DataTable)ViewState["GoogleVids"];
                    break;
                default:
                    dt = (DataTable)ViewState["YouTubeVids"];
                    break;
            }
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}
