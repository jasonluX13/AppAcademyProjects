<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="Library.Book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h1>Book</h1>
    <lib:bookaddedit BookList="~/Book.aspx" edit="false" runat="server" />
    <lib:booklist id="Booklist" AddBookUrl="~/AddBook.aspx" runat="server"></lib:booklist>
</asp:Content>
