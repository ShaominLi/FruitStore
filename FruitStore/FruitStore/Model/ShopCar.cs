using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FruitStore.Model
{
    public class ShopCar
    {
        private int userid;

        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        private int fruitid;

        public int Fruitid
        {
            get { return fruitid; }
            set { fruitid = value; }
        }
        private int fruitnum;

        public int Fruitnum
        {
            get { return fruitnum; }
            set { fruitnum = value; }
        }
        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private float sumprice;

        public float Sumprice
        {
            get { return sumprice; }
            set { sumprice = value; }
        }

        public ShopCar(int uid,int fid,int fnum,float price)
        {
            Userid = uid;
            Fruitid = fid;
            Fruitnum = fnum;
            Price = price;
        }

    }
}