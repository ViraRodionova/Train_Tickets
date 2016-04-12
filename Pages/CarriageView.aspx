<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CarriageView.aspx.cs" Inherits="Pages_CarriageView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="btnOK" runat="server" Text="До корзини" Visible="False" Width="100px" OnClick="btnOK_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Відміна" Visible="False" Width="100px" OnClick="btnCancel_Click" />
    <br />
    <asp:Button ID="btnOrder" runat="server" Text="Купити!" OnClick="btnOrder_Click" />

    <asp:Label ID="lblTrainInfo" runat="server" Text=""></asp:Label>
    <asp:Panel ID="pnlContent" runat="server">
        
    </asp:Panel>
</asp:Content>

