using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nhom3_BanGame
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnDangNhap_Click(object sender, EventArgs e)
        {

            SqlConnection myCon = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString);
            myCon.Open();
            string qry = "SELECT * FROM TaiKhoan WHERE TenTK ='" + txt_TK.Text + "' AND MatKhau ='" + txt_MK.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, myCon);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Session["username"] = txt_TK.Text;
                Response.Redirect("default.aspx");
            }
            else
            {
                Label1.Text = "Tài khoản hoặc mật khẩu không đúng!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}