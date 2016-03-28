using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FruitStore.Model;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FruitStore.DAL
{
    public class DALShopCar
    {
        //加入购物车
        public static int AddFruitToShopCar(ShopCar item)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = string.Format("select COUNT(*) from ShopCar where UserId={0} and FruitId={1};"
                    ,item.Userid, item.Fruitid);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                int status;
                if (result != 0)
                {
                    cmd.CommandText = string.Format("update ShopCar set FruitNum+={0} where UserId={1} and FruitId ={2};"
                   , item.Fruitnum ,item.Userid, item.Fruitid);
                    //cmd.Connection = conn;
                    status = Convert.ToInt32(cmd.ExecuteNonQuery());
                    
                }
                else
                {
                    cmd.CommandText = string.Format("insert into ShopCar values({0},{1},{2},{3});"
                    , item.Userid, item.Fruitid, item.Fruitnum, item.Price);
                   // cmd.Connection = conn;
                    status = Convert.ToInt32(cmd.ExecuteNonQuery());
          
                }
                return status;
            }
        }

        //根据用户id查询购物车
        public static DataTable GetInfoByUserId(int userid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("select f.*,i.FruitName,i.FruitImage from ShopCar f left join FruitInfo i on f.FruitId=i.FruitId  where UserId={0};", userid);
                cmd.Connection = conn;
                //cmd.ExecuteReader();
                DataSet dsUser = new DataSet();
                //SqlDataAdapter sadapter = new SqlDataAdapter(cmd);
                SqlDataAdapter sadapter = new SqlDataAdapter();
                sadapter.SelectCommand = cmd;
                sadapter.Fill(dsUser);
                DataTable dtable = new DataTable();
                dtable = dsUser.Tables[0];
                return dtable;
            }
        }

        //根据ID删除item
        public static DataTable DeleteItemByID(int id,out int status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = string.Format("select UserId from ShopCar where ID={0};",id);
                int userid = Convert.ToInt32(cmd.ExecuteScalar());
                Convert.ToInt32(cmd.ExecuteNonQuery());

                cmd.CommandText = string.Format("delete from ShopCar where ID={0};", id);
                status = Convert.ToInt32(cmd.ExecuteNonQuery());

                return GetInfoByUserId(userid);

            }
        }

        //计算某人的订单总额
        public static float SumOfUser(int userid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = string.Format("select count(*) from ShopCar where UserId={0};", userid);
                int num = Convert.ToInt32(cmd.ExecuteScalar());
                float sum = 0;
                if (num != 0)
                {
                    cmd.CommandText = string.Format("select SUM(FruitSumPrice) from ShopCar where UserId={0};", userid);
                    sum = (float)Convert.ToDouble(cmd.ExecuteScalar());
                }
                return sum;
            }

        }

        //清空购物车
        public static void ClearShopCar(int userid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("delete from ShopCar where UserId={0};", userid);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }

        }

    }
}