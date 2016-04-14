<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Pages_Account_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlContent" runat="server"></asp:Panel>
    <asp:Button ID="btnOK" runat="server" Text="Купити" Width="100px" OnClick="btnOK_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Відміна" Width="100px" OnClick="btnCancel_Click" CausesValidation="False" />
</asp:Content>

