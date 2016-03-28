<%@ Page Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="submitorder.aspx.cs" Inherits="FruitStore.WebMembers.submitorder" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            function submit() {
                if (confirm("确定付款吗？")) {
                    alert("付款成功，等待发货");
                    document.getElementById("txtFlag").value = "1";
                } else {
                    alert("付款失败，订单已提交");
                    document.getElementById("txtFlag").value = "0";
                }
        }
    </script>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    修改密码
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <fieldset>
        <legend>订单信息</legend>
        <table class="formtable" style="width: 50%">
            <tr>
                <td>收货名：</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td>收货地址：</td>
                <td>
                    <asp:DropDownList ID="AddressList" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>联系电话：</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" />
                </td>
            </tr>
                        <tr>
                <td>客户备注：</td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" MaxLength="20" />
                </td>
            </tr>
                        <tr>
                <td>订单价格：</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server" MaxLength="20" />
                </td>
            </tr>
        </table>
        <div style="float:right;">
        <div>
            <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="submit()">确认并付款</asp:LinkButton>
        </div>
            <input  type="text" name="txtFlag" id="txtFlag" style="visibility:hidden;"/>  
    </div>
    </fieldset>
</asp:Content>
