<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="EditPatron.aspx.cs" Inherits="Library.EditPatron" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:PatronAddEdit edit="true" PatronList="~/Patron.aspx" runat="server" />
</asp:Content>
