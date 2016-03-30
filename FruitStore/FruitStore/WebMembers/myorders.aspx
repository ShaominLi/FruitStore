<%@ Page Language="C#"  MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="myorders.aspx.cs" Inherits="FruitStore.WebMembers.myorders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/jbox/jbox.css" rel="stylesheet"/>
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
    <script src="../Scripts/jquery-1.9.0.min.js"></script>
    <script src="../Scripts/jquery.jBox-2.3.min.js" ></script>
    <script src="../Scripts/jquery.jBox-zh-CN.min.js"></script>
    
    <script type="text/javascript">
        //function stopDefault(e) {
        //    // Prevent the default browser action (W3C)
        //    if (e && e.preventDefault)
        //        e.preventDefault();
        //    else
        //        // A shortcut for stoping the browser action in IE
        //        window.event.returnValue = false;
        //    return false;
        //}

        function assess(e) {
            
            var html = "<div style='padding:10px;'>输入评价：<input type='text' id='assess' name='assess' /></div>";
            //alert(html);
            var submit = function (v, h, f) {
               
                if (f.assess == '') {
                    $.jBox.tip("请输入评价。", 'error', { focusId: "assess" }); // 关闭设置 yourname 为焦点
                    return false;
                } else {
                    alert($("#txtAssess").val());
                    var id = e.CommandArgument;
                    alert(id);
                    $("#txtAssess").attr("value", f.assess); 
                  
                    return true;
                }
            };
            $.jBox(html, { title: '评价', submit: submit });
            return false;
            //stopDefault(e);
        }
        

    </script>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    欢迎来到水果商城
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
   我的订单
    <asp:Repeater ID="OrdersList" runat="server" OnItemCommand="OrdersList_ItemCommand">
        <HeaderTemplate>
            <table class="listtable2">
                
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="listheader">   
                    <th>订单时间</th>
                    <th>收货姓名</th>
                    <th>收货地址</th>
                    <th>收货电话</th>
                    <th>订单状态</th>               
                    </tr>
            <tr>
                <td><%# Eval("OrderTime") %></td>
                <td><%# Eval("OrderUserName") %></td>
                <td> <%# Eval("OrderUserAdress") %></td>
                <td><%# Eval("OrderUserPhone") %></td>
                <td><%# Eval("OrderStatus") %></td>
                </tr>
            <tr class="listheader">                   
                    <th>用户备注</th>
                    <th>快递信息</th>
                    <th>买家评价</th>
                    <%--<th>卖家评价</th>--%>
                    <th>下一步</th> 
                    <th></th>
                </tr>
            <tr>
                <td><%# Eval("OrderUserComment") %></td>
                <td> <%# Eval("OrderExpressCompany") %> <%# Eval("OrderExpressNumber") %></td>
                <td><%# Eval("OrderAssessByUser") %></td>
                <%--<td><%# Eval("OrderAssessByAdm") %></td>--%>
                <td>
                    <asp:Button ID="btnNext" CommandName="Next" CommandArgument='<%#Eval("OrderId") %>' runat="server" Text='<%#Eval("Next") %>' /></td>
            
           </tr> 
   
        </ItemTemplate>
        
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <input  type="text" name="txtAssess" id="txtAssess" style="visibility:hidden;" value="123"/>  
    
</asp:Content>
