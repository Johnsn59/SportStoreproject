using System.Linq;

namespace SportStore.Models
{
    public interface IProductRepository
    {
        //   C r e a t e

        Product Create(Product product);

        //  R e a d

        IQueryable<Product> GetAllProducts();
        Product GetProductById(int productId);
        IQueryable<Product> GetProductsByKeyword(string keyword);
        IQueryable<string> GetAllCategories();
        IQueryable<Product> GetProductsByCategory(string category);

        //   U p d a t e

        Product UpdateProduct(Product product);

        //  D e l e t e

        bool DeleteProduct(int id);
    }
}
