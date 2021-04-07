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
    public partial class BookDetail : System.Web.UI.Page
    {
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id = Request["BookID"];
            if (string.IsNullOrEmpty(Id))
                Response.Redirect("index.aspx");
            else
            {
                BookModel bookDetail = new BookModel();
                bookDetail = BookBLL.GetBookDetail(Id);
                imgBookPic.ImageUrl = bookDetail.BookPic;
                labBookName.Text = bookDetail.BookName;
                labBookAuthor.Text = bookDetail.BookAuthor;
                labBookFrom.Text = bookDetail.BookFrom;
                labBookNum.Text = bookDetail.BookNum.ToString();
                labBookID.Text = bookDetail.BookID;
                labBookPrice.Text = bookDetail.BookPrice.ToString();
                labThings.Text =  bookDetail.BookThings;
            }
        }
        /// <summary>
        /// 提交购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCurt_Click(object sender, EventArgs e)
        {
            try
                {
                    string username = Session["UName"].ToString();
                    string bookID = labBookID.Text.ToString();
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
}