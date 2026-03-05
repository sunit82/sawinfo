using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace MyPages
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string strConn = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" +
                                     Server.MapPath("SAWINFO\\SAWiNFO_Comments.mdb") + ";Mode=ReadWrite;Persist Security Info=False";
                //string strQuery = "SELECT TOP 10 Name, Comment, AddedOn  FROM Comments ORDER BY AddedOn DESC";
                string strQuery = "select * from comments where Issystem = 1 order by addedon desc " +
                " UNION  select top 9 * from comments where Issystem =0 order by addedon desc ";
                OleDbConnection conn = new OleDbConnection(strConn);
                OleDbDataAdapter da = new OleDbDataAdapter(strQuery, conn);

                DataSet ds = new DataSet();
                da.Fill(ds);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                 Server.MapPath("SAWINFO\\SAWiNFO_Comments.mdb") + ";";
                string strQuery = "INSERT INTO Comments (Name, Comment) VALUES " +
                "('" + txtName.Text.Trim() + "','" + txtComment.Text + "')";
                OleDbConnection conn = new OleDbConnection(strConn);
                OleDbCommand cmd = new OleDbCommand(strQuery, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("Contact.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
