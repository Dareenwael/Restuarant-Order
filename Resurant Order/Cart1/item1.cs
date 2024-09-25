using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart1
{
    internal class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int Quantity { get; set; }
        public float Price  { get; set; }
        public  string Description { get; set; }
    }
}
