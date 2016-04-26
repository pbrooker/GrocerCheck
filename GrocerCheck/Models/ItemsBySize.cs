﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class ItemsBySize:Item
    {
        public int ItemBySizeID { get; set; }


        [Display(Name ="Size")]
        public int Size { get; set; }

        [Display(Name ="Measurement type - eg ml, gm, Kg")]
        public string SizeType { get; set; }


    }
}