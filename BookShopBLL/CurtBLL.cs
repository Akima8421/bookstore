using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookShopModel;
using System.Data.SqlClient;
using BookShopDAL;

namespace BookShopBLL
{
     public class CurtBLL
    {
         /// <summary>
         /// 购物车添加商品
         /// </summary>
         /// <param name="newCurt"></param>
         /// <returns></returns>
         public static int CurtUpload(string BookID,string UserName)
         {
             string sqlStr = "insert into Curt(BookID,UserName) values(@bookid,@username)";
             SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@bookid", BookID),
                new SqlParameter("@username", UserName)
            };
             return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
         }
         
         
         /// <summary>
        /// 购物车界面信息获取
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static List<CurtModel> GetCurtDetail(string UserName)
        {
            string sql = "select * from CurtView where UserName =@UserName";
            List<CurtModel> Mycurt = new List<CurtModel>();
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@UserName",UserName)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            CurtModel curt = new CurtModel();
                            curt.BookID = sdr["BookID"].ToString();
                            curt.UserName = sdr["UserName"].ToString();
                            curt.BookNeedNum = Convert.ToInt32(sdr["BookNeedNum"]);
                            curt.BookNum = Convert.ToInt32(sdr["BookNum"]);
                            curt.BookPrice = sdr["BookPrice"].ToString();
                            curt.BookPic = sdr["BookPic"].ToString();
                            curt.BookName = sdr["BookName"].ToString();
                            Mycurt.Add(curt);
                        }   
                        return Mycurt;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
         /// <summary>
         /// 从购物车删除商品
         /// </summary>
         /// <param name="bookID"></param>
         /// <returns></returns>
        public static int DelCurtInfo(string bookID,string username)
        {
            string sqlStr = "delete from Curt where BookID = @bookid and UserName = @username ";
            SqlParameter[] sqlParames = new SqlParameter[] { 
                new SqlParameter("@bookid",bookID),
                new SqlParameter("@username",username)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
         /// <summary>
         /// 检查商品是否有重复（点击加入购物车时触发）
         /// </summary>
         /// <param name="BookID"></param>
         /// <param name="UserName"></param>
         /// <returns></returns>
        public static int CheckBookNum(string BookID, string UserName)
        {
            string sqlStr = "select * from Curt where BookID = @bookid and UserName =@username";
            SqlParameter[] sqlParames = new SqlParameter[] {
                new SqlParameter("@bookid",BookID),
                new SqlParameter("@username",UserName)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sqlStr, sqlParames))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        return 0;
                    }
                    else
                        return 1 ;
                }
                else
                    return 2;
            }

        }

         /// <summary>
         /// 购物车图书数量+1
         /// </summary>
         /// <param name="bookID"></param>
         /// <param name="username"></param>
         /// <returns></returns>
        public static int BookNumPlus(string bookID, string username)
        {
            string sqlStr = "update Curt set BookNeedNum = BookNeedNum+1 where BookID = @bookid and UserName =@username";
            SqlParameter[] sqlParames = new SqlParameter[] { 
                new SqlParameter("@bookid",bookID),
                new SqlParameter("@username",username)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 数量更新
        /// </summary>
        /// <param name="mycurt"></param>
        /// <returns></returns>

        public static int NumUpdate(CurtModel mycurt)
        {
            string sqlStr = "update Curt set BookNeedNum = @newnum where BookID = @bookid and UserName =@username";
            SqlParameter[] sqlParames = new SqlParameter[] { 
                new SqlParameter("@bookid",mycurt.BookID),
                new SqlParameter("@username",mycurt.UserName),
                new SqlParameter("@newnum",mycurt.BookNeedNum)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }


        /// <summary>
        /// 生成订单
        /// </summary>
        /// <param name="BookIDList"></param>
        /// <returns></returns>
        public static int PushOrder(List<BookModel> BookList,string username,string OrderID,float PriceSum)
        {
            int n = 0;
            for (int i = 0; i <= BookList.Count()-1; i++)
            {
                string bookid = BookList[i].BookID.ToString();
                string sqlStr = "insert into OrderInfo(OrderID,BookID,UserName,PriceSum) values(@orderid,@bookid,@username,@pricesum)";
                SqlParameter[] sqlParames = new SqlParameter[] { 
                new SqlParameter("@orderid",OrderID),
                new SqlParameter("@username",username),
                new SqlParameter("@bookid",bookid),
                new SqlParameter("@pricesum",PriceSum)
                };
                n=n+BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
            }
            return n;
        }
         /// <summary>
         /// 获取库存内书本数量
         /// </summary>
         /// <param name="BookID"></param>
         /// <returns></returns>
        public static int CheckBookSum(string BookID)
        {
            string sql ="select BookNum from BookInfo where BookID = @bookid";
            SqlParameter[] para = new SqlParameter[] { 
                new SqlParameter("@bookid",BookID)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql,para));
        }
         /// <summary>
         /// 更改库存书本数量
         /// </summary>
         /// <param name="BookList"></param>
        public static void ChangeBookNum(List<BookModel> BookList)
        {
            for (int i = 0; i <= BookList.Count()-1; i++)
            {
                string sql = "update BookInfo set BookNum = BookNum - @booknum  where BookID = @bookid";
                SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@booknum",BookList[i].BookNum),
                new SqlParameter("@bookid",BookList[i].BookID)
            };
                BookShopDAL.SqlHelper.ExecuteNonQuery(sql, paras);
            }
        }
    }
}
