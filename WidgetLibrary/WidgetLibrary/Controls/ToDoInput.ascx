<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToDoInput.ascx.cs" Inherits="WidgetLibrary.Controls.ToDoInput" %>

 <asp:Label runat="server">Task</asp:Label>  
 <asp:textbox id="Description" runat="server"></asp:textbox>
 <asp:button ID="Submit" runat="server" text="Add Task" OnClick="Submit_Click"/>