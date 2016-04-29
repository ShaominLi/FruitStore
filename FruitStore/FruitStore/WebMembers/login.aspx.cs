using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.DAL;

namespace FruitStore.WebMembers
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UserName"] = null;
                if (Request.UrlReferrer != null)
                    ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            int flag = DALUsers.UserLogin(name, password);
            if (flag > 0)
            {
                Session["UserName"] = name;
                if (name != "admin")
                {
                    if (ViewState["UrlReferrer"] == null)
                        Response.Redirect("~/WebMembers/mainmemu.aspx");// 默认
                    else
                    {
                        string url = ViewState["UrlReferrer"].ToString();
                        int index = url.IndexOf("=");
                        if (index != -1)
                            url = url.Substring(0, index + 1);
                        string type1=url.Substring(url.LastIndexOf("/") + 1);
                        string temp = url.Substring(0, url.LastIndexOf("/"));
                        string type2 = temp.Substring(temp.LastIndexOf("/") + 1);
                        if (type1 == "apply.aspx" || type2 == "AdminWebs")
                            Response.Redirect("~/WebMembers/mainmemu.aspx");
                        Response.Redirect(url);
                    }
                }
                else
                {
                    Response.Redirect("~/WebMembers/AdminWebs/Adminmenu.aspx");
                }
            }
            else if (flag == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名或密码错误！');</script>");
            }
           
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }


    }
}