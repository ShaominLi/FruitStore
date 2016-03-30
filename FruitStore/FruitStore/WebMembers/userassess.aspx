<%@ Page Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="userassess.aspx.cs" Inherits="FruitStore.WebMembers.userassess" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 352px;
            height: 98px;
        }
        .auto-style2 {
            width: 113px;
            height: 98px;
        }
    </style>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    登录
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <fieldset>
        <legend>用户评价</legend>
        <div  style="float:left; width: 379px; margin-top:30px;" >
        <table class="formtable" style="width: 99%;" >
            <tr>
                <td class="auto-style2">
                    <br />
                    <br />
                    请评价:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtUserAssess" runat="server" TextMode="MultiLine" Height="57px" Width="234px"/>
                    <asp:RequiredFieldValidator ID="valtxtUserAssess" runat="server"
                        ControlToValidate="txtUserAssess" ErrorMessage="*" CssClass="error" Display="Dynamic" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="command">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="clickbutton" OnClick="btnSubmit_Click" />                  
                </td>
            </tr>
        </table>
        </div>
    </fieldset>
</asp:Content>

