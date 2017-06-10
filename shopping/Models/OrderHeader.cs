using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace shopping.Models
{
    [DisplayName("订单表头")]
    [DisplayColumn("DisplayName")]
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("订购会员")]
        [Required]
        public virtual Members Member { get; set; }
        [DisplayName("收件人姓名")]
        [Required(ErrorMessage = "请输入收件人姓名，例如：小明")]
        [MaxLength(40, ErrorMessage = "收件人姓名长度不可超过40个字符")]
        [Description("订购的会员不一定就是收到商品的人")]
        public string ContactName { get; set; }
        [DisplayName("联系电话")]
        [Required(ErrorMessage = "请输入您的联系电话，例如：12345678")]
        [MaxLength(25, ErrorMessage = "电话号码长度不可超过25个字符")]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhoneNo { get; set; }
        [DisplayName("派送地址")]
        [Required(ErrorMessage = "请输入商品派送地址")]
        public string ContactAddress { get; set; }

        //时间
        public string BuyOn { get; set; }
        [NotMapped]
        public string DisplayName {
         get { return this.Member.Name+ "于" + this.BuyOn+ "订购的商品"; }
         }
        public virtual ICollection<OrderDetail> OrderDetailItems { get; set; }
    }
}