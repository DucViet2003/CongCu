<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="Nhom3_BanGame.signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Noidung" runat="server">
    <table align="center">
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="txt_Email" runat="server" TextMode="Email"></asp:TextBox>                        
            </td>
        </tr>
        <tr>
            <td>Tài Khoản</td>
            <td>
                <asp:TextBox ID="txt_TK" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mật Khẩu</td>
            <td>
                <asp:TextBox ID="txt_MK" runat="server" TextMode="Password"></asp:TextBox>                        
            </td>
        </tr>                   
        <tr>
            <td colspan="2">
                <asp:Button ID="btnDangKy" runat="server" OnClick="btnDangKy_Click" Text="Đăng Ký" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
