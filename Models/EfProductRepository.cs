using System;
using System.Linq;

namespace SportStore.Models
{
    public class EfProductRepository : IProductRepository
    {
        //   F i e l d s   &   P r o p e r t i e s

        private AppDbContext context;

        //   C o n s t r u c t o r s

        public EfProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        //   M e t h o d s

        //  C r e a t e

        public Product Create(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return product;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //  R e a d

        public IQueryable<Product> GetAllProducts()
        {
            return context.Products.OrderBy(p => p.Name);
        }
        public Product GetProductById(int productId)
        {
            Product theProduct =
                context.Products
                    .Where(p => p.ProductId == productId)
                    .FirstOrDefault();
            return theProduct;
        }
        public IQueryable<Product> GetProductsByKeyword(string keyword)
        {
            return context.Products.Where(p => p.Name.Contains(keyword));
        }
        public IQueryable<string> GetAllCategories()
        {
            return context.Products
                 .Select(p => p.Category)
                 .Distinct()
                 .OrderBy(c => c);
        }
        public IQueryable<Product> GetProductsByCategory(string category)
        {
            return GetAllProducts()
                    .Where(p => p.Category == category)
                    .OrderBy(p => p.ProductId);
        }

        //  U p d a t e

        public Product UpdateProduct(Product product)
        {
            Product productToUpdate =
               context.Products
               .SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Category = product.Category;
                productToUpdate.Description = product.Description;
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                context.SaveChanges();
            }
            return productToUpdate;
        }

        //  D e l e t e

        public bool DeleteProduct(int id)
        {
            Product productToDelete =
               context.Products.FirstOrDefault(p => p.ProductId == id);
            if (productToDelete == null)
            {
                return false;
            }
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
