using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ đăng nhập?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Họ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [StringLength(100, ErrorMessage = "Mật khẩu từ {0} đến {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác thực không đúng.")]
        public string ConfirmPassword { get; set; }
    }
    
}