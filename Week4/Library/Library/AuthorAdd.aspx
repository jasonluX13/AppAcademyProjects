<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AuthorAdd.aspx.cs" Inherits="Library.AuthorAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:AuthorAddEdit edit="false" authorlist="~/Author.aspx" runat="server"></lib:AuthorAddEdit>
</asp:Content>
