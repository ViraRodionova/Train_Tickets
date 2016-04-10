<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="Pages_SearchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>

    <asp:Button ID="Button1" runat="server" Text="Плацкарт" OnClick="ButtonIsClicked" />
<asp:Button ID="Button2" runat="server" Text="Купе" OnClick="ButtonIsClicked" />
<asp:Button ID="Button3" runat="server" Text="Люкс" OnClick="ButtonIsClicked" />

    <asp:Panel ID="pnlTrains" runat="server">
        
    </asp:Panel>
</asp:Content>

