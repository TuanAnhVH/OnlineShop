using Models.DAO;
using Models.FE;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(String SearchString,int Page=1,int PageSize=10)
        {
            var model = new UserDAO().ListAllPaging(SearchString,Page,PageSize);
            ViewBag.SearchString = SearchString;
            return View(model);
   
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            User u = new UserDAO().GetByID(ID);
            return View(u);
        }


        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pass = Encryptor.MD5Hash(user.Password);
                    user.Password = pass;
                    var dao = new UserDAO();
                    long rs = dao.Insert(user);
                    if (rs > 0)
                    {
                      return  RedirectToAction("Index");
                    }
                    else if(rs == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản đã tồn tại!");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công!");
                    }
                }
                return View(user);
            }
            catch
            {
                ModelState.AddModelError("", "Thêm không thành công!");
                return View();
               
            }
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pass = Encryptor.MD5Hash(user.Password);
                    user.Password = pass;
                    var dao = new UserDAO();
                    bool rs = dao.Update(user);
                    if (rs)
                    {
                        return RedirectToAction("Index");
                    }
                  
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công!");
                    }
                }
                return View(user);
            }
            catch
            {
                ModelState.AddModelError("", "Thêm không thành công!");
                return View();

            }
        }
        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            new UserDAO().Delete(ID);
            return RedirectToAction("Index");
        }
    }
}