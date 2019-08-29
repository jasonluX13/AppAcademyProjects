<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="Library.Author" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h1>Author</h1>
    <lib:AuthorList AddAuthorUrl="~/AuthorAdd.aspx" runat="server"></lib:AuthorList>
</asp:Content>
