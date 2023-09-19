using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ElectricStoreDbContext _context;

        public ProductRepo(ElectricStoreDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            return await Save();
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return await Save();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.OrderBy(p => p.Id).ToListAsync();
        }

        public Task<bool> HasProduct(int id)
        {
            return _context.Products.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> Save()
        {
            var saved = _context.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return await Save();
        }
    }
}
