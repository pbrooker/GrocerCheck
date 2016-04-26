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
        [Display(Name ="Grocer Name")]
        public string GrocerName { get; set; }
    }
}