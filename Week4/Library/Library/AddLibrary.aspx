<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="AddLibrary.aspx.cs" Inherits="Library.AddLibrary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:LibraryAddEdit edit="false" librarylist="~/Library.aspx" runat="server" />
</asp:Content>
