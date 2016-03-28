<%@ Page Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FruitStore.WebMembers.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 352px;
        }
        .auto-style2 {
            width: 113px;
        }
    </style>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    登录
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <fieldset>
        <legend>登录信息</legend>
        <div  style="float:left; width: 379px; margin-top:30px;" >
        <table class="formtable" style="width: 99%;" >
            <tr>
                <td class="auto-style2">账号名:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtUserName" runat="server" />
                    <asp:RequiredFieldValidator ID="valUserName" runat="server"
                        ControlToValidate="txtUserName" ErrorMessage="*" CssClass="error" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">密码:</td>
                <td class="auto-style1">
                    <asp:TextBox type="password" ID="txtPassword" runat="server" />
                    <asp:RequiredFieldValidator ID="valPassword" runat="server"
                        ControlToValidate="txtPassword" ErrorMessage="*" CssClass="error" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="command">
                    <asp:Button ID="btnSubmit" runat="server" Text="登录" CssClass="clickbutton" OnClick="btnSubmit_Click" />
                    <asp:Button runat="server" ID="reset" Text="重置" class="clickbutton" OnClick="reset_Click" />
                </td>
            </tr>
        </table>
        </div>
        <div style="float:left; margin-left:200px;">
            <img src="../Images/login.jpg" />
        </div>
    </fieldset>
</asp:Content>
