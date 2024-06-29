using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nhom3_BanGame
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = (string)Session["username"];
            if (user == "admin")
                Quanly.Visible = true;
            else Quanly.Visible = false;
            if (string.IsNullOrEmpty(user) == false)
            {
                LoginBtn.Visible = false;
                LogouBtn.Visible = true;
                SignInBtn.Visible = false;
                CurrentUser.Text = user;
            }
            else
            {
                LoginBtn.Visible = true;
                LogouBtn.Visible = false;
                SignInBtn.Visible = true;
                CurrentUser.Text = "";
            }
        }
        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Response.Redirect("default.aspx");

        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            Response.Redirect("signin.aspx");
        }
    }
}