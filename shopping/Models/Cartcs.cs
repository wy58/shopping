using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopping.Models
{
    public class Cartcs
    {
        [Key]
        public int Id { get; set; }

        public int mid { get; set; }
        public string Product { get; set; }
        
        public int Amount { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}