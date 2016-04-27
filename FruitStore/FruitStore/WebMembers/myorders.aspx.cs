using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.DAL;
using FruitStore.Model;
using System.Data;

namespace FruitStore.WebMembers
{
    public partial class myorders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请先登录!');location='login.aspx';</script>");
                else
                {
                    //string username = Session["UserName"].ToString();
                    //OrdersList.DataSource = DALOrders.SelectAllInfo(username);
                    //OrdersList.DataBind();                   
                    InitData();
                }
            }
        }

        protected void OrdersList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Next":{
                    int orderid = Convert.ToInt32(e.CommandArgument);
                    int status = DALOrders.GetIdByID(orderid);
                    switch(status){
                        //付款操作
                        case 0: {
                            Response.Write("<script>alert('付款成功!');</script>");
                            DALOrders.ModifyOrderStatus(orderid, DALOrders.GetStatusById(1));
                            break;
                        }
                        //等待发货
                        case 1: {
                            Response.Write("<script>alert('已催卖家，请耐心等待!');</script>");
                            break; 
                        }
                        //确认收货
                        case 2: {
                            Response.Write("<script>alert('确认收货成功!');</script>");
                            DALOrders.ModifyOrderStatus(orderid, DALOrders.GetStatusById(3));
                            break;
                        }
                        //评价
                        case 3: {
                            string url = string.Format("<script>location='userassess.aspx?id={0}';</script>", orderid);
                            Response.Write(url);
                                                                                  
                            break; 
                        }
                        //删除订单
                        default: {
                            Response.Write("<script>alert('订单已删除!');</script>");

                            DALOrders.DeleteOrderByOrderId(orderid);
                            break; 
                        }
                    }
                    break;
                }
                default:
                    break;
            }
           Response.Write("<script language=javascript>location='myorders.aspx';</script>"); 
        }

        protected void InitData()
        {
            string username = Session["UserName"].ToString();
            OrdersList.DataSource = DALOrders.SelectAllInfo(username);
            OrdersList.DataBind();
        }

        protected void OrdersList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("fruitlist") as Repeater;//找到里层的repeater对象  
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项  
                int orderid = Convert.ToInt32(rowv["OrderId"]);//获取填充子类的id 
                string username = Session["UserName"].ToString();
                int userid = DALUsers.GetUserIdByName(username);
                rep.DataSource = DALShopCar.GetInfoByUserId(userid,orderid);
                rep.DataBind();
            }  
        }

    }
}