using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FruitStore.Model;
using FruitStore.DAL;
using System.IO;
using System.Drawing;

namespace FruitStore.WebMembers.AdminWebs
{
    public partial class modifyweb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GroupList.DataSource = DALFruits.getAllGroupName();
                GroupList.DataTextField = "FGroupName";
                GroupList.DataValueField = "FGroupId";
                GroupList.DataBind();
                GroupList.SelectedIndex = 0;

                string id = Request.QueryString["id"];
                int fruitid = Convert.ToInt32(id);
                if (fruitid != 0)
                {
                    Fruits f = DALFruits.GetInfoByID(fruitid);
                    Fruitimg.ImageUrl = f.FruitImage;
                    txtFruitName.Text = f.FruitName;
                    txtNPrice.Text = f.FruitNPrice.ToString();
                    txtOPrice.Text = f.FruitOPrice.ToString();
                    txtFruitComment.Text = f.FruitComment;
                    GroupList.SelectedValue = f.FruitGroupId.ToString();
                }
                lbl_pic.Text = "";

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //是否新图片
            Boolean fileOk = false;
            string picpath=Fruitimg.ImageUrl;
            if (pic_upload.HasFile)//验证是否包含文件
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);
                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件宽度不能超过319，高度不超过220

                    System.Drawing.Image img = System.Drawing.Image.FromStream(pic_upload.FileContent);
                    if (img.Width == 319 || img.Height == 220)
                    {
                        // 处理代码
                        string filepath = Server.MapPath("~")+"\\Images\\fruits\\"; 
                        //if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        //{
                        //    Directory.CreateDirectory(Server.MapPath(filepath));
                        //}
                        picpath = filepath + txtFruitName.Text + fileExtension;//这是路径

                        pic_upload.PostedFile.SaveAs(picpath);//保存图片
                        //显示图片
                        Fruitimg.ImageUrl = picpath;
                        //清空提示
                        lbl_pic.Text = "";
                        picpath = "~//Images//fruits//" + txtFruitName.Text + fileExtension;
                    }
                    else
                    {
                        Fruitimg.ImageUrl = "";
                        lbl_pic.Text = "文件大小不合适！请重新选择！";
                    }
                }
                else
                {
                    Fruitimg.ImageUrl = "";
                    lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                }
            }
            if (lbl_pic.Text == "")
            {
                //int flag = Convert.ToInt32(Request.Form["flag"].ToString());
                string name = txtFruitName.Text;
                int gid = Convert.ToInt32(GroupList.SelectedValue);
                string com = txtFruitComment.Text;
                float op = (float)Convert.ToDouble(txtOPrice.Text);
                float np = (float)Convert.ToDouble(txtNPrice.Text);
                Fruits f = new Fruits(name, gid, picpath, com, op, np);

                string id = Request.QueryString["id"];
                int fruitid = Convert.ToInt32(id);
                int result1 = DALFruits.deleteFruitByID(fruitid);
                int result2 = DALFruits.insertFruit(f);
                
                Response.Write("<script>location='modifyprice.aspx';</script>");
            }
        }

        public bool IsImage(string str)
        {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".bmp", ".png" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }
    }
  }




     