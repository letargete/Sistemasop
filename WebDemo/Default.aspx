<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebDemo._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Proyecto de SISTEMAS DISTRIBUIDOS
    </h2>
    <p>
        Practica de consulta a una base de datos.
    </p>
    <p>
        Consulta en un Grid
    <p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </p>
    </asp:Content>
