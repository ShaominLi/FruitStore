<%@ Page Language="C#" MasterPageFile="~/WebMembers/AdminWebs/admin.Master" AutoEventWireup="true" CodeBehind="modifyweb.aspx.cs" Inherits="FruitStore.WebMembers.AdminWebs.modifyweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 6px;
        }
        .auto-style3 {
            height: 9px;
        }
        .auto-style5 {
            height: 20px;
        }
        .auto-style6 {
            height: 40px;
        }
        .auto-style7 {
            height: 13px;
        }
    </style>
            <script type="text/javascript">
                function submit() {
                    if (confirm("确定修改吗？")) {
                        alert("修改成功");
                        //document.getElementById("txtFlag").value = "1";
                        return true;
                    } else {
                        alert("修改失败");
                        //document.getElementById("txtFlag").value = "0";
                        return false;
                    }
                }
    </script>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderNav" runat="server">
    修改密码
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <fieldset>
        <legend>水果信息</legend>
        <table class="formtable" style="width: 50%;margin-left:200px;" >
            <tr>
                <td style="vertical-align:central;">
                    <asp:FileUpload ID="pic_upload" runat="server" />
                </td>
                <td rowspan="2">
                    <asp:Image ID="Fruitimg" runat="server" Height="200px"/>  
                </td>
            </tr>
            <tr><td><asp:Label ID="lbl_pic" runat="server" class="pic_text"></asp:Label>    </td></tr>
            <tr><td>上传图片格式为.jpg,.bmp,.png,图片大小为319*220   </td></tr>
            <tr>
                <td class="auto-style1">
                    <br />
                    </td>
                <td class="auto-style1">
                    水果名称：<asp:TextBox ID="txtFruitName" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <br />
                    </td>
                <td class="auto-style6">                    
                    水果类别：<asp:DropDownList ID="GroupList" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <br />
                    </td>
                <td class="auto-style3">                    
                    水果原价：<asp:TextBox ID="txtOPrice" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <br />
                    </td>
                <td class="auto-style7">                    
                    水果现价：<asp:TextBox ID="txtNPrice" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <br />
                    </td>
                <td class="auto-style5">                    
                    水果描述：<asp:TextBox ID="txtFruitComment" runat="server" MaxLength="20" />
                </td>
            </tr>
            <tr><td><%--<input type="text" id="flag" name="flag" style="visibility:hidden;" />--%></td><td>
                <asp:Button ID="btnSubmit" runat="server" Text="确认修改" OnClientClick="return submit()" OnClick="btnSubmit_Click" />
                         </td></tr>
        </table>
    </fieldset>
</asp:Content>


