<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="Library.Library1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h1>Library</h1>
    <lib:LibraryList addLibraryUrl="~/AddLibrary.aspx" runat="server"></lib:LibraryList>
</asp:Content>
