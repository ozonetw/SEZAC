<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SEZAC.login" MasterPageFile="~/Sezac.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderR" ID="loginform" runat="server">
	<center>
        <p>
            <h2>Bienvenido</h2>
            Por favor ingrese sus credenciales para ingresar al sistema:
        </p>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" OnLoggedIn="Login1_LoggedIn" OnLoginError="Login1_LoginError" />
    </center>
</asp:Content>
