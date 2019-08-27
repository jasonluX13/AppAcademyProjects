<%@ Page Title="" Language="C#" MasterPageFile="~/RpnCalculator.Master" AutoEventWireup="true" CodeBehind="CalculatorUI.aspx.cs" Inherits="RpnCalculator.CalculatorUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h1>RPN Calculator</h1>
    <div>
        <asp:Repeater ID="StackViewer" ItemType="System.string" runat="server">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# Item %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <section>
        <asp:TextBox ID="NumberInput" runat="server"></asp:TextBox>
        <asp:Button ID="Enter" class="Gray Button" Text="Enter" runat="server" OnClick="Handle_Enter" />
        <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
    </section>
    <fieldset>
        <legend>Math Operations</legend>
        <asp:Button ID="Add" class="Green Button" Text="+" runat="server" OnClick="HandleAdd" />
        <asp:Button ID="Minus" class="Green Button" Text="-" runat="server" OnClick="HandleMinus" />
        <asp:Button ID="Multiply" class="Green Button" Text="*" runat="server" OnClick="HandleMultiply" />
        <asp:Button ID="Divide" class="Green Button" Text="/" runat="server" OnClick="HandleDivide" />
        <asp:Button ID="Negate" class="Green Button" Text="+/-" runat="server" OnClick="HandleNegate" />
        <br />
        <asp:Button ID="SqRoot" class="Green Button" Text="√" runat="server" OnClick="HandleOperation" />
        <asp:Button ID="Natural" class="Green Button" Text="e^x" runat="server" OnClick="HandleOperation" />
        <asp:Button ID="Exponent" class="Green Button" Text="y^x" runat="server" OnClick="HandleOperation" />
        <asp:Button ID="Reciprocal" class="Green Button" Text="1/x" runat="server" OnClick="HandleOperation" />
        <asp:Button ID="Sin" class="Green Button" Text="sin(x)" runat="server" OnClick="HandleOperation" />
        <asp:Button ID="Cos" class="Green Button" Text="cos(x)" runat="server" OnClick="HandleOperation" />
    </fieldset>
    <fieldset>
        <legend>Stack Operations</legend>
        <asp:Button ID="Drop" class="Blue Button" Text="Drop" runat="server" OnClick="HandleDrop" />
        <asp:Button ID="Clear" class="Blue Button" Text="Clear" runat="server" OnClick="HandleClear" />
        <asp:Button ID="Swap" class="Blue Button" Text="Swap" runat="server" OnClick="HandleSwap" />
        <asp:Button ID="Rotate" class="Blue Button" Text="Rotate" runat="server" OnClick="HandleRotate" />
    </fieldset>
</asp:Content>
