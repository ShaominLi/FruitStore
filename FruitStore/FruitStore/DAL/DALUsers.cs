using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FruitStore.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
//using FruitStore.Model;

namespace FruitStore.DAL
{
    public class DALUsers
    {
        //用户登录处理
        public static int UserLogin(string username, string password)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //打开数据库连接
                conn.Open();
                //进行一系列操作
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand();
                //为Command属性赋值
                cmd.Connection = conn;
                //Text类型的命令
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select count(*) from UserInfo where UserVName= @username and UserPsw=@password";
                SqlParameter name = new SqlParameter("@username", SqlDbType.NVarChar, 50);
                name.Value = username;
                SqlParameter psw = new SqlParameter("@password", SqlDbType.NVarChar, 50);
                psw.Value = password;
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(psw);

                //执行SqlCommand对象
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;

            }
        }

        //添加员工信息
        public static int AddUser(Users user)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //打开数据库连接
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                //为Command属性赋值
                cmd.Connection = conn;
                //Text类型的命令
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = String.Format("select Count(*) from UserInfo where UserVName='{0}';", user.UserVName);

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                //当DataReader对象有值时进行循环取值
                if (result > 0)
                {
                    //记录重复
                    return -1;

                }else{
                    SqlCommand sub = new SqlCommand();
                    //为Command属性赋值
                    cmd.Connection = conn;
                    //Text类型的命令
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = String.Format("insert into UserInfo values('{0}','{1}','{2}','{3}','{4}');"
                        , user.UserVName,user.UserPsw,user.UserTName,user.UserAdress,user.UserPhone);
                    int res = Convert.ToInt32(cmd.ExecuteNonQuery());
                    if (res == 1)
                    {
                        return 1;//成功
                    }
                    else
                    {
                        return 0;//失败
                    }

                }


            }



        }

        //修改密码
        public static int ModifyPassword(string username, string oldpassword, string newpassword)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //打开数据库连接
                conn.Open();
                //进行一系列操作
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand();
                //为Command属性赋值
                cmd.Connection = conn;
                //Text类型的命令
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select count(*) from UserInfo where UserVName= @username and UserPsw=@password";
                SqlParameter name = new SqlParameter("@username", SqlDbType.NVarChar, 50);
                name.Value = username;
                SqlParameter psw = new SqlParameter("@password", SqlDbType.NVarChar, 50);
                psw.Value = oldpassword;
                cmd.Parameters.Add(name);
                cmd.Parameters.Add(psw);

                //执行SqlCommand对象
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result == 0)
                {
                    return -1;//原密码错误
                }
                else
                {
                    //有原密码，则修改密码
                    SqlCommand sub = new SqlCommand();
                    //为Command属性赋值
                    cmd.Connection = conn;
                    //Text类型的命令
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = String.Format("update UserInfo set UserPsw='{0}' where UserVName='{1}';", newpassword, username);
                    int res = Convert.ToInt32(cmd.ExecuteNonQuery());
                    if (res == 1)
                    {
                        return 1;//成功
                    }
                    else
                    {
                        return 0;//失败
                    }
                }

            }
        }

        //根据用户名查询信息
        public static Users GetInfoByName(string username)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //打开数据库连接
                conn.Open();
                //进行一系列操作
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand();
                //为Command属性赋值
                cmd.Connection = conn;
                //Text类型的命令
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format("select * from UserInfo where UserVName='{0}' ",username);
                //执行SqlCommand对象
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //存储数据
                string vname=ds.Tables[0].Rows[0]["UserVName"] as string;
                string psw=ds.Tables[0].Rows[0]["UserPsw"] as string;
                string tname=ds.Tables[0].Rows[0]["UserTName"] as string;
                string addr=ds.Tables[0].Rows[0]["UserAdress"] as string;
                string phone=ds.Tables[0].Rows[0]["UserPhone"] as string;
                Users me=new Users(vname,psw,tname,addr,phone);

                return me;

            }

        }

        //根据用户名查询ID
        public static int GetUserIdByName(string username)
        {
            string connectionStr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //打开数据库连接
                conn.Open();
                //进行一系列操作
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand();
                //为Command属性赋值
                cmd.Connection = conn;
                //Text类型的命令
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format("select UserId from UserInfo where UserVName='{0}' ", username);
                //执行SqlCommand对象
                int id = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                return id;

            }

        }

        //管理收货信息
        public static DeliveryInfo GetDeliveryInfo(string username)
        {
            int userid = GetUserIdByName(username);
            string connectionStr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //打开数据库连接
                conn.Open();
                //进行一系列操作
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand();
                //为Command属性赋值
                cmd.Connection = conn;
                //Text类型的命令
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format("select * from DeliveryAddressinfo where UserId={0} ", userid);
                //执行SqlCommand对象
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //存储数据
                string vname = ds.Tables[0].Rows[0]["UserVName"] as string;
                string addr = ds.Tables[0].Rows[0]["DeliveryAddress"] as string;
                string phone = ds.Tables[0].Rows[0]["UserPhone"] as string;
                DeliveryInfo temp = new DeliveryInfo(userid, addr, vname, phone);

                return temp;

            }

        }
       
        //修改收货地址
        public static int ModifyAdressByUserName(string username,string adress)
        {
            int userid = GetUserIdByName(username);
            string connectionStr = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                //打开数据库连接
                conn.Open();
                //进行一系列操作
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand();
                //为Command属性赋值
                cmd.Connection = conn;
                //Text类型的命令
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = string.Format("update DeliveryAddressinfo set DeliveryAddress='{0}' where UserId={1} ",adress, userid);
                //执行
                int result = Convert.ToInt32(cmd.ExecuteNonQuery());
                

                return result;

            }

        }
    }
}