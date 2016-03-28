using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FruitStore.Model;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

//using FruitStore.Model;

namespace FruitStore.DAL
{
    public class DALOrders
    {
        //根据状态id查询状态信息
        public static string GetStatusById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("select statusComments from orderStatus where statusid={0};", id);
                cmd.Connection = conn;
                string status = cmd.ExecuteScalar().ToString();
                return status;
            }
        }

        //根据orderid查询状态id
        public static int GetIdByID(int orderid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("select i.StatusId from OrderInfo f left join OrderStatus i on f.OrderStatus=i.StatusComments where OrderId ='{0}';", orderid);
                cmd.Connection = conn;
                int id =Convert.ToInt32(cmd.ExecuteScalar());
                return id;
            }
        }

        //显示用户全部订单
        public static DataTable SelectAllInfo(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("select i.*,j.Next from OrderInfo i left join OrderStatus j on i.OrderStatus=j.StatusComments where OrderUserName='{0}' ;", username);
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

        //存入订单
        public static int InsertOrder(OrderInfo order)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("insert into OrderInfo(OrderPrice,OrderUserName,OrderUserAdress,OrderUserPhone,OrderTime,OrderStatus,OrderUserComment) values({0},'{1}','{2}','{3}','{4}','{5}','{6}');"
                    ,order.Price,order.Username,order.Useradress,order.Phone,order.Time,order.Status,order.Usercomment);
                cmd.Connection = conn;
                int status =Convert.ToInt32(cmd.ExecuteNonQuery());
                return status;
            }

        }

        //更改用户状态
        public static int ModifyOrderStatus(int orderid, string status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("update OrderInfo set OrderStatus='{0}' where OrderId={1};",status,orderid);
                cmd.Connection = conn;
                int flag = Convert.ToInt32(cmd.ExecuteNonQuery());
                return flag;
            }

        }

        //删除订单
        public static void DeleteOrderByOrderId(int orderid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("delete from OrderInfo where OrderId={0};", orderid);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }

        }
    }
}