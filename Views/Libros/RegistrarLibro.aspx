<%@ Page Title="Registrar Libro" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarLibro.aspx.cs" Inherits="BibliotecaMVC.Views.Libros.RegistrarLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Registrar Libro</h2>

    <asp:Label runat="server" AssociatedControlID="txtCodigo" Text="Código:" />
    <asp:TextBox ID="txtCodigo" runat="server"/>

    <br />

    <asp:Label runat="server" AssociatedControlID="txtTitulo" Text="Título:"/>
    <asp:TextBox ID="txtTitulo" runat="server"/>

    <br />

    <asp:Label runat="server" AssociatedControlID="txtAutor" Text="Autor:"/>
    <asp:TextBox ID="txtAutor" runat="server"/>

    <br />

    <asp:Label runat="server" AssociatedControlID="txtFechaPublicacion" Text="Fecha de publicación (yyyy-mm-dd):"/>
    <asp:TextBox ID="txtFechaPublicacion" runat="server" />
    <br />

    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="btn"/>

    <br />
    <br />

    <asp:Label ID="lblMensaje" runat="server" />

</asp:Content>
