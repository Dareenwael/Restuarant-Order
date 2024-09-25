using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart1
{
    internal class Cartitem
    {
        public Cartitem()
        {
            Quantity = 1;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public Item Item { get; set; }
    }
}
