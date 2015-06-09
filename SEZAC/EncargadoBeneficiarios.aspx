<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncargadoBeneficiarios.aspx.cs" Inherits="SEZAC.EncargadoBeneficiarios" MasterPageFile="~/Sezac.Master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="hi" runat="server">
    <!-- Menu-->
    <div class="menu_en">
        <asp:Menu runat="server" Orientation="Horizontal" BackColor="#669900" ForeColor="White" Width="1300px" Font-Size="Large" Font-Underline="true" RenderingMode="List" Font-Names="Tahoma">
        <Items>
            <asp:MenuItem Text="Inico |" NavigateUrl="~/Admin_Home.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Programas |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Encargados |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Organizaciones |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Beneficiarios |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Historial |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Evaluacion |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Vetados |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Busqueda |" NavigateUrl="#"></asp:MenuItem>
            <asp:MenuItem Text="Salir |" NavigateUrl="#"></asp:MenuItem>
        </Items>
        </asp:Menu>
    </div>
    <!--Barra para la bienvenida de usuario y posicion en el mapa-->
    <div class="top_bar_en">
        <div>
            Inicio > Beneficiarios
        </div>
    </div>
    <!--Contenido-->
    <div class="eb_content">
        <div class="col_one">
            <asp:Image runat="server"/>
            <br />
            <asp:FileUpload runat="server"/>
        </div>
        <div class="col_two">
            <asp:Label Text="RFC" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Nombre" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Apellido Paterno" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Apellido Materno" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Correo Electronico" runat="server"></asp:Label>
            <br />
            <asp:Label Text="Organizacion(es)" runat="server"></asp:Label>
        </div>
        <div class="col_three">
            <asp:TextBox ID="rfcbox" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="namebox" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="paternobox" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="correobox" runat="server"></asp:TextBox>
            <br />
            <div>
                <div class="ception_a">
                    <asp:DropDownList ID="orgalist" runat="server"></asp:DropDownList>
                </div>
                <div class="ception_b">
                    <asp:Button Text=">" runat="server" />
                </div>
                <div class="ception_c">
                    <asp:ListBox ID="orgalistbox" runat="server"></asp:ListBox>
                </div>
            </div>
        </div>
    </div>
    <!--Footer de Confirmación-->
    <div class="confirm">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label Text="Empty" runat="server"></asp:Label>
    </div>



</asp:Content>