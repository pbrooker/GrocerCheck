using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ItemByQuantity> ItemsByQuantity { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<ItemBySize> ItemsBySize { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}