using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrocerCheck.Models;

namespace GrocerCheck.viewModels
{
    public class GrocerIndexData
    {

        //for reading related data: Grocers - Catagories - Items

        public IEnumerable<Grocer> Grocers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Item> Items { get; set; }

    }
}