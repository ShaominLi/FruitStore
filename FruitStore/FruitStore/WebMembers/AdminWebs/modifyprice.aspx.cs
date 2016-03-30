using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.DAL;

namespace FruitStore.WebMembers.AdminWebs
{
    public partial class modifyprice : System.Web.UI.Page
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

        protected void FruitList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Modify":
                    
                    string url = string.Format("<script>location='modifyweb.aspx?id={0}';</script>", id);
                    Response.Write(url);
                                                                                  
                    break;
                case "Delete":
                    DALFruits.deleteFruitByID(Convert.ToInt32(id));
                    Response.Write("<script>location='modifyprice.aspx';</script>");
                    break;
                default:
                    break;
            }
        }



        public void pageload()
        {
            FruitList.DataSource = DALFruits.SelectAllInfo(curPage, out sumPage);

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

            FruitList.DataBind();

        }
 
        protected void btnHeadPage_Click(object sender, EventArgs e)
        {
            curPage = 1;
            txtCurPage.Text = Convert.ToString(curPage);
            pageload();
        }

        protected void btnUpPage_Click(object sender, EventArgs e)
        {
            curPage -= 1;
            txtCurPage.Text = Convert.ToString(curPage);
            pageload();
        }

        protected void btnDownPage_Click(object sender, EventArgs e)
        {
            curPage += 1;
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