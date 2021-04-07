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
    public partial class userinformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //获取用户各种信息
                string s = Convert.ToString(Session["UName"]);
                UserModel myuser = new UserModel();
                myuser = UserBLL.GetUser(s);
                lbName.Text = myuser.UserName;
                lbEmail.Text = myuser.Email;
                lbTel.Text = myuser.Tel;
                lbAddress.Text = myuser.Address;

                //将用户信息存入session
                UserModel userinfo = new UserModel();
                userinfo.UserName = lbName.Text;
                userinfo.Email = lbEmail.Text;
                userinfo.Tel = lbTel.Text;
                userinfo.ID = myuser.ID;
                userinfo.Admin = myuser.Admin;
                userinfo.Address = myuser.Address;
                Session["userinfo"] = userinfo;
            }
            catch
            {
                Response.Write("<script>alert('请先登录');window.location.href='Login.aspx'</script>");

            }
        }

        protected void ChangeInfo_Click(object sender, EventArgs e)
        {
            //跳转修改信息页面
            Response.Redirect("changeinformation.aspx");
        }
    }
}