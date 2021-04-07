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
    public partial class changepwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UName"] == null)
            {
                Response.Write("<script>alert('用户请登录');window.location.href='Login.aspx'</script>");//未登录，相应提示
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void changepassword_Click(object sender, EventArgs e)
        {   
            UserModel myuser = new UserModel();
            myuser.UserName = Session["UName"].ToString();
            myuser.UserPwd = oldpwd.Text;
            int success = UserBLL.ComparePwd(myuser); // 比较新密码和旧密码
            int change = UserBLL.NewPwd(myuser); //修改密码操作
                if (success == 1)
                {
                    myuser.UserPwd = newpwd.Text;
                    if (change == 1)
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
                    Response.Write(@"<script>alert('旧密码错误，请重新输入！');</script>");
                }
        }
    }
}