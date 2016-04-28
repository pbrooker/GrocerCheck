using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public abstract class Item
    {

        public int ItemID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(65)]
        public string ItemName { get; set; }

        public int BrandID { get; set; }  //FK

        public int GrocerID { get; set; }   //FK

        public int CategoryID { get; set; } //FK

        public int SizeID { get; set; }  //FK

        [Display(Name = "Barcode or Standard ID")]
        public int StandardIdent { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Updated")]
        public DateTime Updated { get; set; }


        //Navigation

        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Grocer> Grocers { get; set; }

        public virtual Item item { get; set; }

    }
}