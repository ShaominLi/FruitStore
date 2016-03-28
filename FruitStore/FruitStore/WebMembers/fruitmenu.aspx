<%@ Page Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="fruitmenu.aspx.cs" Inherits="FruitStore.WebMembers.fruitmenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 98px;
        }
        .auto-style2 {
        height: 53px;
    }
    </style>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    水果详情
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
    <div style="float:left;">
    <table >
            <tr><td rowspan="2">
               <asp:Image ID="fimg" runat="server"  AlternateText=" Logo" Width="200px" /></td>
            <td class="auto-style1">
                    <asp:Label ID="txtfName" runat="server" Text=""></asp:Label></td>
            <td class="auto-style1">
                    <asp:Label ID="txtfComment" runat="server" Text=""></asp:Label></td>
            </tr>  
            <tr>
                <td style="width:80px;">原价：<asp:Label ID="txtfOp" runat="server" Text=""></asp:Label></td>
                <td >现价：<asp:Label ID="txtfNp" runat="server" Text=""> </asp:Label></td>
            </tr> 
        </table>
        </div>
    <div style="float:right; margin-right:300px; width: 122px; height: 156px;">
        <table style="padding-top:15px;">
            <tr><td class="auto-style2">规格：一斤</td></tr>
            <tr><td>数量：<asp:Button ID="btnSub" runat="server" Text="-" Width="20px" OnClick="btnSub_Click" />
                          <asp:TextBox ID="txtNum" runat="server" Width="21px" style="text-align:center"></asp:TextBox>
                          <asp:Button ID="btnAdd" runat="server" Text="+" Width="20px" OnClick="btnAdd_Click" />
                </td></tr>
            <tr><td style="padding-top:20px; padding-left:10px;">
                <asp:Button ID="btnAddShopCar" runat="server" Text="加入购物车" Height="31px" OnClick="btnAddShopCar_Click" /></td></tr>
            </table>
        </div>
</asp:Content>

