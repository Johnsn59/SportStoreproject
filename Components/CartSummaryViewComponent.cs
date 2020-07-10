using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        //   F i e l d s   &   M e t h o d s

        private ICartRepository repository;

        //   C o n s t r u c t o r s

        public CartSummaryViewComponent
           (ICartRepository repository)
        {
            this.repository = repository;
        }

        //   M e t h o d s

        public IViewComponentResult Invoke()
        {
            return View(repository.GetCart());
        }
    }
}
