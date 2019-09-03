<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LibraryList.ascx.cs" Inherits="Library.Controls.LibraryList" %>

<%@ Import Namespace="System.Data" %>

<asp:HyperLink ID="LibraryAddLink" runat="server" NavigateUrl="~/LibraryAdd.aspx">Add New Library</asp:HyperLink>


<asp:Repeater ID="Libraries" runat="server" ItemType="DataRow">
    <HeaderTemplate>
        <table class="table">
            <thead>
            <tr>
                <th>Branch Name</th>
                <th>Address</th>
                <th>State</th>
                <th>Zipcode</th>
                <th>&nbsp;</th>
            </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Field<string>("BranchName") %> </td>
            <td><%# Item.Field<string>("Address") %> </td>
            <td><%# Item.Field<string>("State") %> </td>
            <td><%# Item.Field<string>("Zipcode") %> </td>
            <td>
                <asp:HyperLink runat="server" class="btn btn-secondary" NavigateUrl='<%# $"~/EditLibrary.aspx?ID={Item.Field<int>("Id")}" %>' Text="Edit" /></td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody></table>
    </FooterTemplate>
</asp:Repeater>