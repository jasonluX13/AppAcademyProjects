<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoList.aspx.cs" Inherits="ToDoList.ToDoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>To Do List</h1>
    <form id="form1" runat="server">
    <div>
        

        <asp:Repeater ID="Tasks" runat="server" ItemType="ToDoList.ToDoItem" OnItemCommand="Tasks_ItemCommand">
            <HeaderTemplate>
                <table> 
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td> 
                        <asp:label id="Description" runat="server" 
                            text='<%# Eval("Description") %>'
                            font-strikeout='<%# Eval("Done") %>' />
                        
                    </td>
                    <td>
                        <asp:button id="Done" runat="server" text="Done"
                            commandname="Done" 
                            commandargument='<%# Container.ItemIndex %>'
                            visible='<%# !((bool)Eval("Done")) %>' />
                    </td>
                    
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:Label runat="server">Task</asp:Label>  
        <asp:textbox id="Description" runat="server"></asp:textbox>
        <asp:button ID="Submit" runat="server" text="Add Task" OnClick="Submit_Click"/>
        <asp:Label ID="ErrorMessage" runat="server" Text="Please provide a description." ForeColor="Red" Visible="false"></asp:Label>
    </div>
    </form>
</body>
</html>
