using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class Brand
    {
        public int BrandID { get; set; }


        [Required]
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }
    }
}