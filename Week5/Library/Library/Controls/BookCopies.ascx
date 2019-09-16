<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookCopies.ascx.cs" Inherits="Library.Controls.BookCopies" %>

<%@ Import Namespace="System.Data" %>

<asp:Repeater ID="Results" runat="server" ItemType="DataRow">
    <HeaderTemplate>
        <table class="table">
            <thead>
            <tr>
                <th>Title</th>
                <th>ISBN</th>
                <th>Author's Name</th>
                <th>Library</th>
                <th>Out</th>
                <th>Available</th>
                <th>&nbsp;</th>
            </tr>
            </thead><tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Field<string>("Title") %></td>
            <td><%# Item.Field<string>("ISBN") %></td>
            <td><%# Item.Field<string>("FirstName") %> <%# Item.Field<string>("LastName") %></td>
            <td><%# Item.Field<string>("BranchName") %></td>
            <td><%# Item.Field<bool>("Out") %></td>
            <td><%# Item.Field<bool>("Available") %></td>
            <td>
                <asp:HyperLink runat="server" class="btn btn-secondary" NavigateUrl='<%# $"~/CheckoutBook.aspx?ID={Item.Field<int>("Id")}" %>' Text="Checkout" visible='<%# (!Item.Field<bool>("Out") && Item.Field<bool>("Available")) %>'/></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
