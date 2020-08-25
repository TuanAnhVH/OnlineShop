using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategoryDAO
    {
        public List<Category> ListAll()
        {
            return Dbo.Db.Category.Where(x => x.Status == true).ToList();
        }
    }
}
