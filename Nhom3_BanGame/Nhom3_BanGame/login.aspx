<%@ Page Title="Đăng Nhập" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Nhom3_BanGame.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Noidung" runat="server">
    <table align="center">
        <tr>
            <td colspan="2">&nbsp;</td>
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
                <asp:Button ID="btnDangNhap" runat="server" OnClick="btnDangNhap_Click" Text="Đăng Nhập" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
