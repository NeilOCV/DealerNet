using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class orders
    {
        public string id { get; set; }
        public DateTime order_date { get; set; }
        public string items_id { get; set; }
        public int quantity { get; set; }
    }
}
