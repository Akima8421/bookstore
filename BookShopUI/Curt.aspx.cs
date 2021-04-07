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
    public partial class Curt : System.Web.UI.Page
    {
        string username;
        /// <summary>
        /// 界面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    username = Session["UName"].ToString();
                    getCurtList(username);
                }
            }
            catch
            {
                Response.Write(@"<script>alert('请先登录！');window.location.href='index.aspx'</script>");
                //Response.Redirect("index.aspx");
            }
        }

        /// <summary>
        ///数据绑定
        /// </summary>
        /// <param name="Uname"></param>
        void getCurtList(string Uname)
        {
            gvCurtList.DataSource = CurtBLL.GetCurtDetail(Uname);
            gvCurtList.DataKeyNames=new string[] {"BookID"};
            gvCurtList.DataBind();
        }

        /// <summary>
        /// 行删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvNewsList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string bookid = gvCurtList.DataKeys[e.RowIndex].Value.ToString();
            username = Session["UName"].ToString();
            int success = CurtBLL.DelCurtInfo(bookid,username);
            if (success == 1)
            {
                Response.Write(@"<script>alert('图书删除成功！')</script>");
                getCurtList(username);
            }
            else
            {
                Response.Write(@"<script>alert('图书删除失败！')</script>");
            }
        }

        /// <summary>
        /// 行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCurtList_RowEditing(object sender, GridViewEditEventArgs e)
        {

            username = Session["UName"].ToString();
            string bookid = gvCurtList.DataKeys[e.NewEditIndex].Value.ToString();
            gvCurtList.EditIndex = e.NewEditIndex;
            getCurtList(username);
        }

        /// <summary>
        /// 行更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCurtList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string bookid = gvCurtList.DataKeys[e.RowIndex].Value.ToString();
            int changekey = Convert.ToInt32(((TextBox)gvCurtList.Rows[e.RowIndex].Cells[5].Controls[0]).Text.ToString().Trim());
            username = Session["UName"].ToString();
            CurtModel mycurt = new CurtModel();
            mycurt.BookID = bookid;
            mycurt.UserName = username;
            mycurt.BookNeedNum = changekey;
            gvCurtList.EditIndex = -1;
            int suc = CurtBLL.NumUpdate(mycurt);
            if (suc == 1)
            {
                Response.Write(@"<script>alert('数量修改成功！')</script>");
                getCurtList(username);
            }
            else
            {
                Response.Write(@"<script>alert('数量修改失败！')</script>");
            }
        }

        /// <summary>
        /// 行更新取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCurtList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            username = Session["UName"].ToString();
            gvCurtList.EditIndex = -1;
            getCurtList(username);
        }

        /// <summary>
        /// 订单提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOrderSend_Click(object sender, EventArgs e)
        {
            List<BookModel> BookList = new List<BookModel>();
            username=Session["UName"].ToString();
            string dt = DateTime.Now.ToFileTimeUtc().ToString();
            string CurtID = dt+username;
            int n = 0;
            string bid="";
            float PriceSum = 0;
            bool flag = false;
            foreach (GridViewRow gvr in gvCurtList.Rows)
            {
                Control ctl = gvr.FindControl("cbCheck");
                CheckBox ck = (CheckBox)ctl;
                if (ck.Checked)
                {
                    BookModel mybook = new BookModel();
                    TableCellCollection cell = gvr.Cells;
                    float bookprice = Convert.ToSingle(cell[4].Text);
                    int booknum = Convert.ToInt32(cell[5].Text);
                    bid = cell[1].Text;
                    mybook.BookID = bid;
                    mybook.BookNum = booknum;
                    PriceSum = PriceSum + bookprice * booknum;
                    BookList.Add(mybook);
                    n++;
                    int j = CurtBLL.CheckBookSum(bid) - booknum;
                    if (j >= 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            if (flag)
            {
                int suc = CurtBLL.PushOrder(BookList, username, CurtID, PriceSum);
                if (suc == n)
                {
                    Response.Write(@"<script>alert('订单提交成功！')</script>");
                    CurtBLL.ChangeBookNum(BookList);
                }
                else
                {
                    Response.Write(@"<script>alert('订单提交失败！')</script>");
                }
            }
            else
            {
                Response.Write(@"<script>alert('图书数量超出库存,请重新修改！')</script>");
            }
        }
    }
}