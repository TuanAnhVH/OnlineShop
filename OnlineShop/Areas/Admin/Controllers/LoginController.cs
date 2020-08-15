
using Models.DAO;
using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Session[CommonConstant.User_Session] != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        public ActionResult Login(LoginModel md)
        {
            if(ModelState.IsValid)
            {
                var res = new UserDAO().Login(md.User,Encryptor.MD5Hash(md.Password));
                if(res==3)
                {
                    var user = new UserDAO().GetByUserName(md.User);
                    var UserSesion = new UserLogin();
                    UserSesion.UserID = user.ID;
                    UserSesion.UserName = user.UserName;

                    Session.Add(CommonConstant.User_Session,UserSesion);
                    return RedirectToAction("Index", "Home");
                }
                else if(res==0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (res == 1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng!");
                }
                else if (res == 2)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                }
            }

            return View("index");
        }

        public ActionResult Logout()
        {
            Session.Remove(CommonConstant.User_Session);
            return RedirectToAction("Login");

        }
    }
}