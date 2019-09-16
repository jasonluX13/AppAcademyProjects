<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="BookEdit.aspx.cs" Inherits="Library.BookEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:bookaddedit booklist="~/Book.aspx" edit="true" runat="server"></lib:bookaddedit>
</asp:Content>
