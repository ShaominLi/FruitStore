<%@ Page Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="mydeliveryinfo.aspx.cs" Inherits="FruitStore.WebMembers.mydeliveryinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function del(obj) {
            var temp = obj.id;
            var array = temp.split("_");

            if (confirm("确定删除吗？"))
                document.getElementById("DelAdr").value = array[1];
            else
                document.getElementById("DelAdr").value = "";
            //alert(document.getElementById("DelAdr").value);
        }
    </script>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    修改密码
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <fieldset>
        <legend>收货信息</legend>

        <asp:Table ID="myinfo" runat="server" Width="600px">
            <asp:TableRow>
                <asp:TableCell>
                    用户名：
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="txtName" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    联系电话：
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="txtPhon" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    收货地址：
 </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="txtAdr" runat="server" Width="400px" />
                    
                     <asp:linkbutton ID="add" runat="server" style="margin-left:0px;" OnClick="add_Click">+</asp:linkbutton>
                    <%-- <asp:linkbutton ID="sub" runat="server" style="margin-left:5px;" OnClick="sub_Click">-</asp:linkbutton>--%>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <div style="padding-left:90px;">
            <asp:TextBox ID="newadr"  runat="server" Width="400px" Visible="false"></asp:TextBox>
            <input  type="text" name="DelAdr" id="DelAdr" style="visibility:hidden;"/>  
        </div>
    </fieldset>

</asp:Content>
