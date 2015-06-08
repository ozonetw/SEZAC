<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAniosFiscales.aspx.cs" Inherits="SEZAC.AdminAniosFiscales" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Anios" runat="server">
    <div class="admin_menu">
        <asp:Menu runat="server" Orientation="Horizontal" BackColor="#669900" ForeColor="White" Width="1300px" Font-Size="Large" Font-Underline="True" RenderingMode="List" Font-Names="Tahoma">
    <Items>
        <asp:MenuItem Text="Inicio |" NavigateUrl="~/Admin_Home.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Dependencias |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Encargados |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Años Fiscales |" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Salir |" NavigateUrl="#"></asp:MenuItem>
    </Items>
</asp:Menu>
    <div class="top_header">
        Inicio> Años Fiscales
        <br />
        <br />
    </div>

    </div>
    <div class ="a_container">
        <div class="col_a">
            <asp:Label ID="Label1" runat="server" Text="Año Fiscal:"></asp:Label>
        </div>
        <div class="col_b">
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .a_container {
            margin-left: 498px;
        }
    </style>
</asp:Content>
