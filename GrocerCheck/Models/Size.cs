using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class Size
    {
        public int SizeID { get; set; }

        [Required]
        [Display(Name ="Description - eg Jumbo Pack")]
        public string SizeDescription { get; set; }
    }
}