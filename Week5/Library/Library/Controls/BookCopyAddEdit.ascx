<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookCopyAddEdit.ascx.cs" Inherits="Library.Controls.BookCopyAddEdit" %>


<fieldset id="AddEditForm" runat="server">
    <h1>
        <asp:Label ID="AddOrEdit" runat="server"></asp:Label>
    </h1>
    <div>
        <asp:Label ID="BooksLabel" AssociatedControlID="Books" Text="Books" runat="server"></asp:Label>
        <asp:DropDownList ID="Books" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="LibrariesLabel" AssociatedControlID="Libraries" Text="Libraries" runat="server"></asp:Label>
        <asp:DropDownList ID="Libraries" runat="server"></asp:DropDownList>
    </div>

    <asp:Label ID="CheckedOutLabel" AssociatedControlID="CheckedOut" Text="Checked Out" runat="server" Visible="false"></asp:Label>
    <asp:CheckBox ID="CheckedOut" runat="server" Visible="false" />
    <asp:Label ID="AvailableLabel" AssociatedControlID="Available" Text="Available" runat="server" Visible="false"></asp:Label>
    <asp:CheckBox ID="Available" runat="server" Visible="false" />


    <div>
        <asp:Button ID="Save" class="btn btn-primary" runat="server" Text="Save" OnClick="Save_Click" />
        <asp:Button ID="Cancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="Cancel_Click" Visible="false" />
    </div>
</fieldset>
