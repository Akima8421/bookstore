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
    public partial class OrderAdmin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                if (Request["Orderabout"] != null)
                {
                    getOrderList2(Request["Orderabout"].ToString(), Request["select"].ToString());
                    OrderAbout.Text = Request["Orderabout"].ToString();

                }
                else
                    getOrderList();
               }
         }
        /// <summary>
        /// 查询时加载函数
        /// </summary>
        void getOrderList()
        {
            
            gvOrderList.DataSource = OrderBLL.GetOrderList();
            gvOrderList.DataKeyNames = new string[] { "OrderID" };
            gvOrderList.DataBind();
            MergeRow(gvOrderList, 0, 1);
        }
        /// <summary>
        /// 无查询时的加载函数
        /// </summary>
        /// <param name="OrderAbout"></param>
        /// <param name="select"></param>
        void getOrderList2(string OrderAbout, string select)
        {

            gvOrderList.DataSource = OrderBLL.GetOrderList(OrderAbout, select);
            gvOrderList.DataKeyNames = new string[] { "OrderID" };
            gvOrderList.DataBind();
            MergeRow(gvOrderList, 0, 1);
        }

        /// <summary>
        /// 合并单列的行
        /// </summary>
        /// <param name="gv">GridView</param>
        /// <param name="currentCol">当前列</param>
        /// <param name="startRow">开始合并的行索引</param>
        /// <param name="endRow">结束合并的行索引</param>
        private static void MergeRow(GridView gv, int currentCol, int startRow, int endRow)
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
        private static void TraversesPrevCol(GridView gv, int prevCol, List<RowArg> list)
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
        public static void MergeRow(GridView gv, int startCol, int endCol)
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
        /// 更新后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrderList.PageIndex = e.NewPageIndex;
            getOrderList();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvOrderList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //string idStr = gvOrderList.DataKeys[e.NewEditIndex].Value.ToString();
            gvOrderList.EditIndex = e.NewEditIndex;
            getOrderList();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvOrderList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOrderList.EditIndex = -1;
            getOrderList();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvOrderList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            OrderModel myorder = new OrderModel();
            myorder.OrderID = gvOrderList.DataKeys[e.RowIndex].Value.ToString();
            myorder.OrderState = ((DropDownList)gvOrderList.Rows[e.RowIndex].Cells[6].FindControl("ddlOrder")).SelectedValue;
            
            gvOrderList.EditIndex = -1;

            int success = OrderBLL.OrderStateUpdate(myorder);
            getOrderList();
        }
        /// <summary>
        /// 行数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvOrderList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //弹窗提示
                if (((LinkButton)e.Row.Cells[7].Controls[0]).Text == "编辑")
                { }
                else
                {
                    ((LinkButton)e.Row.Cells[7].Controls[0]).Attributes.Add("onclick", "return confirm('是否要更新当前记录？')");
                    string labOrder = ((Label)e.Row.Cells[6].FindControl("Orderstate")).Text;
                    ((DropDownList)e.Row.Cells[6].FindControl("ddlOrder")).SelectedValue = labOrder;
                }
                //高亮
                e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='lightblue'");
                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            }
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFindNews_Click(object sender, EventArgs e)
        {
            string BookQueryUrl = string.Format(@"OrderAdmin.aspx?Orderabout={0}&select={1}", OrderAbout.Text.Trim(), ddlOrderstate.SelectedValue);
            Response.Redirect(BookQueryUrl);
        }
    }
}