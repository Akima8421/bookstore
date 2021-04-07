using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using BookShopModel;
using BookShopDAL;
using System.Data;

namespace BookShopBLL
{
    public class BookBLL
    {
        /// <summary>
        /// 上传封面
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        public static int BookUpload(BookModel newBook)
        {
            string sqlStr = "insert into BookInfo(BookID,BookName,BookPic,BookAuthor,BookThings,BookPrice,BookFrom,BookNum) values(@bookid,@bookname,@bookpic,@bookauthor,@bookthings,@bookprice,@bookfrom,@booknum)";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@bookid", newBook.BookID),
                new SqlParameter("@bookname", newBook.BookName),
                new SqlParameter("@bookpic", newBook.BookPic),
                new SqlParameter("@bookauthor", newBook.BookAuthor),
                new SqlParameter("@bookthings", newBook.BookThings),
                new SqlParameter("@bookprice", newBook.BookPrice),
                new SqlParameter("@bookfrom", newBook.BookFrom),
                new SqlParameter("@booknum", newBook.BookNum)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 获取图书id
        /// </summary>
        /// <param name="myBook"></param>
        /// <returns></returns>
        public static int oldBook(BookModel myBook)
        {
            string sqlStr = "select BookID from BookInfo where BookID =@bookid";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@bookid", myBook.BookID),
            };
            return Convert.ToInt32(BookShopDAL.SqlHelper.ExecuteScalar(sqlStr, sqlParames));
        }
        /// <summary>
        /// 删除图书
        /// </summary>
        /// <param name="selectBook"></param>
        /// <returns></returns>
        public static int deletBook(BookModel selectBook)
        {
            string sqlStr = "delete from BookInfo where BookID =@bookid";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@bookid",selectBook.BookID),
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 修改图书信息
        /// </summary>
        /// <param name="chooseBook"></param>
        /// <returns></returns>
        public static int changeBook(BookModel chooseBook)
        {
            string sqlStr = "update BookInfo set BookName =@bookname,BookAuthor =@bookauthor,BookFrom =@bookfrom,BookPrice =@bookprice,BookNum =@booknum,BookThings =@bookthings where BookID =@bookid";
            SqlParameter[] sqlParames = new SqlParameter[]{
                new SqlParameter("@bookid",chooseBook.BookID),
                new SqlParameter("@bookname",chooseBook.BookName),
                new SqlParameter("@bookauthor",chooseBook.BookAuthor),
                new SqlParameter("@bookfrom",chooseBook.BookFrom),
                new SqlParameter("@bookprice",chooseBook.BookPrice),
                new SqlParameter("@booknum",chooseBook.BookNum),
                new SqlParameter("@bookthings",chooseBook.BookThings),
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 获取图书列表
        /// </summary>
        /// <returns></returns>
        public static List<BookModel> GetBookList()
        {
            string sqlStr = "select  * from BookInfo ";
            List<BookModel> BookList = new List<BookModel>();
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sqlStr, null))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            BookModel books = new BookModel();
                            books.BookID = sdr["BookID"].ToString();
                            books.BookPic = sdr["BookPic"].ToString();
                            books.BookName = sdr["BookName"].ToString();
                            books.BookPrice = Convert.ToSingle(sdr["BookPrice"]);
                            books.BookFrom = sdr["BookFrom"].ToString();
                            books.BookAuthor = sdr["BookAuthor"].ToString();
                            books.BookThings = sdr["BookThings"].ToString();
                            books.BookNum = Convert.ToInt32( sdr["BookNum"]);
                            BookList.Add(books);
                        }
                        return BookList;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }

        }
    /// <summary>
    /// 查询图书
    /// </summary>
    /// <param name="Bookabout"></param>
    /// <param name="select"></param>
    /// <returns></returns>
        public static DataTable GetBookList(string Bookabout ,string select)
        {
            string sql = string.Empty;
            SqlParameter[] sqlParams;
            if (select == "书名")
            {
                sql = @"select * from BookInfo where BookName = @bookname";
                sqlParams = new SqlParameter[]{
                    new SqlParameter("@bookname",Bookabout)
                };
            }
            else 
            {
                sql = @"select * from BookInfo where BookID = @bookid";
                sqlParams = new SqlParameter[]{
                    new SqlParameter("@bookid",Bookabout)
                };
            }
            
            return SqlHelper.ExcuteDataTable(sql, sqlParams);
        }
        /// <summary>
        /// 图书详情界面图书信息获取
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public static BookModel GetBookDetail(string BookID)
        {
            string sql = "select * from Bookinfo where BookID =@BookID";
            BookModel book = new BookModel();
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@BookID",BookID)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {

                        sdr.Read();
                        book.BookID = sdr["BookID"].ToString();
                        book.BookPic = sdr["BookPic"].ToString();
                        book.BookName = sdr["BookName"].ToString();
                        book.BookFrom = sdr["BookFrom"].ToString();
                        book.BookPrice = Convert.ToSingle(sdr["BookPrice"]);
                        book.BookNum = Convert.ToInt32(sdr["BookNum"]);
                        book.BookAuthor = sdr["BookAuthor"].ToString();
                        book.BookThings = sdr["BookThings"].ToString();
                        return book;
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
    

