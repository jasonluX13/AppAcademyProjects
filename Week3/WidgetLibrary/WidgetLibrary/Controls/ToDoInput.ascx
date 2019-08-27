<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToDoInput.ascx.cs" Inherits="WidgetLibrary.Controls.ToDoInput" %>

<asp:Label runat="server">Task</asp:Label>
<asp:TextBox ID="Description" runat="server"></asp:TextBox>
<asp:Label ID="CategoryLabel" Text="Category" runat="server"></asp:Label>
<asp:dropdownlist id="Category" runat="server" />
<asp:Button ID="Submit" runat="server" Text="Add Task" OnClick="Submit_Click" />