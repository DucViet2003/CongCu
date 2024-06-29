using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nhom3_BanGame
{
    public partial class Sanpham : System.Web.UI.Page
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
                    lblSanphamNew.Visible = false;
                    lblSanphamUpd.Visible = true;
                    btnAddSanpham.Visible = false;
                    btnUpdSanpham.Visible = true;
                }
                else
                {
                    lblSanphamNew.Visible = true;
                    lblSanphamUpd.Visible = false;
                    btnAddSanpham.Visible = true;
                    btnUpdSanpham.Visible = false;
                }
                GetNhomForDLL();
            }
        }
        private void GetNhomForDLL()
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand cmd = new SqlCommand("dbo.GetTheLoai", myCon))
                {
                    SqlDataReader myDr = cmd.ExecuteReader();

                    ddlTheLoai.DataSource = myDr;
                    ddlTheLoai.DataTextField = "TheLoai";
                    ddlTheLoai.DataValueField = "IdTL";
                    ddlTheLoai.DataBind();
                    ddlTheLoai.Items.Insert(0, new ListItem("-- Chọn thể loại --", "0"));

                    myDr.Close();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in GetNhomForDLL: " + ex.Message; }
            finally { myCon.Close(); }
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
                            txtGameID.Text = Comp_ID.ToString();
                            txtGameName.Text = myDr.GetValue(1).ToString();
                            txtImg.Text = myDr.GetValue(2).ToString();
                            txtNPH.Text = myDr.GetValue(3).ToString();
                            txtDongia.Text = myDr.GetValue(4).ToString();
                            ddlTheLoai.SelectedValue = myDr.GetValue(5).ToString();
                            Image1.ImageUrl = "~/Images/" + myDr.GetValue(2).ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in GetSanpham: " + ex.Message; }
            finally { myCon.Close(); }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Quanly.aspx");
        }
        private void UpdSanpham()
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand cmd = new SqlCommand("dbo.usp_UpdSanpham", myCon))
                {
                    cmd.Connection = myCon;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IDG", SqlDbType.Int).Value = int.Parse(txtGameID.Text);
                    cmd.Parameters.Add("@TenGame", SqlDbType.NVarChar).Value = txtGameName.Text;
                    cmd.Parameters.Add("@Img", SqlDbType.NVarChar).Value = txtImg.Text;
                    cmd.Parameters.Add("@NPH", SqlDbType.NVarChar).Value = txtNPH.Text;
                    cmd.Parameters.Add("@Gia", SqlDbType.Decimal).Value = txtDongia.Text;
                    cmd.Parameters.Add("@IDTL", SqlDbType.Int).Value = ddlTheLoai.SelectedValue;


                    int rows = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in UpdSanpham: " + ex.Message; }
            finally { myCon.Close(); }
        }
        protected void btnUpdSanpham_Click(object sender, EventArgs e)
        {
            UpdSanpham();
            Response.Redirect("Quanly.aspx");
        }
        protected void btnAddSanpham_Click(object sender, EventArgs e)
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM GAME WHERE IdGame = @IdGame", myCon))
                {
                    checkCmd.Parameters.AddWithValue("@IdGame", int.Parse(txtGameID.Text));
                    int existingCount = (int)checkCmd.ExecuteScalar();
                    if (existingCount > 0)
                    {
                        lblMessage.Text = "Trùng ID game. Hãy thử id khác";
                        return;
                    }
                }

                using (SqlCommand myCom = new SqlCommand("dbo.usp_InsSanpham", myCon))
                {
                    myCom.CommandType = CommandType.StoredProcedure;
                    myCom.Parameters.Add("@IDG", SqlDbType.Int).Value = int.Parse(txtGameID.Text);
                    myCom.Parameters.Add("@TenGame", SqlDbType.NVarChar).Value = txtGameName.Text;
                    myCom.Parameters.Add("@Img", SqlDbType.NVarChar).Value = txtImg.Text;
                    myCom.Parameters.Add("@NPH", SqlDbType.NVarChar).Value = txtNPH.Text;
                    myCom.Parameters.Add("@Gia", SqlDbType.Decimal).Value = decimal.Parse(txtDongia.Text);
                    myCom.Parameters.Add("@IDTL", SqlDbType.Int).Value = int.Parse(ddlTheLoai.SelectedValue);

                    myCom.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in btnAddSanpham_Click: " + ex.Message; }
            finally { myCon.Close(); }
            Response.Redirect("Quanly.aspx");
        }
    }
}