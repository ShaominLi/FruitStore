using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.DAL;

namespace FruitStore.WebMembers
{
    public partial class myshopcar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请先登录!');location='login.aspx';</script>");
                else
                {
                    string username = Session["UserName"].ToString();
                    int userid = DALUsers.GetUserIdByName(username);
                    ShopCarList.DataSource = DALShopCar.GetInfoByUserId(userid,0);
                    ShopCarList.DataBind();
                    txtSumPrice.Text = DALShopCar.SumOfUser(userid).ToString();
                }
            }

        }

        protected void ShopCarList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DeleteItem":
                    ShopCarList.Visible = false;
                    int status;
                    int id = Convert.ToInt32(e.CommandArgument);
                    ShopCarList.DataSource = DALShopCar.DeleteItemByID(id,out status);
                    ShopCarList.DataBind();
                    if(status==1)
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功!');</script>");
                    else
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败!');</script>");
                    ShopCarList.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}