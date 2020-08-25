using Models.DAO;
using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAll();
            return PartialView(model);

        }

        public ActionResult Category(long Cateid,int Page=1, int PageSize=1)
        {
            
            var Category = new ProductCategoryDAO().detail(Cateid);
            ViewBag.Category = Category;
            int TotalRecord = 0;
            var model = new ProductDAO().ListByCategoryID(Cateid,ref TotalRecord,Page,PageSize);
            ViewBag.Total = TotalRecord;
            ViewBag.Page = Page;
            int MaxPage = 5;
            int TotalPage = (int)Math.Ceiling((double)(TotalRecord / PageSize));

            ViewBag.TotalPage = TotalPage;
            ViewBag.MaxPage = MaxPage;
            ViewBag.First = 1;
            ViewBag.Last = TotalPage;
            ViewBag.Next = Page+1;
            ViewBag.Prev = Page- 1;
            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var model = new ProductDAO().viewDetail(id);
            ViewBag.Category = new ProductCategoryDAO().detail(model.CategoryID.Value);
            ViewBag.RelatedProduct = new ProductDAO().ListRelatedProduct(id);
            return View(model);
        }

    }
}