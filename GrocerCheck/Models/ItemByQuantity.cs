using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class ItemByQuantity:Item
    {

        public int Quantity { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Calculated price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal CalculatedPrice
        {
            get { return Price / Quantity; }

            private set { }
        }


    }
}