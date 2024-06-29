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
    public partial class _default : System.Web.UI.Page
    {
        int SP_ID;
        SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["GioHang"] !=  null)
                {
                    DBClass.tbGioHang = Session["GioHang"] as DataTable;
                }
                else
                {
                    DBClass.tbGioHang.Rows.Clear();
                    DBClass.tbGioHang.Columns.Clear();
                    DBClass.tbGioHang.Columns.Add("idGame", typeof(int));
                    DBClass.tbGioHang.Columns.Add("idTL", typeof(int));
                    DBClass.tbGioHang.Columns.Add("TenGame", typeof(string));
                    DBClass.tbGioHang.Columns.Add("NhaPhatHanh", typeof(string));
                    DBClass.tbGioHang.Columns.Add("Gia", typeof(decimal));
                    DBClass.tbGioHang.Columns.Add("TongTien", typeof(decimal), "Gia * 1");
                }
                lbGiohang.Text = "Giỏ hàng (" + DBClass.tbGioHang.Rows.Count + ")";
                DoGridView();
            }
        }

        private void DoGridView()
        {
            try
            {
                myCon.Open();
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

                    listGames.DataSource = myDr;
                    listGames.DataBind();

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
        protected void lbGiohang_Click(object sender, EventArgs e)
        {
            Response.Redirect("Giohang.aspx");
        }
        protected void listGames_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XemChiTiet")
            {
                SP_ID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ViewGame.aspx?id=" + SP_ID);
            }
        }
    }
}