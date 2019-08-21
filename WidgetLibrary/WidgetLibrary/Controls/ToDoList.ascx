<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.ascx.cs" Inherits="WidgetLibrary.Controls.ToDoList" %>

<asp:Repeater ID="TaskList" runat="server" OnItemCommand="TaskList_ItemCommand">
    <HeaderTemplate>
        <table>
            <tr>
                <th>Tasks</th>
                <th>Complete</th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:label id="Description" text=<%# Eval("Description") %> runat="server" font-strikeout='<%# Eval("Done") %>' />
            </td>
            <td>
                <asp:button id="Done" Text="Done" runat="server" commandname="Done" 
                            commandargument='<%# Container.ItemIndex %>'
                            visible='<%# !((bool)Eval("Done")) %>' />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>