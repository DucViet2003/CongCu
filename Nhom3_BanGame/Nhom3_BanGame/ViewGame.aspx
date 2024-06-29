<%@ Page Title="Chi Tiết Sản Phẩm" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewGame.aspx.cs" Inherits="Nhom3_BanGame.ViewGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Noidung" runat="server">
    <div style="text-align: center;">
        <asp:Label ID="lblSanphamNew" runat="server" Text="Thông tin sản phẩm" Font-Size="24px" Font-Bold="true" />
        <asp:Label runat="server" ID="lblIdTL" Visible="false" Font-Size="12px" />
    </div>
    <div class="myrow">
        <div class="mycol-4">
            <asp:Image ID="Image1" runat="server" Width="100%" Height="100%"/>
        </div>

        <div class="mycol-8">
            <asp:Label ID="lblMessage" ForeColor="Red" Font-Bold="true" runat="server" Text="" />
            <table align="center">
                <tr>
                    <td>Tên Game</td>
                    <td>
                        <asp:TextBox ID="txtGameName" runat="server" MaxLength="50" 
                            ToolTip="Tên game"
                            AutoCompleteType="Disabled" placeholder="Tên game" />
                    </td>
                </tr>
                <tr>
                    <td>ID</td>
                    <td>
                        <asp:TextBox ID="txtGameID" runat="server" MaxLength="20" 
                            ToolTip="ID Game"
                            AutoCompleteType="Disabled" placeholder="ID Game" />
                    </td>
                </tr>
                <tr>
                    <td>NPH<td>
                        <asp:TextBox ID="txtNPH" runat="server" MaxLength="20" 
                            ToolTip="Nhà Phát Hành"
                            AutoCompleteType="Disabled" placeholder="Nhà Phát Hành" />
                    </td>
                </tr>
                <tr>
                    <td>Giá bán</td>
                    <td>
                        <asp:TextBox ID="txtDongia" runat="server" MaxLength="20" 
                            ToolTip="Giá bán"
                            AutoCompleteType="Disabled" placeholder="Giá bán sản phẩm" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnThemGioHang" runat="server" 
                            Text="Thêm vào giỏ hàng"
                            Visible="true" CausesValidation="false"
                            OnClick="btnThemGioHang_Click"
                            UseSubmitBehavior="false" />
                        <asp:Button ID="btnClose" runat="server" 
                            Text="Close" CausesValidation="false"
                            OnClick="btnClose_Click"
                            UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
