using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<MyDataCategory> MyDataCategory { get; set; }
    }
}
