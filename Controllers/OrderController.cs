using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System.Linq;

namespace SportStore.Controllers
{
    public class OrderController : Controller
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IOrderRepository repository;
        private ICartRepository cartRepository;

        //   C o n s t r u c t o r s

        public OrderController(IOrderRepository repository, ICartRepository cartRepository)
        {
            this.repository = repository;
            this.cartRepository = cartRepository;
        }

        //   M e t h o d s

        [HttpGet]
        public IActionResult Checkout()
        {
            Order newOrder = new Order();
            return View(newOrder);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            Cart cart = cartRepository.GetCart();
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Your Cart Is Empty");
            }

            if (ModelState.IsValid)
            {
                order.Items = cart.Items.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                cartRepository.SaveCart(cart);
                return RedirectToAction("Completed");
            }

            return View(order);
        }

        public IActionResult Completed()
        {
            return View();
        }
    }
}
