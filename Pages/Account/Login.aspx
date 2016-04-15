<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Account_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 209px;
    }
    .auto-style2 {
        width: 598px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style1">Email:</td>
            <td><asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLogin" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblPass" runat="server" Text=""></asp:Label>
            </td>
            <td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Button ID="btnLogin" runat="server" Text="Увійти" OnClick="btnLogin_Click" />
                <br />
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                <br />
                <asp:LinkButton ID="lbtnReg" runat="server" PostBackUrl="~/Pages/Account/Registration.aspx" CausesValidation="False">Зареєструватися</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

