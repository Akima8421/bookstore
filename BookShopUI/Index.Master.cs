using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShopModel;

namespace BookShopUI
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

                if (Convert.ToInt32(Session["Admin"]) == 0)//判断用户是否为管理员，将控制相应控件的显示
                {
                    BookAdmin.Visible = false;
                    BookAdd.Visible = false;
                    UserAdmin.Visible = false;
                    OrderAdmin.Visible = false;
                }
                if (Session["UName"] == null)//判断用户是否登录，显示注销或者用户名等按钮
                {
                    Button1.Visible = true;
                    Button2.Visible = false;
                    username.Visible = false;
                }
                else
                {
                    Button2.Visible = true;
                    Button1.Visible = false;
                    username.Visible = true;
                    username.Text = Session["UName"].ToString().Trim() ;
                }
            
        }
        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        /// <summary>
        /// 注销按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["UName"] = null;//将session用户名清空
            Session["Admin"] = 0;
            Response.Redirect("index.aspx");
        }
    }
}