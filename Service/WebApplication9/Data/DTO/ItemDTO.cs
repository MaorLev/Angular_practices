using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Data.DTO
{
    public class ItemDTO
    {
        public string ItemName { get; set; }
        public string ItemCompanyName { get; set; }
        public int ItemCount { get; set; }
        public int ItemSerial { get; set; }
        public bool ?ItemActive { get; set; }
        public int ItemPrice { get; set; }
    }
}
