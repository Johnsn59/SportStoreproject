using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        //  F i e l d s   &   P r o p e r t i e s

        private IProductRepository repository;
        public int PageSize { get; set; } = 3;

        //  C o n s t r u c t o r s

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        //  M e t h o d s

        //  C r e a t e

        [HttpGet]
        public IActionResult Create()
        {
            Product newProduct = new Product();
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            repository.Create(product);
            return RedirectToAction("Index");
        }

        //  R e a d

        public IActionResult Index(string category, int productPage = 1)
        {
            ProductListViewModel plvm = new ProductListViewModel();

            plvm.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                //TotalItems = repository.GetAllProducts().Count()
            };

            if (category == null)
            {
                plvm.Products =
                   repository.GetAllProducts()
                             .OrderBy(p => p.ProductId)
                             .Skip((productPage - 1) * PageSize)
                             .Take(PageSize);
                plvm.PagingInfo.TotalItems = repository.GetAllProducts().Count();

            }
            else
            {
                //plvm.PagingInfo.TotalItems =
                //    repository.GetProductsByCategory()
                //    .Where(p => p.Category == category)
                //    .Count();

                plvm.Products =
                   repository.GetProductsByCategory(category)
                             .Skip((productPage - 1) * PageSize)
                             .Take(PageSize);
                plvm.PagingInfo.TotalItems = repository.GetProductsByCategory(category).Count();
            }

            plvm.CurrentCategory = category;

            return View(plvm);
        }
        public IActionResult Detail(int id)
        {
            Product product = repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Search(string id)
        {
            IQueryable<Product> products = repository.GetProductsByKeyword(id);
            return View(products);
        }
        [HttpPost]
        public IActionResult Search(string keyword, int ProductId)
        {
            //Product product = repository.GetProductById(ProductId);
            IQueryable<Product> products = repository.GetProductsByKeyword(keyword);
            return View(products);
        }

        //  U p d a t e

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Product product, int id)
        {
            product.ProductId = id;
            repository.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        //  D e l e t e

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = repository.GetProductById(id);
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Product product, int id)
        {
            repository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}
