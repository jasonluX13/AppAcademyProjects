<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Library.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <asp:TextBox ID="LibraryCardNumber" runat="server" placeholder="LibraryCardNumber"></asp:TextBox>
    <asp:TextBox ID="Password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
    <asp:Button ID="LoginButton" CssClass="btn btn-light" runat="server" OnClick="LoginButton_Click" Text="Login"/>
    <asp:Label ID="ErrorMessage" runat="server" Visible="false" ForeColor="Red">Error, either username or password is incorrect</asp:Label>
</asp:Content>
