using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.DAL;

namespace FruitStore.WebMembers.AdminWebs
{
    public partial class sendfruit : System.Web.UI.Page
    {
        static private int curPage = 1;

        static private int sumPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtCurPage.Text = "1";
                pageload();
                txtSumPage.Text = sumPage.ToString();
            }
        }

        protected void OrderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "SendFruit":
                    {
                        string []txtExpress=new string[2];
                        foreach (RepeaterItem item in OrderList.Items)
                        {
                            TextBox t1=(TextBox)item.FindControl("txtExpressCompany");
                            TextBox t2=(TextBox)item.FindControl("txtExpresNumber");

                            txtExpress[0] = t1.Text;
                            txtExpress[1] = t2.Text;

                            if ((txtExpress[0] != "") && (txtExpress[1] != ""))
                                break; 
                        }
                        if ((txtExpress[0] == "") || (txtExpress[1] == ""))
                            Response.Write("<script language=javascript>alert('请完善快递信息！');</script>"); 
                        else
                        {
                            int orderid = Convert.ToInt32(e.CommandArgument);
                            int result = DALOrders.SendFruit(orderid,txtExpress[0],txtExpress[1]);
                            Response.Write("<script language=javascript>alert('发货成功！');</script>");
                        }
                       break;
                    }
                default:

                    break;
            }
            Response.Write("<script language=javascript>location='sendfruit.aspx';</script>"); 

        }
        public void pageload()
        {
            OrderList.DataSource = DALOrders.SelectNotSendInfo(curPage, out sumPage);

            this.btnDownPage.Enabled = true;
            this.btnUpPage.Enabled = true;

            if (curPage == 1)
            {
                this.btnUpPage.Enabled = false;
            }
            if (curPage == sumPage)
            {
                this.btnDownPage.Enabled = false;
            }

            OrderList.DataBind();

        }
        protected void btnUp_Click(object sender, EventArgs e)
        {
            curPage -= 1;
            txtCurPage.Text = Convert.ToString(curPage);
            pageload();

        }

        protected void btnDown_Click(object sender, EventArgs e)
        {
            curPage += 1;
            txtCurPage.Text = Convert.ToString(curPage);
            pageload();
        }
        protected void btnHeadPage_Click(object sender, EventArgs e)
        {
            curPage = 1;
            txtCurPage.Text = Convert.ToString(curPage);
            pageload();
        }
        protected void btnRealPage_Click(object sender, EventArgs e)
        {
            curPage = sumPage;
            txtCurPage.Text = Convert.ToString(curPage);
            pageload();
        }
    }
}