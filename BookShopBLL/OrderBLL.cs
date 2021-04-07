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
    public class OrderBLL
    {

        /// <summary>
        /// 获取订单页内容
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static List<OrderModel> GetOrderList(string UserName)
        {
            string sql = "select * from OrderView where UserName =@UserName";
            List<OrderModel> MyOrder = new List<OrderModel>();
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
                            OrderModel order = new OrderModel();
                            order.BookID = sdr["BookID"].ToString();
                            order.UserName = sdr["UserName"].ToString();
                            order.cdate = Convert.ToDateTime(sdr["cdate"]);
                            order.Tel = sdr["Tel"].ToString();
                            order.BookPrice = sdr["BookPrice"].ToString();
                            order.BookPic = sdr["BookPic"].ToString();
                            order.BookName = sdr["BookName"].ToString();
                            order.Address = sdr["Address"].ToString();
                            order.OrderState = sdr["OrderState"].ToString();
                            order.OrderID = sdr["OrderID"].ToString();
                            order.PriceSum = Convert.ToInt32(sdr["PriceSum"]);
                            MyOrder.Add(order);
                        }
                        return MyOrder;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 获取所有订单信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static List<OrderModel> GetOrderList()
        {
            string sql = "select * from OrderView";
            List<OrderModel> MyOrder = new List<OrderModel>();
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, null))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            OrderModel order = new OrderModel();
                            order.BookID = sdr["BookID"].ToString();
                            order.UserName = sdr["UserName"].ToString();
                            order.cdate = Convert.ToDateTime(sdr["cdate"]);
                            //order.tel = sdr["tel"].ToString();
                            order.BookPrice = sdr["BookPrice"].ToString();
                            order.BookPic = sdr["BookPic"].ToString();
                            order.BookName = sdr["BookName"].ToString();
                            //order.address = sdr["address"].ToString();
                            order.OrderState = sdr["OrderState"].ToString();
                            order.OrderID = sdr["OrderID"].ToString();
                            MyOrder.Add(order);
                        }
                        return MyOrder;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="select"></param>
        /// <returns></returns>
        public static DataTable GetOrderList(string OrderAbout, string select)
        {
            string sql = string.Empty;
            SqlParameter[] sqlParams;
            if (select == "订单号")
            {
                sql = @"select * from OrderView where OrderID = @orderid";
                sqlParams = new SqlParameter[]{
                    new SqlParameter("@orderid",OrderAbout)
                };
            }
            else
            {
                sql = @"select * from OrderView where Orderstate = @orderstate";
                sqlParams = new SqlParameter[]{
                    new SqlParameter("@orderstate",OrderAbout)
                };
            }
            return SqlHelper.ExcuteDataTable(sql, sqlParams);
        }
        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="mycurt"></param>
        /// <returns></returns>
        public static int OrderStateUpdate(OrderModel myOrder)
        {
            string sqlStr = "update OrderInfo set OrderState =@orderstate where OrderId=@orderid";
            SqlParameter[] sqlParames = new SqlParameter[] { 
                new SqlParameter("@orderstate",myOrder.OrderState),
                new SqlParameter("@orderid",myOrder.OrderID),
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sqlStr, sqlParames);
        }
        /// <summary>
        /// 获取订单id
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<string> GetOrderID(string username)
        {
            List<string> myOrderID = new List<string>();
            string sql = "select distinct OrderID from OrderView where UserName =@UserName and OrderState != '已收货' ";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@UserName",username)
            };
            using (SqlDataReader sdr = SqlHelper.ExcuteReader(sql, paras))
            {
                if (sdr != null)
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            myOrderID.Add(sdr["OrderID"].ToString());
                        }
                        return myOrderID;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// 更改收货状态
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public static int CheckState(string orderID)
        {
            string sql = "update OrderInfo set OrderState = '已收货' where OrderID = @orderid";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@orderid",orderID)
            };
            return BookShopDAL.SqlHelper.ExecuteNonQuery(sql, paras);
        }
    }
}
