<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sezac.IU.Login" MasterPageFile="~/Sezac.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="loginform" runat="server">
	<center>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" OnLoggedIn="Login1_LoggedIn" OnLoginError="Login1_LoginError" />
    </center>
</asp:Content>
