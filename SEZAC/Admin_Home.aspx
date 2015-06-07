<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Home.aspx.cs" Inherits="SEZAC.Admin_Home" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="adminhomeform" runat="server">
<asp:Menu runat="server">
    <Items>
        <asp:MenuItem Text="Inicio" NavigateUrl="~/Admin_Home.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Dependencias" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Encargados" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Años" NavigateUrl="#"></asp:MenuItem>
        <asp:MenuItem Text="Salir" NavigateUrl="#"></asp:MenuItem>
    </Items>

</asp:Menu>
</asp:Content>