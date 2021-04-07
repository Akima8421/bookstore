using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookShopModel;
using BookShopBLL;

namespace BookShopUI
{
    public partial class UserAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UName"] == null)
                {
                    Response.Write("<script>alert('用户请登录');window.location.href='Login.aspx'</script>");
                }
                else
                {
                    BindUserInfo();
                }
            }
        }
        
        private void BindUserInfo()
        {
            //定义GridView的数据源
            gvUserInfo1.DataSource = UserBLL.GetUserList();
            gvUserInfo1.DataBind();
        }

        protected void gvUserInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvUserInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //根据用户ID进行封禁操作
            UserModel user = new UserModel();
            user.ID = gvUserInfo1.DataKeys[e.RowIndex].Value.ToString();
            int suc = UserBLL.DeleteUser2(user);
            if (suc == 1)
            {
                Response.Write(@"<script>alert('封禁成功！');</script>");
                BindUserInfo();
            }
            else
            {
                Response.Write(@"<script>alert('封禁失败！');</script>");
            }
        }

        protected void gvUserInfo1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //高亮
                e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            }
        }
    }
}