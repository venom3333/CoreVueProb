using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Models
{
    public class MyDataCategory
    {
        public int MyDataId { get; set; }
        public MyData MyData { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
