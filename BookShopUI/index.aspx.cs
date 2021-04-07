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
    public partial class index : System.Web.UI.Page
    {
        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["Bookabout"] != null)
                {
                    BindBookList(Request["Bookabout"].ToString(), Request["select"].ToString());
                    serchBooks.Text = Request["Bookabout"].ToString();

                }
                else
                    BindBookList2();
            }
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="Bookabout"></param>
        /// <param name="select"></param>
        void BindBookList(string Bookabout, string select)
        {
            gvBookList.DataSource = BookBLL.GetBookList(Bookabout, select);
            gvBookList.DataKeyNames = new string[] { "BookID" };
            gvBookList.DataBind();

        }

        /// <summary>
        /// 查询数据绑定
        /// </summary>
        void BindBookList2()
        {
            gvBookList.DataSource = BookBLL.GetBookList();
            gvBookList.DataKeyNames = new string[] { "BookID" };
            gvBookList.DataBind();

        }

        /// <summary>
        /// 图书添加至购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvBookList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Click")
            {
                try
                {
                    string username = Session["UName"].ToString();
                    string bookID = gvBookList.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
                    int mycurt = CurtBLL.CheckBookNum(bookID, username);
                    if (mycurt==0)
                    {
                        int suc = CurtBLL.BookNumPlus(bookID, username);
                        if (suc == 1)
                            Response.Write(@"<script>alert('购物车添加成功！')</script>");
                        else
                            Response.Write(@"<script>alert('购物车添加失败！')</script>");

                    }
                    else
                    {
                        int suc = CurtBLL.CurtUpload(bookID, username);
                        if (suc == 1)
                        {
                            Response.Write(@"<script>alert('购物车添加成功！')</script>");
                        }
                    }
                }
                catch
                {
                  Response.Write(@"<script>alert('请先登录！')</script>");
                }
            }
        }
        
        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void serchButton_Click(object sender, EventArgs e)
        {
            string BookQueryUrl = string.Format(@"index.aspx?Bookabout={0}&select={1}", serchBooks.Text.Trim(), ddlSelect.SelectedValue);
            Response.Redirect(BookQueryUrl);
        }

    }
}