<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PatronList.ascx.cs" Inherits="Library.Controls.PatronList" %>

<%@ Import Namespace="System.Data" %>

<asp:HyperLink ID="PatronAddLink" runat="server" NavigateUrl="~/PatronAdd.aspx">Add New Patron</asp:HyperLink>


<asp:Repeater ID="Patrons" runat="server" ItemType="DataRow">
    <HeaderTemplate>
        <table>
            <tr>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Library Card#</th>
                <th>Email</th>
                <th>Address</th>
                <th>State</th>
                <th>Zipcode</th>
                <th>&nbsp;</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Field<string>("FirstName") %> </td>
            <td><%# Item.Field<string>("LastName") %> </td>
            <td><%# Item.Field<int>("LibraryCardNumber") %> </td>
            <td><%# Item.Field<string>("Email") %> </td>
            <td><%# Item.Field<string>("Address") %> </td>
            <td><%# Item.Field<string>("State") %> </td>
            <td><%# Item.Field<string>("Zipcode") %> </td>
            <td>
                <asp:HyperLink runat="server" NavigateUrl='<%# $"~/EditPatron.aspx?ID={Item.Field<int>("LibraryCardNumber")}" %>' Text="Edit" /></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>