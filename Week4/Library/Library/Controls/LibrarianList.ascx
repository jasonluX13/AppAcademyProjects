<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LibrarianList.ascx.cs" Inherits="Library.Controls.LibrarianList" %>

<%@ Import Namespace="System.Data" %>

<asp:Repeater ID="Librarians" runat="server" ItemType="DataRow">
    <HeaderTemplate>
        <table class="table">
            <thead>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Branch Name</th>
                <th>Librarian Id</th>
                <th>Library Card#</th>
                <th>Email</th>
                <th>Address</th>
                <th>State</th>
                <th>Zipcode</th>
                <th>&nbsp;</th>
            </tr>
            </thead><tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Field<string>("FirstName") %> </td>
            <td><%# Item.Field<string>("LastName") %> </td>
            <td><%# Item.Field<string>("BranchName") %> </td>
            <td><%# Item.Field<int>("Id") %> </td>
            <td><%# Item.Field<int>("LibraryCardNumber") %> </td>
            <td><%# Item.Field<string>("Email") %> </td>
            <td><%# Item.Field<string>("Address") %> </td>
            <td><%# Item.Field<string>("State") %> </td>
            <td><%# Item.Field<string>("Zipcode") %> </td>
            <td>
                <asp:HyperLink runat="server" class="btn btn-secondary" NavigateUrl='<%# $"~/EditLibrarian.aspx?ID={Item.Field<int>("Id")}" %>' Text="Edit" /></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>