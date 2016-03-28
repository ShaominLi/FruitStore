using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FruitStore.DAL;

namespace FruitStore.Model
{
    public class OrderInfo
    {
        float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        string useradress;

        public string Useradress
        {
            get { return useradress; }
            set { useradress = value; }
        }
        string time;

        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        string userconment;

        public string Usercomment
        {
            get { return userconment; }
            set { userconment = value; }
        }
        string userassess;

        public string Userassess
        {
            get { return userassess; }
            set { userassess = value; }
        }
        string admassess;

        public string Admassess
        {
            get { return admassess; }
            set { admassess = value; }
        }
        string expresscompany;

        public string Expresscompany
        {
            get { return expresscompany; }
            set { expresscompany = value; }
        }
        string expressnumber;

        public string Expressnumber
        {
            get { return expressnumber; }
            set { expressnumber = value; }
        }
        public OrderInfo(float price,string uname,string adr,string phone,int status,string ucom=""
            ,string uassess="",string aassess="",string expressname="",string expressnumber="")
        {
            Price = price;
            Username = uname;
            Useradress = adr;
            Phone = phone;
            Status = DALOrders.GetStatusById(status);
            
            Usercomment = ucom;
            Userassess = uassess;
            Admassess = aassess;
            Expresscompany = expressname;
            Expressnumber = expressnumber;
            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
        }
    }
}