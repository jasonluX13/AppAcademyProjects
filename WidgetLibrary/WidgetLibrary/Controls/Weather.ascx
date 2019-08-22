<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Weather.ascx.cs" Inherits="WidgetLibrary.Controls.Weather" %>

<asp:validationsummary runat="server" displaymode="BulletList" headertext="The following errors were found:" validationgroup="Zipcode"/>

<asp:Label id="ZipcodeLabel" runat="server">Enter Zipcode:</asp:Label>
<asp:TextBox id="Zipcode" runat="server"></asp:TextBox> 
<asp:requiredfieldvalidator runat="server"
        controltovalidate="Zipcode"
        display="Dynamic"
        errormessage="Required field cannot be empty."
        enableclientscript="true"
        validationgroup="Zipcode"
        text="*" />
<asp:rangevalidator runat="server"
        controltovalidate="Zipcode"
        display="Dynamic"
        errormessage="Please provide a valid 5 digit zipcode."
        enableclientscript="true"
        type="Integer"
        minimumvalue="10000"
        maximumvalue="99999"
        text="*"
        validationgroup="Zipcode" />
<asp:Button id="Submit" Text="Submit" runat="server" OnClick="Submit_Click" ValidationGroup="Zipcode" />

<div>
    <asp:Label id="ErrorMessage" runat="server"></asp:Label>
</div>
<div>
    <asp:Label id="Location" runat="server"></asp:Label>
</div>
<div>
    <asp:Label id="Temp" runat="server"></asp:Label>
</div>
<div>
    <asp:Label id="Pressure" runat="server"></asp:Label>
</div>
<div>
    <asp:Label id="Humidity" runat="server"></asp:Label>
</div>
<div>
    <asp:Label id="TempMin" runat="server"></asp:Label>
</div>
<div>
    <asp:Label id="TempMax" runat="server"></asp:Label>
</div>
<div>
    <asp:Label id="WindSpeed" runat="server"></asp:Label>
</div>




