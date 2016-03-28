<%@ Page Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="mainmemu.aspx.cs" Inherits="FruitStore.WebMembers.mainmemu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    欢迎来到水果商城
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
   
    <asp:Repeater ID="FruitList" runat="server">
        <HeaderTemplate>
<%--                <tr class="listheader">
                    <th>水果名称</th>
                    <th>水果种类</th>
                    <th>水果图片</th>
                    <th>水果说明</th>
                    <th>水果原价</th>
                    <th>水果现价</th>
                </tr>--%>
        </HeaderTemplate>
        <ItemTemplate>
            <div style="float:left;">
        
        <table class="listtable">
            <tr><td colspan="2"><a href="fruitmenu.aspx?FruitName=<%# Eval("FruitName") %>">
               <asp:Image ID="img" runat="server" ImageUrl=<%# Eval("FruitImage") %> AlternateText=" Logo" Width="200px" /></a></td></tr>  
            <tr><td colspan="2"><%# Eval("FGroupName") %></td></tr>
            <tr style="height:80px;">
                <td><%# Eval("FruitName") %></td>
                <td><%# Eval("FruitComment") %></td>
            </tr>
            <tr>
                <td style="width:80px;">原价：<%# Eval("FruitOPrice") %></td>
                <td >现价：<%# Eval("FruitNPrice") %></td>
            </tr> 
        </table>
                </div>
        </ItemTemplate>
        <FooterTemplate>
           
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
