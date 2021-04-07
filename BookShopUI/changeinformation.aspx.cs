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
    public partial class changeinformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label2.Visible = false;
                try
                {
                    UserModel userinfo = Session["userinfo"] as UserModel;//获取用户信息，储存用户信息
                    tbName.Text = userinfo.UserName;
                    tbEmail.Text = userinfo.Email;
                    tbTel.Text = userinfo.Tel;
                    Label2.Text = userinfo.ID;
                    tbAddress.Text = userinfo.Address;


                }
                catch
                {
                    Response.Write("<script>alert('请先登录')</script>");

                }
            }
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void xx_Click(object sender, EventArgs e)
        {
            UserModel myuser = new UserModel();
            myuser.UserName = tbName.Text;
            myuser.Email = tbEmail.Text;
            myuser.Tel = tbTel.Text;
            myuser.ID = Label2.Text;
            myuser.Address = tbAddress.Text;
            int success = UserBLL.ChangeInfo(myuser);
            try
            {
                if (success == 1)
                {
                    Response.Write("<script>alert('修改成功')</script>");
                }
                else
                {
                    Response.Write("<script>alert('修改失败')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('修改异常')</script>");
            }
        }

    }
}