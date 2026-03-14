<%@ Page Title="Consultar Libro" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarLibro.aspx.cs" Inherits="BibliotecaMVC.Views.Libros.ConsultarLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Consultar Libros</h2>

    <asp:Label runat="server" AssociatedControlID="txtFiltro" Text="Filtrar por código o título:" />

    <asp:TextBox ID="txtFiltro" runat="server" />

    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn" />

    <asp:Button ID="btnRefrescar" runat="server" Text="Ver todos" OnClick="btnRefrescar_Click" CssClass="btn" />

    <br />
    <br />

    <asp:GridView ID="gvLibros" runat="server" CssClass="tabla-libros" AutoGenerateColumns="false">

        <Columns>

            <asp:BoundField DataField="Codigo" HeaderText="Código" />
            <asp:BoundField DataField="Titulo" HeaderText="Título" />
            <asp:BoundField DataField="Autor" HeaderText="Autor" />
            <asp:BoundField DataField="FechaPublicacion" HeaderText="Fecha de publicación" DataFormatString="{0:yyyy-MM-dd}" />

            <asp:HyperLinkField HeaderText="Detalle"
                Text="Ver"
                DataNavigateUrlFields="Codigo"
                DataNavigateUrlFormatString="DetalleLibro.aspx?codigo={0}" />

        </Columns>

    </asp:GridView>

</asp:Content>
