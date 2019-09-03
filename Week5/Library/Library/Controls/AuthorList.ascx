<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuthorList.ascx.cs" Inherits="Library.Controls.AuthorList" %>

<%@ Import Namespace="System.Data" %>

<asp:HyperLink ID="AuthorAddLink" runat="server" NavigateUrl="~/AuthorAdd.aspx">Add New Author</asp:HyperLink>

<asp:Repeater ID="Authors" runat="server" ItemType="DataRow">
    <HeaderTemplate>
        <table class="table">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Field<string>("FirstName") %></td>
            <td><%# Item.Field<string>("LastName") %></td>
            <td>
                <asp:HyperLink runat="server" class="btn btn-secondary" NavigateUrl='<%# $"~/AuthorEdit.aspx?ID={Item.Field<int>("Id")}" %>' Text="Edit" /></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
