<%@ Page Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="myInfo.aspx.cs" Inherits="FruitStore.WebMembers.myInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    修改密码
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <fieldset>
        <legend>个人信息</legend>
        <table class="formtable" style="width: 50%">
            <tr>
                <td>帐户名：</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td>真实姓名：</td>
                <td>
                    <asp:TextBox ID="txtUserTName" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td>密码：</td>
                <td>                    
                    <asp:TextBox ID="txtPsw" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td>收货地址：</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td>联系电话：</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
