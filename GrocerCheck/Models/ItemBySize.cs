﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class ItemBySize:Item
    {

        [Display(Name ="Size")]
        public int Size { get; set; }

        [Display(Name ="Measurement type")]
        public string SizeType { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Calculated price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal CalculatedPrice
        {
            get { return Price / Size; }
            private set { }
        }


    }
}