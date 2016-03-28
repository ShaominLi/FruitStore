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
            if (Session["UserName"] == null)
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请先登录!');location='login.aspx';</script>");
            else
            {
                string Username = Session["UserName"].ToString();
                Users myInfo = DALUsers.GetInfoByName(Username);

                txtUserName.Text = myInfo.UserVName;
                txtUserTName.Text = myInfo.UserTName;
                txtPsw.Text = myInfo.UserPsw;
                txtAddress.Text = myInfo.UserAdress;
                txtPhone.Text = myInfo.UserPhone;
            }
        }
    }
}