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
    <asp:Repeater ID="OrdersList" runat="server" OnItemCommand="OrdersList_ItemCommand" OnItemDataBound="OrdersList_ItemDataBound">
        <HeaderTemplate>
           
                
        </HeaderTemplate>
        <ItemTemplate>
            <div style="margin-top:10px;">
                 <table class="listtable2">
            <tr>
                <td>订单时间</td>
                <td><%# Eval("OrderTime") %></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Repeater ID="fruitlist" runat="server">
                        <HeaderTemplate>
                            <table class="listtable2">
                                <tr class="listheader">
                                    <th></th>
                                    <th>水果名称</th>
                                    <th>水果数量</th>
                                    <th>水果单价</th>
                                    <th>水果总价</th>
                                    
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
                                
                            </tr> 
   
                        </ItemTemplate>
        
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

                </td>
            </tr>
            <tr>
                <td>订单状态</td>
                <td><%# Eval("OrderStatus") %></td>
            </tr>
            <tr>
                <td>订单总价</td>
                <td><%# Eval("OrderPrice") %></td>
            </tr>
            <tr>
                <td>快递信息</td>
                <td><%# Eval("OrderExpressCompany") %> <%# Eval("OrderExpressNumber") %></td>
            </tr>
            <tr>
                <td>操作</td>
                <td>
                    <asp:Button ID="btnNext" CommandName="Next" CommandArgument='<%#Eval("OrderId") %>' runat="server" Text='<%#Eval("Next") %>' /></td>       
           </tr> 
                      </table>
    </div>
        </ItemTemplate>
        
        <FooterTemplate>
           
        </FooterTemplate>
    </asp:Repeater>
    <input  type="text" name="txtAssess" id="txtAssess" style="visibility:hidden;" value="123"/>  
    
</asp:Content>
