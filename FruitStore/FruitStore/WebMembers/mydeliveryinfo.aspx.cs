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
    public partial class mydeliveryinfo : System.Web.UI.Page
    {
        private string adr;

        public string Adr
        {
            get { return adr; }
            set { adr = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Adr = Session["Adr"].ToString();
                string Username = Session["UserName"].ToString();
                if (newadr.Text!="")
                    Adr += (newadr.Text + "+");

                string DalAdr = Request.Form["DelAdr"].ToString();
                //string DalAdr = DelAdr.Value.ToString();
                if (DalAdr != "")
                {
                    string[] sArray = Adr.Split('+');
                    string newAdr = "";
                    foreach (string i in sArray)
                    {
                        if (i != DalAdr && i!="")
                        {
                            newAdr += (i + "+");
                        }

                    }

                    Adr = newAdr;
                }
                DALUsers.ModifyAdressByUserName(Username, Adr);

            }

                if (Session["UserName"] == null)
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请先登录!');location='login.aspx';</script>");
                else
                {
                    string Username = Session["UserName"].ToString();
                    DeliveryInfo my = DALUsers.GetDeliveryInfo(Username);

                    txtName.Text = my.Uservname;
                    txtPhon.Text = my.Userphone;
                    int index = my.Deliveryadress.IndexOf("+");
                    if (index == my.Deliveryadress.Length)
                    {
                        txtAdr.Text = my.Deliveryadress;
                    }
                    else
                    {
                        int length = my.Deliveryadress.Length;
                        string temp = my.Deliveryadress.Substring(0, index);
                        my.Deliveryadress = my.Deliveryadress.Substring(index + 1, length - index - 1);
                        txtAdr.Text = temp;

                        index = my.Deliveryadress.IndexOf("+");
                        length = my.Deliveryadress.Length;
                        while (index != my.Deliveryadress.Length && index > 0)
                        {
                            temp = my.Deliveryadress.Substring(0, index);
                            my.Deliveryadress = my.Deliveryadress.Substring(index + 1, length - index - 1);

                            TableRow tr = new TableRow();
                            TableCell tc1 = new TableCell();
                            TableCell tc2 = new TableCell();
                            TextBox t = new TextBox();
                            t.Width = 400;
                            t.ID = "tb" + myinfo.Rows.Count;
                            t.Text = temp;

                            LinkButton lb_sub = new LinkButton();
                            lb_sub.Text = "-";
                            lb_sub.OnClientClick = "del(this)";
                            lb_sub.ID = temp;

                            tc2.Controls.Add(t);
                            tc2.Controls.Add(lb_sub);

                            tr.Cells.Add(tc1);
                            tr.Cells.Add(tc2);
                            myinfo.Rows.Add(tr);
                            index = my.Deliveryadress.IndexOf("+");
                            length = my.Deliveryadress.Length;
                        }

                    }
                }
                Adr = "";
                GetValue(myinfo);
                Session["Adr"] = Adr;
         }
        public void GetValue(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c.HasControls())
                {
                    GetValue(c);
                }

                 if (c is TextBox)
                 {
                      TextBox tb = (TextBox)c;
                      Adr+=(tb.Text+"+");
                 }
              
            }
        }


        protected void add_Click(object sender, EventArgs e)
        {
    
            newadr.Visible = true;
            newadr.Text = "";

        }
        protected void sub_Click(object sender, EventArgs e)
        {
            

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            Adr += txtAdr.Text;
        }


    }
}