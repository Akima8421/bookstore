using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShopModel;
using BookShopBLL;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BookShopUI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;//注册按钮不可点击状态
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //获取用户名密码等信息
            Session["User"] = tbName.Text;
            UserModel newUser = new UserModel();
            newUser.UserName = tbName.Text.Trim().ToLower();
            newUser.UserPwd = tbPwd1.Text;
            newUser.Email = tbEmail.Text;
            newUser.Tel = tbPhone.Text;
            int success = UserBLL.UserRegiste(newUser);
            //执行注册操作
            try
            {
                if (success == 1)
                    Response.Write(@"<script>alert('注册成功！');</script>");
                else
                    Response.Write("<script>alert('注册失败')</script>");
            }
            catch
            {
                Response.Write("<script>alert('注册异常')</script>");
            }



        }
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserModel NewUser = new UserModel();
                NewUser.UserName = tbName.Text.Trim().ToLower();
                int repeat = UserBLL.UserNames(NewUser);
                try
                {
                    if (repeat == 1)
                    {
                        //Response.Write(@"<script>alert('用户名已存在');</script>");
                        Label1.Text = "用户名已存在";
                    }
                    else
                    {
                        //Response.Write(@"<script>alert('用户名可用');</script>");
                        Label1.Text = "用户名可用";
                        btnRegister.Enabled = true;//用户名可用，注册按钮变成可点击状态
                    }
                }
                catch
                {
                    Response.Write("<script>alert('用户名检测异常')</script>");
                }
        }

        protected void linkToLogin_Click(object sender, EventArgs e)
        {
            //跳转登录页面
            Response.Redirect("Login.aspx");
        }
    }
}