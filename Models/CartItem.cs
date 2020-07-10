using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class CartItem
    {
        public int      CartItemId { get; set; } // Not Needed Yet
        public Product  Product { get; set; }
        public int      Quantity { get; set; }
        public decimal  SubTotal
        {
            get { return Quantity * Product.Price; }
        }
    }
}
