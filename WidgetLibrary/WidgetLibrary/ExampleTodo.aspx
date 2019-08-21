<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExampleTodo.aspx.cs" Inherits="WidgetLibrary.ExampleTodo" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h1>Widget Library</h1>

    <h2>TodoList Control Documentation</h2>

    <p>
        This control creates a ToDoList input field that can be used to add a task.
    </p>

    <h3>Available Properties</h3>
    <ul>
        <li>No special properties.</li>

    </ul>

    <h3>Examples</h3>

    <pre>&lt;wl:todoinput runat="server" /&gt;</pre>

    <!-- This content is being rendered by an instance of the ToDoInput user control -->
    <div>
        <wl:ToDoInput runat="server" />
    </div>


    <p>
        This control creates a ToDoList input field that can be used to add a task.
    </p>

    <h3>Available Properties</h3>
    <ul>
        <li>No special properties.</li>

    </ul>

    <h3>Examples</h3>
    <pre>&lt;wl:todolist runat="server" /&gt;</pre>

    <!-- This content is being rendered by an instance of the ToDoList user control -->
    <div>
        <wl:ToDoList runat="server" />
    </div>
</asp:Content>
