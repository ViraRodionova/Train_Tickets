﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Pages_Home" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ MasterType VirtualPath="../MasterPage.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">     
    <ContentTemplate>

    <asp:CheckBox ID="cbOne" runat="server" Checked="True" OnCheckedChanged="cbOne_CheckedChanged" Text="В одну сторону" AutoPostBack="True" Width="259px" CssClass="squaredThree" Visible="False" />
&nbsp;&nbsp;&nbsp;
    <asp:CheckBox ID="cbTwo" runat="server" OnCheckedChanged="cbTwo_CheckedChanged" Text="В обидві сторони" AutoPostBack="True" Width="250px" CssClass="squaredThree" Visible="False" />
    <br />
    <asp:DropDownList ID="ddlFrom" runat="server" DataSourceID="sds_stations" DataTextField="station" DataValueField="station" CssClass="Ddl">
    </asp:DropDownList>

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:ImageButton ID="btnReverse" runat="server" CausesValidation="False" Height="40px" OnClick="btnReverse_Click" Width="40px" ImageAlign="Middle" ImageUrl="~/images/b_refresh.png" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlTo" runat="server" DataSourceID="sds_stations" DataTextField="station" DataValueField="station" CssClass="Ddl" Height="40" Width="200">
    </asp:DropDownList>

    &nbsp;&nbsp;&nbsp;

    <asp:Button ID="btnSearch" runat="server" Text="Пошук" OnClick="btnSearch_Click" CssClass="BtnSearch" />
    &nbsp;<asp:Label ID="lblResult" runat="server"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="txtDateOne" runat="server" CssClass="TextBoxCalendar"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="txtDateOne_CalendarExtender" runat="server" TargetControlID="txtDateOne" />
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDateOne" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtDateTwo" runat="server" Visible="False" Height="30px" Width="150px" CssClass="TextBoxCalendar"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="txtDateTwo_CalendarExtender" runat="server" TargetControlID="txtDateTwo" />
    <br />
    

    <asp:SqlDataSource ID="sds_stations" runat="server" ConnectionString="<%$ ConnectionStrings:Tickets_DBConnectionString %>" SelectCommand="SELECT DISTINCT station
FROM routes"></asp:SqlDataSource>
    
    </ContentTemplate>
    </asp:UpdatePanel>         
    </asp:Content>

