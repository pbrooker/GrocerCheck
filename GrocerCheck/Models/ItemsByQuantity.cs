using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrocerCheck.Models
{
    public class ItemsByQuantity:Item
    {

        public int ItemByQuantityID { get; set; }


        public int Quantity { get; set; }

    

    }
}