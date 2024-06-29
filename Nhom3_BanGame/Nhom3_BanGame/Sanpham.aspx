<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Sanpham.aspx.cs" Inherits="Nhom3_BanGame.Sanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Noidung" runat="server">
    <div style="text-align: center;">
        <asp:Label ID="lblSanphamNew" runat="server" Text="Thêm sản phẩm mới" Font-Size="24px" Font-Bold="true" />
        <asp:Label ID="lblSanphamUpd" runat="server" Text="Cập nhật sản phẩm" Font-Size="24px" Font-Bold="true" />
        <asp:Label runat="server" ID="lblSPID" Visible="true" Font-Size="12px" />
    </div>
    <div class="myrow">   
        <div class="mycol-4">
            <asp:Image ID="Image1" runat="server" Width="100%" Height="100%"/>
        </div>

        <div class="mycol-8">      
            <asp:Label ID="lblMessage" ForeColor="Red" Font-Bold="true" runat="server" Text="" />
            <table align="center">
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>

                <tr>
                    <td>ID</td>
                    <td>
                        <asp:TextBox ID="txtGameID" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                            ToolTip="ID Game"
                            AutoCompleteType="Disabled" placeholder="ID Game" />
                    </td>
                </tr>

                <tr>
                    <td>Tên Game</td>
                    <td>
                        <asp:TextBox ID="txtGameName" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                            ToolTip="Tên game"
                            AutoCompleteType="Disabled" placeholder="Tên game" />
                    </td>
                </tr>

                 <tr>
                     <td>URL Img</td>
                     <td>
                         <asp:TextBox ID="txtImg" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                             ToolTip="Link ảnh"
                             AutoCompleteType="Disabled" placeholder="Link ảnh" />
                     </td>
                 </tr>

                <tr>
                    <td>NPH</td>
                    <td>
                        <asp:TextBox ID="txtNPH" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                            ToolTip="Nhà phát hành"
                            AutoCompleteType="Disabled" placeholder="Nhà phát hành" />
                    </td>
                </tr>

                <tr>
                    <td>Giá bán</td>
                    <td>
                        <asp:TextBox ID="txtDongia" runat="server" MaxLength="255" CssClass="form-control input-xs" 
                            ToolTip="Giá bán"
                            AutoCompleteType="Disabled" placeholder="Giá bán sản phẩm" />
                    </td>
                </tr>

                <tr>
                    <td>Thể loại</td>
                    <td>
                        <asp:DropDownList ID="ddlTheLoai" runat="server" CssClass="form-control input-xs" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAddSanpham" runat="server" class="btn btn-info button-xs" data-dismiss="modal" 
                            Text="Thêm mới"
                            Visible="true" CausesValidation="false"
                            OnClick="btnAddSanpham_Click"
                            UseSubmitBehavior="false" />
                        <asp:Button ID="btnUpdSanpham" runat="server" class="btn btn-info button-xs" data-dismiss="modal" 
                            Text="Cập nhật"
                            Visible="false" CausesValidation="false"
                            OnClick="btnUpdSanpham_Click"
                            UseSubmitBehavior="false" />
                        <asp:Button ID="btnClose" runat="server" class="btn btn-danger button-xs" data-dismiss="modal" 
                            Text="Close" CausesValidation="false"
                            OnClick="btnClose_Click"
                            UseSubmitBehavior="false" />
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblModalMessage" runat="server" ForeColor="Red" Font-Size="12px" Text="" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
