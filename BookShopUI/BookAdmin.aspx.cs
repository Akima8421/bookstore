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
    public partial class BookAdmin : System.Web.UI.Page
    {
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
        /// 查询时的加载函数
        /// </summary>
        /// <param name="Bookabout"></param>
        /// <param name="select"></param>
        void BindBookList(string Bookabout, string select)
        {
            gvBooksList.DataSource = BookBLL.GetBookList(Bookabout, select);
            gvBooksList.DataBind();

        }
        /// <summary>
        /// 无查询时的加载函数
        /// </summary>
        void BindBookList2()
        {
            gvBooksList.DataSource = BookBLL.GetBookList();
            gvBooksList.DataBind();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvBooksList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BookModel selectbook = new BookModel();
            selectbook.BookID = gvBooksList.DataKeys[e.RowIndex].Value.ToString();
            int success = BookBLL.deletBook(selectbook);
            BindBookList2();
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvBooksList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string idStr = gvBooksList.DataKeys[e.NewEditIndex].Value.ToString();
            gvBooksList.EditIndex = e.NewEditIndex;
            BindBookList2();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void gvBooksList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            BookModel chooseBook = new BookModel();
            chooseBook.BookID = gvBooksList.DataKeys[e.RowIndex].Value.ToString();
            chooseBook.BookName = ((TextBox)gvBooksList.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString().Trim();
            chooseBook.BookAuthor = ((TextBox)gvBooksList.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString().Trim();
            chooseBook.BookFrom = ((TextBox)gvBooksList.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString().Trim();
            chooseBook.BookNum =Convert.ToInt32(((TextBox)gvBooksList.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Trim());
            chooseBook.BookPrice = Convert.ToSingle(((TextBox)gvBooksList.Rows[e.RowIndex].Cells[6].Controls[0]).Text.Trim());
            chooseBook.BookThings = ((TextBox)gvBooksList.Rows[e.RowIndex].Cells[7].Controls[0]).Text.ToString().Trim();
            int success = BookBLL.changeBook(chooseBook);
            gvBooksList.EditIndex = -1;
            BindBookList2();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvBooksList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBooksList.EditIndex = -1;
            BindBookList2();
        }
        /// <summary>
        /// 更新后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvBooksList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBooksList.PageIndex = e.NewPageIndex;
            BindBookList2();
        }
        /// <summary>
        /// 行数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvBooksList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //弹窗提示
                if (((LinkButton)e.Row.Cells[8].Controls[0]).Text != "编辑")
                {
                    ((LinkButton)e.Row.Cells[8].Controls[0]).Attributes.Add("onclick", "return confirm('是否要更新当前记录？')");
                    
                }
                //高亮
                e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            }
            if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
            {
                TextBox curText;
                for (int i = 2; i <= 7; i++)
                {
                    curText = (TextBox)e.Row.Cells[i].Controls[0];
                    curText.Width = Unit.Pixel(120);
                }
            }  
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFindBooks_Click(object sender, EventArgs e)
        {
            string BookQueryUrl = string.Format(@"BookAdmin.aspx?Bookabout={0}&select={1}", serchBooks.Text.Trim(), ddlSelect.SelectedValue);
            Response.Redirect(BookQueryUrl);
        }
    }
}