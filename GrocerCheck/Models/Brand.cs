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

        //public int Item { get; set; }


        //Navigation

        public virtual ICollection<Item> Items { get; set; }
        //public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<Category> Categories { get; set; }

        public IEnumerable<Brand> Brands { get; set; }
    }
}