using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System.Linq;

namespace SportStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IProductRepository repository;

        //   C o n s t r u c t o r s

        public NavigationMenuViewComponent
           (IProductRepository repository) // IOC / DI
        {
            this.repository = repository;
        }

        //   M e t h o d s

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = 
                RouteData?.Values["category"];
            IQueryable<string> allCategories = 
                repository.GetAllCategories();
            return View(allCategories);
        }

    }
}
