using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FruitStore.Model;
using FruitStore.DAL;

namespace FruitStore.WebMembers.AdminWebs
{
    public partial class modifypassword : System.Web.UI.Page
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请先登录!');location='../login.aspx';</script>");
            else
                Username = Session["UserName"].ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string oldpsw = txtOldPsw.Text.Trim();
            string newpsw = txtNewPsw.Text.Trim();
            int flag = DALUsers.ModifyPassword(Username, oldpsw, newpsw);
            if (flag < 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('原密码错误!');</script>");
                txtOldPsw.Text = "";
            }
            else if (flag == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改密码失败，请联系管理员！!');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功，请重新登录!');location='../login.aspx';</script>");
            }


        }
    }
}