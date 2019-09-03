<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CheckoutBook.ascx.cs" Inherits="Library.Controls.CheckoutBook" %>

<fieldset>
    <h1>
        <asp:Label ID="AddOrEdit" runat="server"></asp:Label>
    </h1>
    <asp:Label ID="Title" Text="Title: " runat="server"></asp:Label><br />
    <asp:Label ID="Author" Text="Author: " runat="server"></asp:Label><br />
    <asp:Label ID="ISBN" Text="ISBN: " runat="server"></asp:Label><br />
    <asp:Label ID="Library" Text="Library: " runat="server"></asp:Label><br />
    <div>
        <asp:Label ID="PatronsLabel" AssociatedControlID="Patrons" Text="Patrons" runat="server"></asp:Label>
        <asp:DropDownList ID="Patrons" runat="server"></asp:DropDownList>
    </div>

    <div>
        <asp:Button ID="Checkout" class="btn btn-primary" runat="server" Text="Checkout" OnClick="Checkout_Click" />
        <asp:Button ID="Cancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="Cancel_Click" />
    </div>
</fieldset>