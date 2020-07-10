using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class Cart
    {
        //   F i e l d s   &   P r o p e r t i e s

        private List<CartItem> items = new List<CartItem>();
        public virtual IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        public decimal TotalValue
        {
            get { return items.Sum(i => i.SubTotal); }
        }

        //   C o n s t r u c t o r s

        //   M e t h o d s

        public virtual void AddItem(Product product, int quantity)
        {
            CartItem item = items.FirstOrDefault(i => i.Product.ProductId == product.ProductId);

            if (item == null)
            {
                item = new CartItem
                {
                    Product = product,
                    Quantity = quantity
                };
                items.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public virtual void Clear()
        {
            items.Clear();
        }

        public virtual void RemoveItem(int productId)
        {
            items.RemoveAll(i => i.Product.ProductId == productId);
        }

        public virtual void RemoveItem(Product product)
        {
            items.RemoveAll
               (i => i.Product.ProductId == product.ProductId);
        }
    }
}
