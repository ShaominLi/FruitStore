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
    public partial class fruitmenu : System.Web.UI.Page
    {
        private string fruitName;

        public string FruitName
        {
            get { return fruitName; }
            set { fruitName = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //初始化水果信息
                string tempFruitName = Request.QueryString["FruitName"];
                if (tempFruitName != "")
                    Session["FruitName"] = tempFruitName;
                FruitName = Session["FruitName"].ToString();
                
                //TextBox1.Text = FruitName;
                Fruits f = DALFruits.GetInfoByName(FruitName);

                txtfName.Text = f.FruitName;
                txtfComment.Text = f.FruitComment;
                txtfNp.Text = f.FruitNPrice.ToString();
                txtfOp.Text = f.FruitOPrice.ToString();

                fimg.ImageUrl = f.FruitImage;

                //初始化数量
                txtNum.Text = "1";
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(txtNum.Text.Trim().ToString());
            if(temp>0)
                temp--;
            txtNum.Text = temp.ToString();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(txtNum.Text.Trim().ToString());
            temp++;
            txtNum.Text = temp.ToString();
        }

        protected void btnAddShopCar_Click(object sender, EventArgs e)
        {
            string username;
            if (Session["UserName"] == null)
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请先登录!');location='login.aspx';</script>");
            else
            {
                username = Session["UserName"].ToString();
                int userid = DALUsers.GetUserIdByName(username);
                FruitName = Session["FruitName"].ToString();
                int fruitid = DALFruits.GetFruitIdByName(FruitName);
                int fruitnum = Convert.ToInt32(txtNum.Text.Trim());
                float fruitprice =(float)Convert.ToDouble(txtfNp.Text.Trim());
                ShopCar item = new ShopCar(userid, fruitid, fruitnum, fruitprice);
                int status = DALShopCar.AddFruitToShopCar(item);
                if(status==1)
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功!');</script>");
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加失败!');</script>");


            }
        }
    }
}