using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.DAL;
using FruitStore.Model;

namespace FruitStore.WebMembers
{
    public partial class submitorder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Username = Session["UserName"].ToString();
                DeliveryInfo my = DALUsers.GetDeliveryInfo(Username);

                string price = Request.QueryString["price"].ToString();
                txtUserName.Text = my.Uservname;
                txtPhone.Text = my.Userphone;
                txtFruitPrice.Text = price;
                txtComment.Text = "";
                string[] sArray = my.Deliveryadress.Split('+');
                AddressList.DataSource = sArray;
                AddressList.DataBind();

                if(Convert.ToDouble(txtFruitPrice.Text)>=88.00)
                    txtExpressPrice.Text = "0.00";
                else
                    txtExpressPrice.Text = "10.00";
                txtSumPrice.Text = (Convert.ToDouble(txtFruitPrice.Text) + Convert.ToDouble(txtExpressPrice.Text)).ToString();
                //清空购物车
                //int userid = DALUsers.GetUserIdByName(Username);
                //DALShopCar.ClearShopCar(userid);

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //txtFlag.Visible = true;
            int status = Convert.ToInt32( Request.Form["txtFlag"].ToString());
            string name = txtUserName.Text;
            string phone = txtPhone.Text;
            float price = (float)Convert.ToDouble(txtSumPrice.Text);
            string adr = AddressList.SelectedValue;
            string usercommand = txtComment.Text;
            OrderInfo myorder = new OrderInfo(price,name,adr,phone,status,usercommand);
            int flag=DALOrders.InsertOrder(myorder);
            if (flag == 1)
            {
                //绑定shopcarID和orderID
                string Username = Session["UserName"].ToString();
                int userid = DALUsers.GetUserIdByName(Username);
                int result=DALShopCar.BindOrderId(userid);
                Server.Transfer("myorders.aspx"); 
            }
        }
    }
}