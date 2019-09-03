<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="EditLibrarian.aspx.cs" Inherits="Library.EditLibrarian" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:LibrarianAddEdit edit="true" LibrarianList="~/Librarian.aspx" runat="server" />
</asp:Content>
