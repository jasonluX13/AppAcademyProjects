<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="EditBookCopy.aspx.cs" Inherits="Library.EditBookCopy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <lib:BookCopyAddEdit edit="true" BookCopyList="~/BookCopy.aspx" runat="server" />
</asp:Content>
