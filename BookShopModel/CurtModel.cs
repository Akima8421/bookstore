using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShopModel
{
     public class CurtModel
    {
         public string CurtID { get; set; }
         public string BookID { get; set; }
         public string UserName { get; set; }
         public string BookName { get; set; }
         public int BookNum { get; set; }
         public int BookNeedNum { get; set; }
         public string BookPrice { get; set; }
         public string BookPic { get; set; }
    }
}
