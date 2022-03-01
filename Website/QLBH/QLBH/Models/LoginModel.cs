using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLBH.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        [Display(Name ="Tên đăng nhập")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        [Display(Name ="Mật khẩu")]
        public string Password { get; set; }
    }
}