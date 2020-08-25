using BotDetect.Web.Mvc;
using Models.DAO;
using Models.FE;
using OnlineShop.Common;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [CaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (new UserDAO().checkUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (new UserDAO().checkEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Name = model.Name;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.Phone = model.Phone;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    var result = new UserDAO().Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công!";
                        model = null;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công!");
                    }
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[CommonConstant.User_Session] = null;
            return Redirect("/");
          
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var res = new UserDAO().Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (res == 3)
                {
                    var user = new UserDAO().GetByUserName(model.UserName);
                    var UserSesion = new UserLogin();
                    UserSesion.UserID = user.ID;
                    UserSesion.UserName = user.UserName;

                    Session.Add(CommonConstant.User_Session, UserSesion);
                    return RedirectToAction("Index", "Home");
                }
                else if (res == 0)
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

            return View(model);
        }

      
       


    }
}