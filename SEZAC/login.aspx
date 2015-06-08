<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SEZAC.login" MasterPageFile="~/Sezac.Master"%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="loginform" runat="server">    
    <table border="1" style="width: 100%;">
        <tr>
            <td style="width: 50%;">&nbsp;</td>
            <td style="text-align: center;">
                <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" OnLoggedIn="Login1_LoggedIn" OnLoginError="Login1_LoginError" />
            </td>
            <td style="width: 50%;">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
