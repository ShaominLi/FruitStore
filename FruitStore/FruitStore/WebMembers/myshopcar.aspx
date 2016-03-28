<%@ Page Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="myshopcar.aspx.cs" Inherits="FruitStore.WebMembers.myshopcar" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .listtable2{
    width:100%;
    border:1px solid #afafaf;
    border-collapse:collapse;
    margin-bottom:10px;
    margin-top:20px;
}

.listtable2 caption{
    text-align:left;
    font-size:16px;
    padding:2px;
    font-weight:bold;
}

.listtable2 td{
    padding:3px;
    border: 1px solid gray;
    font-size:12px;
    text-align:center;
}

.listtable2 tr:nth-child(2n){
    /*background-color : #ebeaea;*/
}

.listtable2 .listheader{
    background-color:skyblue;
    text-align:center;
}

.listtable2 .listheader th{
    padding:5px;
    border: 1px solid gray;
}
    </style>
    <script type="text/javascript">
        function submit() {
            if (confirm("确定提交吗？")) {
                //alert("!!");
                var price = document.getElementById("<%=txtSumPrice.ClientID %>").innerText;
                var url = "submitorder.aspx?price=" + price;
                //alert(url);
                window.location.href = url;
            }
        }
    </script>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    欢迎来到水果商城
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
   我的购物车
    <asp:Repeater ID="ShopCarList" runat="server" OnItemCommand="ShopCarList_ItemCommand">
        <HeaderTemplate>
            <table class="listtable2">
                <tr class="listheader">
                    <th></th>
                    <th>水果名称</th>
                    <th>水果数量</th>
                    <th>水果单价</th>
                    <th>水果总价</th>
                    <th></th>
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Image ID="img" runat="server" ImageUrl=<%# Eval("FruitImage") %> AlternateText=" Logo" Width="50px" Height="50px"/></td>
                <td><%# Eval("FruitName") %></td>
                <td>
                   <%-- <asp:Button ID="btnSub" runat="server" Text="-" />--%>
                     <%# Eval("FruitNum") %>
                   <%-- <asp:Button ID="btnAdd" runat="server" Text="+" /></td>--%>
                <td><%# Eval("FruitPrice") %></td>
                <td><%# Eval("FruitSumPrice") %></td>
                <td>
                    <asp:Button ID="btnDelete" CommandName="DeleteItem" CommandArgument='<%#Eval("ID") %>' runat="server" Text="删除" />
            </tr> 
   
        </ItemTemplate>
        
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <div style="float:right;">
        <div> 总价：<asp:Label ID="txtSumPrice" runat="server" Text=""></asp:Label></div>
        <div>
            <asp:HyperLink ID="Submit" runat="server" NavigateUrl="javascript:submit();" Text ="确认购买" />
        </div>
    </div>
   
</asp:Content>
