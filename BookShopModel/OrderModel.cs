
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShopModel
{
    public class OrderModel
    {
        public string OrderID { get; set; }
        public string BookID { get; set; }
        public string UserName { get; set; }
        public string BookName { get; set; }
        public string BookPrice { get; set; }
        public string BookPic { get; set; }
        public DateTime cdate { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string OrderState { get; set; }
        public float PriceSum { get; set; }
    }
    /// <summary>
    /// 合并单元格使用类
    /// </summary>
    public class RowArg
    {
        public int StartRowIndex { get; set; }
        public int EndRowIndex { get; set; }
    }
}
