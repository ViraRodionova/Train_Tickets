<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Pages_Home" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:CheckBox ID="cbOne" runat="server" Checked="True" OnCheckedChanged="cbOne_CheckedChanged" Text="В одну сторону" AutoPostBack="True" />
&nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="cbTwo" runat="server" OnCheckedChanged="cbTwo_CheckedChanged" Text="В обидві сторони" AutoPostBack="True" />
    <br />
    <asp:DropDownList ID="ddlFrom" runat="server" DataSourceID="sds_stations" DataTextField="station" DataValueField="station">
    </asp:DropDownList>

    <asp:ImageButton ID="btnReverse" runat="server" />
    <asp:DropDownList ID="ddlTo" runat="server" DataSourceID="sds_stations" DataTextField="station" DataValueField="station">
    </asp:DropDownList>

    <asp:Button ID="btnSearch" runat="server" Text="Пошук" OnClick="btnSearch_Click" />
    &nbsp;<asp:Label ID="lblResult" runat="server"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="txtDateOne" runat="server"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="txtDateOne_CalendarExtender" runat="server" TargetControlID="txtDateOne" />
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateOne" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;
    <asp:TextBox ID="txtDateTwo" runat="server" Visible="False"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="txtDateTwo_CalendarExtender" runat="server" TargetControlID="txtDateTwo" />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:SqlDataSource ID="sds_stations" runat="server" ConnectionString="<%$ ConnectionStrings:Tickets_DBConnectionString %>" SelectCommand="SELECT DISTINCT station
FROM routes"></asp:SqlDataSource>

    </asp:Content>

