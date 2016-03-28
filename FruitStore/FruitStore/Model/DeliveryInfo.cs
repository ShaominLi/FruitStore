using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStore.Model
{
    public class DeliveryInfo
    {
        int userid;

        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        string deliveryadress;

        public string Deliveryadress
        {
            get { return deliveryadress; }
            set { deliveryadress = value; }
        }
        string uservname;

        public string Uservname
        {
            get { return uservname; }
            set { uservname = value; }
        }
        string userphone;

        public string Userphone
        {
            get { return userphone; }
            set { userphone = value; }
        }
        public DeliveryInfo(int id, string adr, string name, string phone)
        {
            Userid = id;
            Deliveryadress = adr;
            Uservname = name;
            Userphone = phone;

        }
    }
}