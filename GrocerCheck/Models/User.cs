using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class User
    {

        public int UserID { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [StringLength(65)]
        [Display(Name ="Last Name")]
        public string LName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int GrocerID  { get; set; }

        public int BrandID { get; set; }

        public int SizeID { get; set; }

        public bool Admin { get; set; }

    }
}