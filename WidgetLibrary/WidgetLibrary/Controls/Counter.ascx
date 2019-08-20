<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Counter.ascx.cs" Inherits="WidgetLibrary.Controls.Counter" %>

<asp:Button id="Down" text="-" runat="server" onclick="Down_Click"/>
<asp:Label id="CountLabel" runat="server"></asp:Label>
<asp:Button id="Up" text="+" runat="server" onclick="Up_Click"/>