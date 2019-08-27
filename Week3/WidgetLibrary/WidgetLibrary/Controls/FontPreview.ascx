<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FontPreview.ascx.cs" Inherits="WidgetLibrary.Controls.FontPreview" %>

<asp:dropdownlist id="SelectFont" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SelectFont_SelectedIndexChanged">
    <asp:ListItem text="Arial" Value="Arial"></asp:ListItem>
    <asp:ListItem text="Helvetica" Value="Helvetica"></asp:ListItem>
    <asp:ListItem text="Times New Roman" Value="Times New Roman"></asp:ListItem>
    <asp:ListItem text="Courier" Value="Courier"></asp:ListItem>
    <asp:ListItem text="Verdana" Value="Verdana"></asp:ListItem>
    <asp:ListItem text="Georgia" Value="Georgia"></asp:ListItem>
    <asp:ListItem text="Palatino" Value="Palatino"></asp:ListItem>
    <asp:ListItem text="Garamond" Value="Garamond"></asp:ListItem>
    <asp:ListItem text="Bookman" Value="Bookman"></asp:ListItem>
    <asp:ListItem text="Comic Sans MS" Value="Comic Sans MS"></asp:ListItem>
    <asp:ListItem text="Trebuchet MS" Value="Trebuchet MS"></asp:ListItem>
    <asp:ListItem text="Arial Black" Value="Arial Black"></asp:ListItem>
    <asp:ListItem text="Impact" Value="Impact"></asp:ListItem>
</asp:dropdownlist>

<p>
    <asp:Label id="PreviewText" runat="server">
        Lorem ipsum dolor sit amet, consectetur adipiscing elit.
    Nullam vulputate, nisl ut volutpat pulvinar, mi lectus
    malesuada arcu, eu scelerisque tortor elit eu augue.
    Nullam in nibh eleifend, fringilla enim id, consectetur
    dolor. Pellentesque habitant morbi tristique senectus et
    netus et malesuada fames ac turpis egestas. Fusce eleifend
    sit amet justo nec euismod. Sed pharetra laoreet dolor.
    Cras auctor molestie quam, sed pulvinar ligula malesuada
    tincidunt. Suspendisse euismod tincidunt justo, a faucibus
    nisi commodo eu. Vestibulum tempus vehicula diam mattis
    convallis. Cras a velit et lacus pulvinar varius vel eget
    magna. Donec nisl magna, interdum non sem nec, viverra
    lobortis velit. Aenean faucibus quam vel ante congue dictum.
    Mauris vel metus lorem. Curabitur mattis nisi ut convallis
    vehicula. Donec mollis bibendum luctus. Class aptent taciti
    sociosqu ad litora torquent per conubia nostra, per
    inceptos himenaeos.
    </asp:Label>
</p>
