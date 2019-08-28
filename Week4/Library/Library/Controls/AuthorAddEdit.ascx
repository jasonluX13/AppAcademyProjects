<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuthorAddEdit.ascx.cs" Inherits="Library.Controls.AuthorAddEdit" %>

<h2>Add Author</h2>

<fieldset>

    <div>
        <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName" Text="First Name: " />
        <asp:TextBox ID="FirstName" runat="server" />
    </div>

    <div>
        <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName" Text="Last Name: " />
        <asp:TextBox ID="LastName" runat="server" />
    </div>

</fieldset>

<div>
    <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
    <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
</div>
