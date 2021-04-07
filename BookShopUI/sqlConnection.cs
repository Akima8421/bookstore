using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShopUI
{
    class sqlConnection
    {
        private string connStr;

        public sqlConnection(string connStr)
        {
            // TODO: Complete member initialization
            this.connStr = connStr;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}
