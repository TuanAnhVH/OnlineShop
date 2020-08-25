using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        public List<Product> ListNewProduct(int top)
        {
            return Dbo.Db.Product.OrderByDescending(x => x.CreatedDate).Take(top).ToList();

        }
        public List<Product> ListFeatureProduct(int top)
        {
            return Dbo.Db.Product.Where(x=>x.TopHot!=null&& x.TopHot> DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();

        }
        public List<Product> ListRelatedProduct(long Id)
        {
            var product = Dbo.Db.Product.Find(Id);
            return Dbo.Db.Product.Where(x => x.ID!=Id && x.CategoryID==product.CategoryID).Take(4).ToList();

        }

        public List<Product> ListByCategoryID(long catid,ref int TotalRecord,int pageindex=1, int pagesize=2)
        {
            TotalRecord = Dbo.Db.Product.Where(x => x.CategoryID == catid).Count();
            return Dbo.Db.Product.Where(x => x.CategoryID == catid).OrderBy(x=>x.CreatedDate).Skip((pageindex-1)*pagesize).Take(pagesize).ToList();
        }
        public Product viewDetail(long id)
        {
            return Dbo.Db.Product.Find(id);
        }

     
    }
}
