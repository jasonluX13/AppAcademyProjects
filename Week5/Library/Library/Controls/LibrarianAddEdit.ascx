<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LibrarianAddEdit.ascx.cs" Inherits="Library.Controls.LibrarianAddEdit" %>

<h2>
    <asp:label ID="AddOrEdit" runat="server"></asp:label>
</h2>

<fieldset>

    
    <div>
        <asp:Label ID="LibrariesLabel" AssociatedControlID="Libraries" Text="Libraries" runat="server"></asp:Label>
        <asp:DropDownList ID="Libraries" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="PatronLabel" AssociatedControlID="Patrons" Text="Patrons" runat="server"></asp:Label>
        <asp:DropDownList ID="Patrons" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:TextBox ID="Password" runat="server" TextMode="Password" Placeholder="Password" ></asp:TextBox>
    </div>
    

</fieldset>

<div>
    <asp:Button ID="Save" class="btn btn-primary"  runat="server" Text="Save" OnClick="Save_Click" />
    <asp:Button ID="Cancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="Cancel_Click" />
</div>
