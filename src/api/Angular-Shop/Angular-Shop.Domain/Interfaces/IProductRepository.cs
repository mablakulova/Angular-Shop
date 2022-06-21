using Angular_Shop.Domain.Entities;

namespace Angular_Shop.Domain.Interfaces 
{
    public interface IProductRepository : IDisposable
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product newProduct);
        Task<bool> Update(Product product);
        Task<bool> Delete(int id);
    }
}
