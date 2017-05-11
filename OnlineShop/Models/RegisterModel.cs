using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = " Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name = " Mật khẩu")]
        [StringLength(20, MinimumLength = 6,ErrorMessage = "Độ dài mật khẩu từ 6 đến 20 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = " Xác nhận mật khẩu")]
        [Compare("Password",ErrorMessage = "Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = " Họ tên")]
        [Required(ErrorMessage = "Bạn phải nhập tên")]
        public string Name { get; set; }

        [Display(Name = " Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = " Email")]
        [Required(ErrorMessage = "Bạn phải nhập Email")]
        public string Email { get; set; }
        [Display(Name = " Điện thoại")]
        public string Phone { get; set; }
        [Display(Name = " Tỉnh/Thành")]
        public string ProvinceID { get; set; }

        [Display(Name = "Quận/Huyện")]
        public string DistrictID { get; set; }

    }
}