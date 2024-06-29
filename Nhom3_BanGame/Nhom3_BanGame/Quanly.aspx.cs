using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nhom3_BanGame
{
    public partial class Quanly : System.Web.UI.Page
    {
        int SP_ID;
        SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DoGridView();
            }
        }
        private void DoGridView()
        {
            try
            {
                myCon = DBClass.OpenConn();
                int nhomID = 0;
                if (ListTheLoai.SelectedIndex > -1)
                {
                    nhomID = Convert.ToInt32(ListTheLoai.SelectedItem.Value);
                }
                using (SqlCommand myCom = new SqlCommand("dbo.GetSanPham", myCon))
                {
                    myCom.Parameters.Add("@NhomID", sqlDbType: SqlDbType.VarChar).Value = nhomID;
                    myCom.Connection = myCon;
                    myCom.CommandType = CommandType.StoredProcedure;

                    SqlDataReader myDr = myCom.ExecuteReader();

                    gvGames.DataSource = myDr;
                    gvGames.DataBind();

                    myDr.Close();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in Sanpham doGridView: " + ex.Message; }
            finally { myCon.Close(); }
        }
        protected void ShowNhom(object sender, EventArgs e)
        {
            DoGridView();
        }
        protected void lbNewSanpham_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sanpham.aspx?id=0");
        }
        protected void gvGames_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "UpdSanpham")
            {
                SP_ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Sanpham.aspx?id=" + SP_ID);
            }
        }
        protected void gvGames_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            SP_ID = Convert.ToInt32(gvGames.DataKeys[e.RowIndex].Value.ToString());

            try
            {
                //myCon.Open();
                myCon = DBClass.OpenConn();
                using (SqlCommand cmd = new SqlCommand("dbo.usp_DelSanpham", myCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = SP_ID;
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in gvSanphams_RowDeleting: " + ex.Message; }
            finally { myCon.Close(); }
            DoGridView();
        }
    }
}