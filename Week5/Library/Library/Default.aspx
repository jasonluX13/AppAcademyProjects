<%@ Page Title="" Language="C#" MasterPageFile="~/Library.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Library.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h1>
        <asp:label id="Welcome" runat="server">
        </asp:label>
    </h1>
    <p>
        Checkout all our new features:
        <br />
        Librarians can
      <ul>
          <li>
              Register new books
          </li>
          <li>
              Register when a book arrives from another library
          </li>
          <li>Assign books as "out" to patrons with a due date</li>
          <li>Register when a book is returned</li>
          <li>Mark books as not longer available</li>
          <li>Search for overdue books</li>
      </ul>
Each librarian has
        <ul>
          <li>A unique employee number that's eight numbers long</li>
          <li>A library to which they're assigned </li>
      </ul>


Patrons can
        <ul>
            <li>Reserve books</li>
            <li>Request books from one library be sent to another library</li>
        </ul>

Each patron is described by their
        <ul>
            <li>First name</li>
            <li>Last name</li>
            <li>Email address</li>
            <li>Street address</li>
            <li>ZIP code</li>
            <li>Unique library card number</li>
        </ul>


Books are described by their
        <ul>
            <li>Title</li>
            <li>ISBN</li>
            <li>Author</li>
        </ul>

Authors are described by their
        <ul>
            <li>First name</li>
            <li>Last name</li>
        </ul>

Libraries are described by their
        <ul>
            <li>Branch name</li>
            <li>Street address</li>
            <li>ZIP code</li>
            <li>Librarians are also patrons</li>
        </ul>
    </p>
</asp:Content>
