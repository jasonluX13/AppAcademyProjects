<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="EditLibrary.aspx.cs" Inherits="Library.EditLibrary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:LibraryAddEdit edit="true" LibraryList="~/Library.aspx" runat="server" /> 
</asp:Content>
