using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.Model;
using FruitStore.DAL;

namespace FruitStore.WebMembers
{
    public partial class myInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请先登录!');location='login.aspx';</script>");
                else
                {
                    string Username = Session["UserName"].ToString();
                    Users myInfo = DALUsers.GetInfoByName(Username);

                    txtUserName.Text = myInfo.UserVName;
                    txtUserTName.Text = myInfo.UserTName;
                    //txtPsw.Text = myInfo.UserPsw;
                    //txtAddress.Text = myInfo.UserAdress;
                    txtPhone.Text = myInfo.UserPhone;
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string username = Session["UserName"].ToString();
            string usertname = txtUserTName.Text;
            string phone = txtPhone.Text;
            int result=DALUsers.ModifyBasicInfo(username, usertname, phone);
            if (result == 0)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败，请联系管理员！!');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功!');location='myInfo.aspx';</script>");
            }
        }
    }
}