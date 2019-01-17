using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stackoverflow_popular_tags.Models
{
    public class Tags
    {
        public List<Item> Items { get; set; }
     
    }

    public class Item
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public double Percent = 0; 
               
    }
}