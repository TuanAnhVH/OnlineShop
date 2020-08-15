using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhập tài khoản")]
        public string User { get; set; }

        [Required(ErrorMessage ="Nhập mật khẩu")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}