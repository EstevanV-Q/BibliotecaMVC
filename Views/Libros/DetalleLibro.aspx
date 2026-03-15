<%@ Page Title="Detalle Libro" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="DetalleLibro.aspx.cs" Inherits="BibliotecaMVC.Views.Libros.DetalleLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detalle del Libro</h2>

    <asp:Label runat="server" Text="Código:" />
    <asp:Label ID="lblCodigo" runat="server" />

    <br />

    <asp:Label runat="server" Text="Título:" />
    <asp:Label ID="lblTitulo" runat="server" />

    <br />

    <asp:Label runat="server" Text="Autor:" />
    <asp:Label ID="lblAutor" runat="server" />

    <br />

    <asp:Label runat="server" Text="Fecha de publicación:" />
    <asp:Label ID="lblFechaPublicacion" runat="server" />

    <br /><br />

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />

</asp:Content>

