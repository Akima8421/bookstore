using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShopBLL;
using BookShopModel;

namespace BookShopUI
{
    public partial class UserDel : System.Web.UI.Page
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
            //GridView数据源
            gvUserInfo.DataSource = UserBLL.GetDelUser();
            gvUserInfo.DataBind();
        }
        protected void gvUserInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //根据用户ID进行解封操作
            UserModel user = new UserModel();
            user.ID = gvUserInfo.DataKeys[e.RowIndex].Value.ToString();
            int success = UserBLL.UserRecover(user);
            if (success == 1)
            {
                Response.Write(@"<script>alert('解封成功');</script>");
                BindUserInfo();
            }
            else
            {
                Response.Write(@"<script>alert('解封失败');</script>");
            }
        }

        protected void gvUserInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
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