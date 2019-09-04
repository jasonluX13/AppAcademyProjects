<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookAddEdit.ascx.cs" Inherits="Library.Controls.BookAddEdit" %>



<fieldset id="AddEditForm" runat="server">
    <h2>
        <asp:Label ID="AddOrEdit" runat="server"></asp:Label>
    </h2>
    <div class="form-row align-items-left">
        <div class="form-group col-auto">
            <asp:TextBox class="form-control" placeholder="Title" ID="Title" runat="server" />
        </div>

        <div class="form-group col-auto">
            <asp:TextBox class="form-control" placeholder="ISBN" ID="ISBN" runat="server" />
        </div>

        <div class="form-group col-auto">
            <asp:DropDownList class="form-control" ID="Authors" runat="server"></asp:DropDownList>
        </div>

        <div class="form-group col-auto">
            <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Save" OnClick="Save_Click" />
            <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Cancel" OnClick="Cancel_Click" />
        </div>
    </div>

</fieldset>
