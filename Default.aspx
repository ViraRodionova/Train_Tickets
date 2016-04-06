<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="~/styles/checkbox.css" />
    <link rel="stylesheet" type="text/css" href="~/styles/default.css" />

    <div>
        <asp:CheckBox ID="cbOneWay" runat="server" text="В одну сторону" CssClass="squaredFour" AutoPostBack="True" OnCheckedChanged="cbOneWay_CheckedChanged"/>
        <asp:CheckBox ID="cbTwoWay" runat="server" text="В обидві сторони" CssClass="squaredFour" AutoPostBack="True" OnCheckedChanged="cbTwoWay_CheckedChanged"/><br />
    </div>

    <div>
        <asp:TextBox ID="txtDateFrom" runat="server" CssClass="text_box"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" TargetControlID="txtDateFrom" />
        <asp:ImageButton ID="btnReplaceDates" runat="server" ImageUrl="~/images/b_refresh.png" Height="20px" OnClick="btnReplaceDates_Click"/>
        <asp:TextBox ID="txtDateTo" runat="server" CssClass="text_box"></asp:TextBox>
        <ajaxToolkit:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" TargetControlID="txtDateTo" />
        <asp:Button ID="btnSearch" runat="server" Text="Пошук" />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
    </div>

    <div>
        <br />
    </div>

</asp:Content>

