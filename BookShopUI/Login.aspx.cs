using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShopBLL;
using BookShopModel;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace BookShopUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //记住用户名
            if (!IsPostBack)
            {
                this.TextBox1.Focus();
                if (!Object.Equals(Request.Cookies["UserName"], null))
                {
                    HttpCookie readcookie = Request.Cookies["UserName"];
                    this.TextBox1.Text = readcookie.Value;
                }
            }

        }

       
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //跳转注册页面
            Response.Redirect("Register.aspx");
        }
 
        protected void Button1_Click(object sender, EventArgs e)
        {
                UserModel UserName = new UserModel();
                 UserName.UserName = TextBox1.Text.Trim().ToLower();
                int name = UserBLL.UserNames(UserName);

            //判断用户名是否在数据库里存在
                if (name == 1)
                {
                    string UserPwd = TextBox2.Text;
                    int success = UserBLL.UserLogin(UserPwd);
                    //判断用户密码是否正确
                    if (success == 1)
                    {
                        UserModel u = new UserModel();
                        u.UserName = TextBox1.Text.Trim().ToLower();
                        Del.Text = UserBLL.GetDelete(u.UserName).ToString();
                        //判断用户是否被封禁
                        if (Del.Text == "0")
                        {
                            UserModel ur = new UserModel();
                            ur.UserName = TextBox1.Text.Trim().ToLower();
                            admin.Text = UserBLL.GetAdmin(ur.UserName).ToString();
                            Session["UName"] = TextBox1.Text;
                            Session["Admin"] = admin.Text;
                            Response.Write(@"<script>alert('登录成功！');</script>");//全部没问题，就登录成功
                            Response.Redirect("index.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('用户已被封禁')</script>");
                        }
                    }
                    else
                        Response.Write("<script>alert('密码错误,请重新输入')</script>");
                }
                else
                    Response.Write("<script>alert('该用户不存在或用户名输入错误')</script>");

            if (object.Equals(Request.Cookies["UId"], null))
            {
                CreateCookie();
            }
            else
            {
                CreateCookie();
            }

 
        }
        /// <summary>
        /// cookie函数
        /// </summary>
        private void CreateCookie()
        {
            HttpCookie cookie = new HttpCookie("UserName");
            if (this.cbxRemeberUser.Checked)
            {
                cookie.Value = this.TextBox1.Text;
            }
            cookie.Expires = DateTime.MaxValue;
            Response.AppendCookie(cookie);
        }
        
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("findpsw.aspx");//跳转找回密码
        }
    }
}