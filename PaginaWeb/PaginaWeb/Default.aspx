<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PaginaWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Biblioteca Mozart</h1>
        <p class="lead">En esta seccion se muestra una basta colección de libros de diversos autores</p>
    </div>

    <div class="row">
        <div class="col-md-8">
            <h2>Libros registrados </h2>
            <asp:GridView ID="gvdLibros" runat="server" AutoGenerateColumns="true">
            </asp:GridView>
        </div>
        <div class="col-md-8">
            <h2>&nbsp;</h2>
        </div>
    </div>

</asp:Content>
