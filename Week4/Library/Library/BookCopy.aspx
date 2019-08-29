<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="BookCopy.aspx.cs" Inherits="Library.BookCopy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:BookCopyAddEdit edit="false" BookCopyList="~/BookCopy.aspx" runat="server" />
    <lib:BookCopyList runat="server" />
</asp:Content>
