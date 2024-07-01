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
    public partial class signin : System.Web.UI.Page
    {
        private SqlConnection myCon;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                myCon = DBClass.OpenConn();
                using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE TenTK = @TENTK", myCon))
                {
                    checkCmd.Parameters.AddWithValue("@TENTK", txt_TKdk.Text);
                    int existingCount = (int)checkCmd.ExecuteScalar();
                    if (existingCount > 0)
                    {
                        lblMessage.Text = "Tên tài khoản đã tồn tại, vui lòng chọn tên khác";
                        return;
                    }
                }

                using (SqlCommand myCom = new SqlCommand("dbo.usp_InsTaiKhoan", myCon))
                {
                    myCom.CommandType = CommandType.StoredProcedure;
                    myCom.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = txt_Email.Text;
                    myCom.Parameters.Add("@TENTK", SqlDbType.NVarChar).Value = txt_TKdk.Text;
                    myCom.Parameters.Add("@MATKHAU", SqlDbType.NVarChar).Value = txt_MKdk.Text;
                    myCom.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { lblMessage.Text = "Error in btnDangKy_Click: " + ex.Message; }
            finally { myCon.Close(); }
            Response.Redirect("login.aspx");
        }
    }
}