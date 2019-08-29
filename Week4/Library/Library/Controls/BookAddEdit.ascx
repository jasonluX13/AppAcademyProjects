<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookAddEdit.ascx.cs" Inherits="Library.Controls.BookAddEdit" %>

<h2>
    <asp:label ID="AddOrEdit" runat="server"></asp:label>
</h2>

<fieldset>

    <div>
        <asp:Label ID="TitleLabel" runat="server" AssociatedControlID="Title" Text="Title: " />
        <asp:TextBox ID="Title" runat="server" />
    </div>

    <div>
        <asp:Label ID="ISBNLabel" runat="server" AssociatedControlID="ISBN" Text="ISBN: " />
        <asp:TextBox ID="ISBN" runat="server" />
    </div>
    <asp:DropDownList ID="Authors" runat="server"  ></asp:DropDownList>

</fieldset>

<div>
    <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
    <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" />
</div>