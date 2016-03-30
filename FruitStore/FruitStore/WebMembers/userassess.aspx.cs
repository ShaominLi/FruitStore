using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.DAL;

namespace FruitStore.WebMembers
{
    public partial class userassess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string orderid = Request.QueryString["id"];
            int id = Convert.ToInt32(orderid);
            string assess = txtUserAssess.Text;
            if (assess != "")
            {
                DALOrders.ModifyOrderStatus(id, DALOrders.GetStatusById(4));
                DALOrders.SetAssess(id, assess);
                Response.Write("<script language=javascript>alert('评价成功！');</script>");
            }
               
            Response.Write("<script language=javascript>location='myorders.aspx';</script>");

        }
    }
}