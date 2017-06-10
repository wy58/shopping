using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping.Models
{
    [DisplayName("商品信息")]
    [DisplayColumn("Name")]
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        //[DisplayName("商品类别名称")]
        //[Required(ErrorMessage = "请输入商品类别名称")]
        //[MaxLength(20, ErrorMessage = "类别名称不可超过20个字")]
        //public string Name { get; set; }
        public ProductCategory()
        {
            this.Products = new List<Product2>();
        }
        public virtual IEnumerable<Product2> Products { get; set; }
    }

}