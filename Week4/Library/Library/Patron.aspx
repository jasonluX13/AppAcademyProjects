<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Patron.aspx.cs" Inherits="Library.Patron" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h1>Patron</h1>
    <lib:PatronList id="PatronList" addPatronUrl="~/AddPatron.aspx" runat="server" />
</asp:Content>
