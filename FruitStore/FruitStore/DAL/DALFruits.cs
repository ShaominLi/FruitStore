using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using FruitStore.Model;
using System.Configuration;
using System.Web.UI.WebControls;


namespace FruitStore.DAL
{
    public class DALFruits
    {
        //显示全部信息
        public static PagedDataSource SelectAllInfo(int num, out int sumpage)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select f.*,i.FGroupName from FruitInfo f left join FruitGroupInfo i on f.FruitGroupId=i.FGroupId ;";
                cmd.Connection = conn;
                //cmd.ExecuteReader();
                DataSet dsUser = new DataSet();
                //SqlDataAdapter sadapter = new SqlDataAdapter(cmd);
                SqlDataAdapter sadapter = new SqlDataAdapter();
                sadapter.SelectCommand = cmd;
                sadapter.Fill(dsUser,"name");

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dsUser.Tables["name"].DefaultView;
                pds.AllowPaging = true;//允许分页
                pds.PageSize = 8;//单页显示项数
                int curpage = num;
                
                pds.CurrentPageIndex = curpage - 1;
                sumpage = pds.PageCount;
                
                return pds;
            }
        }

         //根据水果名查询信息
        public static Fruits GetInfoByName(string fruitname)
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
                cmd.CommandText = string.Format("select * from FruitInfo where FruitName='{0}'; ", fruitname);
                //执行SqlCommand对象
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //存储数据
                string fname = ds.Tables[0].Rows[0]["FruitName"] as string;
                string fimg = ds.Tables[0].Rows[0]["FruitImage"] as string;
                int fgroupid = (int)(ds.Tables[0].Rows[0]["FruitGroupId"]);
                string fcomment = ds.Tables[0].Rows[0]["FruitComment"] as string;
                float fop = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["FruitOPrice"]);
                float fnp = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["FruitNPrice"]);
                Fruits f = new Fruits(fname,fgroupid,fimg,fcomment,fop,fnp);

                return f;
            }
        }

        //根据水果ID查询水果信息
        public static Fruits GetInfoByID(int fruitid)
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
                cmd.CommandText = string.Format("select * from FruitInfo where FruitId={0}; ", fruitid);
                //执行SqlCommand对象
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                //存储数据
                string fname = ds.Tables[0].Rows[0]["FruitName"] as string;
                string fimg = ds.Tables[0].Rows[0]["FruitImage"] as string;
                int fgroupid = (int)(ds.Tables[0].Rows[0]["FruitGroupId"]);
                string fcomment = ds.Tables[0].Rows[0]["FruitComment"] as string;
                float fop = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["FruitOPrice"]);
                float fnp = (float)Convert.ToDouble(ds.Tables[0].Rows[0]["FruitNPrice"]);
                Fruits f = new Fruits(fname, fgroupid, fimg, fcomment, fop, fnp);

                return f;
            }
        }

         //根据水果名查询ID
        public static int GetFruitIdByName(string fruitname)
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
                cmd.CommandText = string.Format("select FruitId from FruitInfo where FruitName='{0}' ", fruitname);
                //执行SqlCommand对象
                int id = Convert.ToInt32(cmd.ExecuteScalar());

                return id;

            }
        }

        //显示分组信息
        public static PagedDataSource SelectAllInfoByGroup(int num, out int sumpage,int groupid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString.ToString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = string.Format("select f.*,i.FGroupName from FruitInfo f left join FruitGroupInfo i on f.FruitGroupId=i.FGroupId where i.FGroupId={0} ;", groupid);
                cmd.Connection = conn;
                //cmd.ExecuteReader();
                DataSet dsUser = new DataSet();
                //SqlDataAdapter sadapter = new SqlDataAdapter(cmd);
                SqlDataAdapter sadapter = new SqlDataAdapter();
                sadapter.SelectCommand = cmd;
                sadapter.Fill(dsUser, "name");

                PagedDataSource pds = new PagedDataSource();
                pds.DataSource = dsUser.Tables["name"].DefaultView;
                pds.AllowPaging = true;//允许分页
                pds.PageSize = 8;//单页显示项数
                int curpage = num;

                pds.CurrentPageIndex = curpage - 1;
                sumpage = pds.PageCount;

                return pds;
            }
        }

        //根据组ID查询组名
        public static string getGroupNameByGID(int gid)
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
                cmd.CommandText = string.Format("select FGroupName from FruitGroupInfo where FGroupId={0} ", gid);
                //执行SqlCommand对象
                string name = cmd.ExecuteScalar().ToString();

                return name;

            }

        }

        //查询所有类别
        public static DataTable getAllGroupName()
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
                cmd.CommandText = "select * from FruitGroupInfo ;";
                //执行SqlCommand对象
                 SqlDataAdapter adaHand = new SqlDataAdapter(cmd.CommandText, conn);
               
                DataSet setHand = new DataSet();
                adaHand.Fill(setHand, "tables");
                setHand.RemotingFormat = SerializationFormat.Binary;
               
                DataTable tmpTable=setHand.Tables[0];
                //string gNames="";

                //for (int i = 0; i < tmpTable.Rows.Count; i++)
                //{
                //    string name = tmpTable.Rows[i]["FGName"].ToString();
                //    gNames=gNames+"+"+name;
                //}
                //return gNames;
                return tmpTable;

            }
        }

        //删除水果根据ID
        public static int deleteFruitByID(int id){
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
                cmd.CommandText = string.Format("delete from FruitInfo where FruitId='{0}' ", id);
                //执行SqlCommand对象
                int result = cmd.ExecuteNonQuery();

                return result;

            }
        }

        //添加新水果
        public static int insertFruit(Fruits f){
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
                cmd.CommandText = string.Format("insert into FruitInfo values({0},'{1}','{2}','{3}',{4},{5}); "
                    , f.FruitGroupId,f.FruitName,f.FruitImage,f.FruitComment,f.FruitOPrice,f.FruitNPrice);
                //执行SqlCommand对象
                int result = cmd.ExecuteNonQuery();

                return result;

            }
        }

    }
}