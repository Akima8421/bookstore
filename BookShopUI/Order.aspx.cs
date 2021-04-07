using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShopModel;
using BookShopBLL;
using System.Drawing;

namespace BookShopUI
{
    public partial class Order : System.Web.UI.Page
    {
        string username = "";
        /// <summary>
        /// 页面加载
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
                    labName.Text = username+"的订单";
                    getOrderList(username);
                    
                }
            }
            catch
            {
                Response.Write(@"<script>alert('请先登录！');window.location.href='index.aspx'</script>");
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="username"></param>
         void  getOrderList(string username)
        {
            username = Session["UName"].ToString();
            gvOrderList.DataSource = OrderBLL.GetOrderList(username);
            gvOrderList.DataKeyNames = new string[] { "OrderID" };
            ddlOrderID.DataSource = OrderBLL.GetOrderID(username);
            string ddl = ddlOrderID.SelectedValue.ToString();
            if (ddl == "")
            {
                ddlOrderID.Items.Clear();
                ddlOrderID.Items.Add("全都订单已收货");
            }
            ddlOrderID.DataBind();
            gvOrderList.DataBind();
            MergeRow(gvOrderList, 0, 5);
        }

        /// <summary>
        /// 合并单列的行
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="currentCol">当前列</param>
        /// <param name="startRow">开始合并的行索引</param>
        /// <param name="endRow">结束合并的行索引</param>
         void MergeRow(GridView gv, int currentCol, int startRow, int endRow)
        {
            for (int rowIndex = endRow; rowIndex >= startRow; rowIndex--)
            {
                GridViewRow currentRow = gv.Rows[rowIndex];
                GridViewRow prevRow = gv.Rows[rowIndex + 1];
                if (currentRow.Cells[currentCol].Text != "" && currentRow.Cells[currentCol].Text != " ")
                {
                    if (currentRow.Cells[currentCol].Text == prevRow.Cells[currentCol].Text)
                    {
                        currentRow.Cells[currentCol].RowSpan = prevRow.Cells[currentCol].RowSpan < 1 ? 2 : prevRow.Cells[currentCol].RowSpan + 1;
                        prevRow.Cells[currentCol].Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// 遍历前一列
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="prevCol">当前列的前一列</param>
        /// <param name="list"></param>
        void TraversesPrevCol(GridView gv, int prevCol, List<RowArg> list)
        {
            if (list == null)
            {
                list = new List<RowArg>();
            }
                RowArg ra = null;
                for (int i = 0; i < gv.Rows.Count; i++)
                {
                    if (!gv.Rows[i].Cells[prevCol].Visible)
                    {
                        continue;
                    }
                    ra = new RowArg();
                    ra.StartRowIndex = gv.Rows[i].RowIndex;
                    ra.EndRowIndex = ra.StartRowIndex + gv.Rows[i].Cells[prevCol].RowSpan - 2;
                    list.Add(ra);
                }
         }

        /// <summary>
        /// GridView合并行，
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="startCol">开始列</param>
        /// <param name="endCol">结束列</param>
        void MergeRow(GridView gv, int startCol, int endCol)
        {
            RowArg init = new RowArg()
            {
                StartRowIndex = 0,
                EndRowIndex = gv.Rows.Count - 2
            };
            for (int i = startCol; i < endCol + 1; i++)
            {
                if (i > 0)
                {
                    List<RowArg> list = new List<RowArg>();
                    //从第二列开始就要遍历前一列
                    TraversesPrevCol(gv, i - 1, list);
                    foreach (var item in list)
                    {
                        MergeRow(gv, i, item.StartRowIndex, item.EndRowIndex);
                    }
               }
                //合并开始列的行
                else
                {
                    MergeRow(gv, i, init.StartRowIndex, init.EndRowIndex);
                }
            }
        }
        /// <summary>
        /// 收货按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChange_Click(object sender, EventArgs e)
        {
            username = Session["UName"].ToString();
            string check = ddlOrderID.SelectedValue.ToString();
            int suc = OrderBLL.CheckState(check);
            if (suc > 0)
            {
                Response.Write(@"<script>alert('收货成功！')</script>");
                getOrderList(username);
            }
            else
            {
                Response.Write(@"<script>alert('收货失败！')</script>");
            }
        }
    }
}