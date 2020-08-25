using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDAO
    {
        public long Insert(Order order)
        {
            Dbo.Db.Order.Add(order);
            Dbo.Db.SaveChanges();
            return order.ID;
        }
    }
}
