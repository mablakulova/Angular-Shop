using Angular_Shop.Data.Data;
using Angular_Shop.Domain.Entities;
using Angular_Shop.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Angular_Shop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> ProductExists(int id) => 
             await _context.Products.AnyAsync(p => p.Id == id);

        public void Dispose() => _context.Dispose();

        public async Task<List<Product>> GetAll() =>
                 await _context.Products.AsNoTrackingWithIdentityResolution().ToListAsync();

        public async Task<Product> GetById(int id)
        {
            var dbProduct = await _context.Products.FindAsync(id);
            return dbProduct;
        }

        public async Task<Product> Add(Product newProduct)
        {
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<bool> Update(Product product)
        {
            if (!await ProductExists(product.Id)) { return false; }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            if(!await ProductExists(id)) { return false; }

            var toRemove = await _context.Products.FindAsync(id);
            _context.Products.Remove(toRemove);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
