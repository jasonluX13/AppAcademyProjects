<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookList.ascx.cs" Inherits="Library.Controls.BookList" %>

<%@ Import Namespace="System.Data" %>

<asp:HyperLink ID="BookAddLink" runat="server" NavigateUrl="~/BookAdd.aspx">Add New Book</asp:HyperLink>


<asp:Repeater ID="Books" runat="server" ItemType="DataRow">
    <HeaderTemplate>
        <table>
            <tr>
                <th>Title</th>
                <th>ISBN</th>
                <th>Author's Name</th>
                <th>&nbsp;</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Field<string>("Title") %></td>
            <td><%# Item.Field<string>("ISBN") %></td>
            <td><%# Item.Field<string>("FirstName") %> <%# Item.Field<string>("LastName") %></td>
            <td>
                <asp:HyperLink runat="server" NavigateUrl='<%# $"~/BookEdit.aspx?ID={Item.Field<int>("Id")}" %>' Text="Edit" /></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
