<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.ascx.cs" Inherits="WidgetLibrary.Controls.ToDoList" %>

<asp:Repeater ID="TaskList" runat="server" OnItemCommand="TaskList_ItemCommand">
    <HeaderTemplate>
        <table>
            <tr>
                <th>Tasks</th>
                <th>Category</th>
                <th>Complete</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:Label ID="Description" Text='<%# Eval("Description") %>' runat="server" Font-Strikeout='<%# Eval("Done") %>' />
            </td>
            <td>
                <asp:Label ID="Category" runat="server"
                    Text='<%# Eval("Category") %>'
                    Font-Strikeout='<%# Eval("Done") %>' />
            </td>
            <td>
                <asp:Button ID="Done" Text="Done" runat="server" CommandName="Done"
                    CommandArgument='<%# Container.ItemIndex %>'
                    Visible='<%# !((bool)Eval("Done")) %>' />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
