<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AddPatron.aspx.cs" Inherits="Library.AddPatron" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:PatronAddEdit patronlist="~/Patron.aspx" edit="false" runat="server"></lib:PatronAddEdit>
</asp:Content>
