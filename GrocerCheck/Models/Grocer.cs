using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class Grocer
    {
        public int GrocerID { get; set; }

        [Required]
        [Display(Name = "Grocer Name")]
        public string GrocerName { get; set; }


        // Navigation

        public virtual ICollection<Category> Categories {get; set;}

        public virtual ICollection<Brand> Brands { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public virtual ICollection<ItemByQuantity> Itembyquantity { get; set; }

        public virtual ICollection<ItemBySize> Itembysize { get; set; }
    }
}