using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nhom3_BanGame
{
    public partial class ViewGame : System.Web.UI.Page
    {
        int SP_ID;
        SqlConnection myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtGameName.Text = "";
                txtGameID.Text = "";
                txtNPH.Text = "";
                txtDongia.Text = "";

                string ma = Request.QueryString["ID"].ToString();
                SP_ID = Convert.ToInt32(ma);
                if (SP_ID > 0)
                {
                    GetSanpham(SP_ID);
                }
            }
        }
        private void GetSanpham(int Comp_ID)
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand myCmd = new SqlCommand("dbo.usp_GetSanpham", myCon))
                {
                    myCmd.Connection = myCon;
                    myCmd.CommandType = CommandType.StoredProcedure;
                    myCmd.Parameters.Add("@ID", SqlDbType.Int).Value = Comp_ID;
                    SqlDataReader myDr = myCmd.ExecuteReader();

                    if (myDr.HasRows)
                    {
                        while (myDr.Read())
                        {
                            txtGameName.Text = myDr.GetValue(1).ToString();
                            txtGameID.Text = Comp_ID.ToString();
                            txtNPH.Text = myDr.GetValue(3).ToString();
                            txtDongia.Text = myDr.GetValue(4).ToString();
                            lblIdTL.Text = myDr.GetValue(5).ToString();
                            Image1.ImageUrl = "~/Images/" + myDr.GetValue(2).ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in GetSanpham: " + ex.Message; }
            finally { myCon.Close(); }
        }
        protected void btnThemGioHang_Click(object sender, EventArgs e)
        {
            int idGame = int.Parse(txtGameID.Text);
            int idTL = int.Parse(lblIdTL.Text);
            string strTenSP = txtGameName.Text;
            string srtNPH = txtNPH.Text;
            decimal Gia = decimal.Parse(txtDongia.Text);
            bool isCheckGioHang = false;

            foreach (DataRow row in DBClass.tbGioHang.Rows) { 
                if ((int)row["idGame"] == idGame)
                {
                    isCheckGioHang = true;
                    break;
                }               
            }
            if (isCheckGioHang)
            {
                lblMessage.Text = "Sản phẩm đã có trong giỏ hàng";
            }
            else
            {
                DBClass.tbGioHang.Rows.Add(idGame, idTL, strTenSP, srtNPH, Gia);
                Session["GioHang"] = DBClass.tbGioHang;
                Response.Redirect("default.aspx");
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}