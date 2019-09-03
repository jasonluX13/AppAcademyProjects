<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Librarian.aspx.cs" Inherits="Library.Librarian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:LibrarianAddEdit edit="false" runat="server"></lib:LibrarianAddEdit>
    <lib:LibrarianList runat="server"></lib:LibrarianList>
</asp:Content>
