<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LibraryAddEdit.ascx.cs" Inherits="Library.Controls.LibraryAddEdit" %>

<h2>
    <asp:label ID="AddOrEdit" runat="server"></asp:label>
</h2>

<fieldset>

    <div>
        <asp:Label ID="BranchNameLabel" runat="server" AssociatedControlID="BranchName" Text="Branch Name: " />
        <asp:TextBox ID="BranchName" runat="server" />
    </div>

    <div>
        <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="Address" Text="Address: " />
        <asp:TextBox ID="Address" runat="server" />
    </div>

    <div>
        <asp:Label ID="StateLabel" runat="server" AssociatedControlID="State" Text="State: " />
        <asp:TextBox ID="State" runat="server" />
    </div>

    <div>
        <asp:Label ID="ZipcodeLabel" runat="server" AssociatedControlID="Zipcode" Text="Zipcode: " />
        <asp:TextBox ID="Zipcode" runat="server" />
    </div>

    

</fieldset>

<div>
    <asp:Button ID="Save" class="btn btn-primary" runat="server" Text="Save" OnClick="Save_Click" />
    <asp:Button ID="Cancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="Cancel_Click" />
</div>
