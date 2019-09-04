<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuthorAddEdit.ascx.cs" Inherits="Library.Controls.AuthorAddEdit" %>



<fieldset>
    <h2>
        <asp:Label ID="AddOrEdit" runat="server"></asp:Label>
    </h2>
    <div class="form-row align-items-left">
        <div class="form-group col-auto">
            <asp:TextBox class="form-control" ID="FirstName" runat="server" placeholder="First Name" />
        </div>

        <div class="form-group col-auto">

            <asp:TextBox class="form-control" ID="LastName" runat="server" placeholder="Last Name" />
        </div>

        <div class="form-group col-auto">
            <asp:Button ID="Save" class="btn btn-primary" runat="server" Text="Save" OnClick="Save_Click" />
            <asp:Button ID="Cancel" class="btn btn-primary" runat="server" Text="Cancel" OnClick="Cancel_Click" />
        </div>
    </div>



</fieldset>


