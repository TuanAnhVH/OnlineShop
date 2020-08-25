using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class OrderDetailDAO
    {
        public bool Insert(OrderDetail detail)
        {
            try
            {
                Dbo.Db.OrderDetail.Add(detail);
                Dbo.Db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
