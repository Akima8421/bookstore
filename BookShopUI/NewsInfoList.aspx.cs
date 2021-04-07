using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookShopBLL;

namespace BookShopUI
{
    public partial class NewsInfoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                //初始化新闻类型列表
                ddlNewsType.DataSource = NewsBLL.GetNewsTypeDict();
                ddlNewsType.DataValueField = "key";
                ddlNewsType.DataTextField = "value";
                ddlNewsType.DataBind();
                ddlNewsType.Items.Insert(0,new ListItem("所有类型","0"));

                if (Request["newstitle"] != null && Request["newstypeid"] != null)
                {
                    BindNewsList(Request["newstitle"].ToString(),Convert.ToInt32(Request["newstypeid"]));
                    tbNewsTitle.Text = Request["newstitle"].ToString();
                    ddlNewsType.SelectedValue = Request["newstypeid"];
                }
                else
                    BindNewsList("",0);
            }
            
        }

        void BindNewsList(string newsTitle, int newsTypeId)
        {
            gvNewsList.DataSource = NewsBLL.GetNewsList(newsTitle,newsTypeId);
            gvNewsList.DataBind();
        }

        protected void btnFindNews_Click(object sender, EventArgs e)
        {
            string newsQueryUrl = string.Format(@"NewsInfoList.aspx?newstitle={0}&newstypeid={1}",tbNewsTitle.Text.Trim(),ddlNewsType.SelectedValue);
            Response.Redirect(newsQueryUrl);
        }
    }
}