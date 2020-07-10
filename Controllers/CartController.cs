using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        //   F i e l d s   &   P r o p e r t i e s

        private ICartRepository repository;        // Main
        private IProductRepository productRepository; // Secondary


        //   C o n s t r u c t o r s

        public CartController(ICartRepository repository,
         IProductRepository productRepository
)
        {
            this.repository = repository;        // Main
            this.productRepository = productRepository; // 2nd

        }

        //   M e t h o d s

        //   C r e a t e - i s h

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = productRepository.GetProductById(productId);
            if (product != null)
            {
                Cart cart = repository.GetCart();
                cart.AddItem(product, 1);
                repository.SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //   R e a d - i s h

        public IActionResult Index(string returnUrl)
        {
            CartIndexViewModel model = new CartIndexViewModel();
            model.Cart = repository.GetCart();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        private Cart GetCart()
        {
            string cartJsonString = HttpContext.Session.GetString("_CartJson");
            if (cartJsonString != null)
            {
                return JsonConvert.DeserializeObject<Cart>(cartJsonString);
            }
            return new Cart();
        }

        private void SaveCart(Cart cart)
        {
            string cartJsonString = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("_CartJson", cartJsonString);
        }

        //   U p d a t e

        //   D e l e t e

        [HttpPost]
        public IActionResult Remove(int productId, string returnUrl)
        {
            repository.Remove(productId);
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}
