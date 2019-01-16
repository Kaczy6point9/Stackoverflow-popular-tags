using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stackoverflow_popular_tags.Models
{
    public class Tags
    {
        public IList<Item> items { get; set; }
    }

    public class Item
    {
        public int count { get; set; }
        public string name { get; set; }
    }
}