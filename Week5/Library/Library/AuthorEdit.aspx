<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AuthorEdit.aspx.cs" Inherits="Library.AuthorEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:AuthorAddEdit edit="true" authorlist="~/Author.aspx" runat="server" />
</asp:Content>
