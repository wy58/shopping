using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shopping.Models
{
    [DisplayName("会员资料")]
    [DisplayColumn("Name")]
        public class Members
        {
            [Key]
            public int Id { get; set; }

            [DisplayName("会员账号")]
            [Required(ErrorMessage = "请输入Email地址")]
            [Description("我们直接以Email当成会员账号")]
            [MaxLength(250, ErrorMessage = "Email地址长度无法超过250个字符")]
            [DataType(DataType.EmailAddress)]
            [Remote("CheckDup", "Mamber", HttpMethod = "Post", ErrorMessage = "您输入的Email已经有人注册过了")]
            public string Email { get; set; }


            [DisplayName("会员密码")]
            [Required(ErrorMessage = "请输入密码")]
            [MaxLength(40, ErrorMessage = "请输入密码")]
            [Description("密码将以SHA1进行散列运算，通过SHA1散列运算过后的结果转为HEX表示法的字符串长度皆为40个字符")]
            [DataType(DataType.Password)]
            public string password { get; set; }

            [DisplayName("中文名字")]
            [Required(ErrorMessage = "请输入中文名字")]
            [MaxLength(5, ErrorMessage = "中文姓名不可超过5个字符")]
            [Description("暂不考虑用英文注册会员的情况")]
            public string Name { get; set; }


            //密码
            public string AuthCode { get; set; }
            //登录的时间
            public string RegisterOn { get; set; } 
            //public virtual ICollection<OrderHeader> Orders { get; set; }
        }
    }