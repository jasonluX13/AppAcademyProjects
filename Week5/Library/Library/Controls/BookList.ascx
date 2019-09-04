<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookList.ascx.cs" Inherits="Library.Controls.BookList" %>

<%@ Import Namespace="System.Data" %>



<asp:Repeater ID="Books" runat="server" ItemType="DataRow">
    <HeaderTemplate>
        <table class="table">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>ISBN</th>
                    <th>Author's Name</th>
                    <th>&nbsp;</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Field<string>("Title") %></td>
            <td><%# Item.Field<string>("ISBN") %></td>
            <td><%# Item.Field<string>("FirstName") %> <%# Item.Field<string>("LastName") %></td>
            <td>
                <asp:HyperLink runat="server" class="btn btn-secondary" NavigateUrl='<%# $"~/BookEdit.aspx?ID={Item.Field<int>("Id")}" %>' Text="Edit" Visible='<%# CustomUser.IsLibrarian %>'/></td>
            <td>
                <asp:HyperLink runat="server" class="btn btn-info" NavigateUrl='<%# $"~/BookCopies.aspx?ID={Item.Field<int>("Id")}" %>' Text="View Copies" /></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
