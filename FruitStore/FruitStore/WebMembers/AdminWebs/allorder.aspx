<%@ Page Language="C#" MasterPageFile="~/WebMembers/AdminWebs/admin.Master" AutoEventWireup="true" CodeBehind="allorder.aspx.cs" Inherits="FruitStore.WebMembers.AdminWebs.allorder" %>

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
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    欢迎来到水果商城
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
   我的订单
    <asp:Repeater ID="OrdersList" runat="server" >
        <HeaderTemplate>
            <table class="listtable2">
                <tr class="listheader">   
                    <th>订单时间</th>
                    <th>收货姓名</th>
                    <th>收货地址</th>
                    <th>收货电话</th>
                    <th>订单状态</th>
                    <th>买家评价</th>                 
                    </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("OrderTime") %></td>
                <td><%# Eval("OrderUserName") %></td>
                <td> <%# Eval("OrderUserAdress") %></td>
                <td><%# Eval("OrderUserPhone") %></td>
                <td><%# Eval("OrderStatus") %></td>
                <td><%# Eval("OrderAssessByUser") %></td>
            </tr>
 
        </ItemTemplate>
        
        <FooterTemplate>
   
            </table>
        </FooterTemplate>
    </asp:Repeater>
             <div>
 
             共<asp:Label ID="txtSumPage" runat="server" Text="Label"></asp:Label>页 当前为第  
             <asp:Label ID="txtCurPage" runat="server" Text="Label"></asp:Label>页  
             <asp:Button ID="btnHeadPage" runat="server" Text="首页" OnClick="btnHeadPage_Click"></asp:Button>  
             <asp:Button ID="btnUpPage" runat="server" Text="上一页" OnClick="btnUp_Click" ></asp:Button>  
             <asp:Button ID="btnDownPage" runat="server" Text="下一页" OnClick="btnDown_Click"></asp:Button>  
             <asp:Button ID="btnRealPage" runat="server" Text="尾页" OnClick="btnRealPage_Click"></asp:Button>            
 
                </div>
</asp:Content>

