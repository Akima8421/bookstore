using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookShopBLL;
using BookShopModel;

namespace BookShopUI
{
    public partial class NewsInfoDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id = Request["NewsId"];
            if (string.IsNullOrEmpty(Id))
                Response.Redirect("NewsInfoList.aspx");
            else
            {
                NewsModel newsDetail = new NewsModel();
                newsDetail = NewsBLL.GetDetail(Convert.ToInt32(Id));
                labTitle.Text = newsDetail.Title;
                labNewsInfo.Text = string.Format("<p>编辑：{0} &nbsp;&nbsp;&nbsp;&nbsp;发布日期：{1}</p>", newsDetail.UserName, newsDetail.cdate.ToShortDateString());
                labContents.Text = Server.HtmlDecode(newsDetail.Contents);

            }
        }
    }
}