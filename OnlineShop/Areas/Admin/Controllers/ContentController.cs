using Models.DAO;
using Models.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long ID)
        {
            var DAO = new ContentDAO();
            var content = DAO.getByID(ID);
            setViewBag(content.CategoryID);
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content Model)
        {
            if(ModelState.IsValid)
            {

            }
            setViewBag();
            return View();
        }

        [HttpPost]
        
        public ActionResult Edit(Content Model)
        {
            if (ModelState.IsValid)
            {

            }
            setViewBag(Model.CategoryID);
            return View();
        }
        public void setViewBag(long? selectedID=null)
        {
            var dao = new CategoryDAO();    
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
    }
}