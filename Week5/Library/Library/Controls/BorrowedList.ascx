<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BorrowedList.ascx.cs" Inherits="Library.Controls.BorrowedList" %>

<%@ Import Namespace="System.Data" %>

<asp:Repeater ID="BorrowedBooks" runat="server" ItemType="DataRow">
    <HeaderTemplate>
        <table class="table">
            <thead>
            <tr>
                <th>Title</th>
                <th>ISBN</th>
                <th>Author's Name</th>
                <th>Library</th>
                <th>Patron</th>
                <th>Date Borrowed</th>
                <th>Date Due</th>
                <th>Date Returned</th>
                <th>&nbsp</th>
            </tr>
            </thead><tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Item.Field<string>("Title") %></td>
            <td><%# Item.Field<string>("ISBN") %></td>
            <td><%# Item.Field<string>("AuthorName") %></td>
            <td><%# Item.Field<string>("BranchName") %></td>
            <td><%# Item.Field<string>("PatronName") %></td>
            <td><%# Item.Field<DateTimeOffset>("BorrowedDate") %></td>
            <td><%# Item.Field<DateTimeOffset>("DueDate") %></td>
            <td><%# Item.Field<DateTimeOffset?>("ReturnDate") %></td>
            <td>
                <%--<asp:HyperLink runat="server" class="btn btn-secondary" NavigateUrl='<%# $"~/AuthorEdit.aspx?ID={Item.Field<int>("Id")}" %>' Text="Return" />--%>
                <asp:Button id="Return" Text="Return" runat="server" class="btn btn-secondary" CommandArgument='<%# Item.Field<int>("BorrowedId") %>' OnClick="Return_Click" />
            </td>
            
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
