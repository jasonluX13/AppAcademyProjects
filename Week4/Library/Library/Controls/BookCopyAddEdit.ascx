<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookCopyAddEdit.ascx.cs" Inherits="Library.Controls.BookCopyAddEdit" %>


<fieldset>
    <h2>
        <asp:Label ID="AddOrEdit" runat="server"></asp:Label>
    </h2>
    <asp:Label ID="BooksLabel" AssociatedControlID="Books" Text="Books" runat="server"></asp:Label>
    <asp:DropDownList ID="Books" runat="server"></asp:DropDownList>
    <asp:Label ID="LibrariesLabel" AssociatedControlID="Libraries" Text="Libraries" runat="server"></asp:Label>
    <asp:DropDownList ID="Libraries" runat="server"></asp:DropDownList>
    <asp:Label ID="CheckedOutLabel" AssociatedControlID="CheckedOut" Text="Checked Out" runat="server" Visible="false"></asp:Label>
    <asp:CheckBox ID="CheckedOut" runat="server" Visible="false" />
    <asp:Label ID="AvailableLabel" AssociatedControlID="Available" Text="Available" runat="server" Visible="false"></asp:Label>
    <asp:CheckBox ID="Available" runat="server" Visible="false" />


<div>
    <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
    <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" Visible="false" />
</div>
</fieldset>