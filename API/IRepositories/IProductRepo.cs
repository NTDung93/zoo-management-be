using API.Models;

namespace API.IRepositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task<bool> HasProduct(int id);
        Task<bool> Save();
    }
}
