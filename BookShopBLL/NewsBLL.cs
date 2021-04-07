using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModel;
using System.Data.SqlClient;
using BookShopDAL;
using System.Data;

namespace BookShopBLL
{
    public class NewsBLL
    {
        /// <summary>
        /// 获取最新的numOfNews条信息
        /// </summary>
        /// <param name="numOfNews"></param>
        /// <returns></returns>
        public static List<NewsModel> GetTopNews(int numOfNews)
        {
            string sqlStr = string.Format("select top{0} * from NewsInfo order by cdate desc ", numOfNews);
            List<NewsModel> topNewsList = new List<NewsModel>();
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sqlStr, null))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            NewsModel news = new NewsModel();
                            news.NewsId = Convert.ToInt32(sdr["NewsId"]);
                            news.Title = sdr["Title"].ToString();
                            news.cdate = Convert.ToDateTime(sdr["cdate"]);
                            topNewsList.Add(news);
                        }
                        return topNewsList;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        public static NewsModel GetDetail(int NewsId)
        {
            string sql = "select * from NewsListView where NewsId =@NewsId"; 
            NewsModel news = new NewsModel();
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@NewsId",NewsId)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {

                        sdr.Read();
                        news.NewsId = Convert.ToInt32(sdr["NewsId"]);
                        news.Title = sdr["Title"].ToString();
                        news.typename = sdr["TypeName"].ToString();
                        news.UserName = sdr["UserName"].ToString();
                        news.cdate = Convert.ToDateTime(sdr["cdate"]);
                        news.Contents = sdr["Contents"].ToString();
                        return news;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// 获取所有新闻记录，返回类型为DataTable
        /// </summary>
        /// <returns>返回类型为DataTable</returns>
        public static DataTable GetNewsList()
        {
            string sql = "select row_number() over(order by cdate desc) rownum, * from NewsListView";
            return SqlHelper.ExcuteDataTable(sql,null);
        }

        /// <summary>
        /// 根据新闻标题关键字和新闻类型进行查询，返回符合条件的新闻数据，返回类型为DataTable
        /// </summary>
        /// <param name="newsTitle">string，新闻标题关键字</param>
        /// <param name="newsTypeId">int，新闻类型ID</param>
        /// <returns>返回符合条件的新闻数据，返回类型为DataTable</returns>
        public static DataTable GetNewsList(string newsTitle, int newsTypeId)
        {
            string sql = string.Empty;
            SqlParameter[] sqlParams;
            if (newsTypeId == 0)//0表示“所有类型”， 即只需考录newsTitle作为查询条件即可
            {
                sql = @"select row_number() over(order by cdate desc) rownum, * from NewsListView where Title like @Title";
                sqlParams = new SqlParameter[]{
                    new SqlParameter("@Title","%"+newsTitle+"%")
                };
            }
            else //用户选择了某种具体的新闻类型作为查询条件
            {
                sql = @"select row_number() over(order by cdate desc) rownum, * from NewsListView where TypeId=@TypeId and Title like @Title";
                sqlParams = new SqlParameter[]{
                    new SqlParameter("@TypeId",newsTypeId),
                    new SqlParameter("@Title","%"+newsTitle+"%")
                };
            }
            return SqlHelper.ExcuteDataTable(sql,sqlParams);
        }


        /// <summary>
        /// 获取新闻类型列表，返回Dictionary(int key, string value)类型对象
        /// </summary>
        /// <returns>返回Dictionary类型对象</returns>
        public static Dictionary<int, string> GetNewsTypeDict()
        {
            Dictionary<int, string> newsTypeDict = new Dictionary<int, string>();
            string sqlStr = "select * from NewsType where del=1";
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sqlStr, null))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                            newsTypeDict.Add(Convert.ToInt32(sdr["typeid"]),sdr["typename"].ToString());
                        return newsTypeDict;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }

        }

        


    }
}
