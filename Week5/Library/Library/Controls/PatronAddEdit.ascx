<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PatronAddEdit.ascx.cs" Inherits="Library.Controls.PatronAddEdit" %>

<h2>
    <asp:label ID="AddOrEdit" runat="server"></asp:label>
</h2>

<fieldset>

    <div>
        <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName" Text="First Name: " />
        <asp:TextBox ID="FirstName" runat="server" />
    </div>

     <div>
        <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName" Text="Last Name: " />
        <asp:TextBox ID="LastName" runat="server" />
    </div>
     <div>
        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" Text="Email: " />
        <asp:TextBox ID="Email" runat="server" />
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
    <asp:Button ID="Save" class="btn btn-primary"  runat="server" Text="Save" OnClick="Save_Click" />
    <asp:Button ID="Cancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="Cancel_Click" />
</div>
