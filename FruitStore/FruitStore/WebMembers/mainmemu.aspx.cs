using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.DAL;

namespace FruitStore.WebMembers
{
    public partial class mainmemu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FruitList.DataSource = DALFruits.SelectAllInfo();
            FruitList.DataBind();
        }
    }
}