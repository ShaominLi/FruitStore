<%@ Page Language="C#" MasterPageFile="~/WebMembers/AdminWebs/admin.Master" AutoEventWireup="true" CodeBehind="myinfo.aspx.cs" Inherits="FruitStore.WebMembers.AdminWebs.myinfo" %>


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
        </table>
    </fieldset>
</asp:Content>

