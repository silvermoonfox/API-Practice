using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DataApi.Helper
{
    public class LoginVModel
    {
        [DisplayName("登入帳號")]
        [Required(ErrorMessage = "請輸入登入帳號")]
        [StringLength(40, ErrorMessage = "登入帳號最多20個字")]
        public string UserName { get; set; }

        [DisplayName("登入密碼")]
        [Required(ErrorMessage = "請輸入登入密碼")]
        [StringLength(40, ErrorMessage = "密碼最多20個字")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
