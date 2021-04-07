using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShopModel
{
    public class NewsModel
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public int typeid { get; set; }
        public string typename { get; set; }
        public string Contents { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime cdate { get; set; }
        public int del { get; set; }
    }
}
