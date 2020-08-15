using Models.DAO;
using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dbo
    {
        public static OnlineShopDbContext Db = new OnlineShopDbContext();
    }
}
