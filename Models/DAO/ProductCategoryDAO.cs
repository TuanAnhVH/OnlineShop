using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductCategoryDAO
    {
        public List<ProductCategory> ListAll()
        {
            return Dbo.Db.ProductCategory.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public ProductCategory detail(long CatID)
        {
            return Dbo.Db.ProductCategory.Find(CatID);
        }

       
    }
}
