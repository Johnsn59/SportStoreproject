using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SportStore.Models
{
    public class SessionCartRepository : ICartRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private readonly IHttpContextAccessor httpContextAccessor;

        //   C o n s t r u c t o r s

        public SessionCartRepository(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        //   M e t h o d s

        public Cart GetCart()
        {
            string cartJsonString = httpContextAccessor
                                    .HttpContext.Session.GetString("_CartJson");
            if (cartJsonString != null)
            {
                Cart myCart = JsonConvert.DeserializeObject<Cart>(cartJsonString);
                return myCart;
            }
            return new Cart();
        }

        public void SaveCart(Cart cart)
        {
            string cartJsonString = JsonConvert.SerializeObject(cart);
            httpContextAccessor.HttpContext.Session.SetString("_CartJson", cartJsonString);
        }
        public void Remove(int productId)
        {
            Cart cart = GetCart();
            cart.RemoveItem(productId);
            SaveCart(cart);
        }

        public void Remove(Product product)
        {
            Cart cart = GetCart();
            cart.RemoveItem(product);
            SaveCart(cart);
        }
    }
}
