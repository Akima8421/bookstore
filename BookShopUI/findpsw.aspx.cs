using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShopModel;
using BookShopBLL;

namespace BookShopUI
{
    public partial class findpsw : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 找回密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            UserModel myuser = new UserModel();
            myuser.UserName = tbName.Text.Trim().ToLower();
            myuser.Email = tbEmail.Text;
            myuser.UserPwd = tbPwd1.Text;
            int success = UserBLL.FindPwd(myuser);
            int change = UserBLL.ChangePwd(myuser);
            try 
            {
                if (success == 1)//先判断用户名，邮箱是否正确
                {
                    if (change == 1)//提示相应信息
                    {
                        Response.Write(@"<script>alert('修改成功！');</script>");
                    }
                    else
                    {
                        Response.Write(@"<script>alert('修改失败！');</script>");
                    }
                }
                else
                {
                    Response.Write(@"<script>alert('用户名或邮箱地址错误，请重新输入！');</script>");
                }
            }
            catch {
                Response.Write(@"<script>alert('修改异常！');</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}