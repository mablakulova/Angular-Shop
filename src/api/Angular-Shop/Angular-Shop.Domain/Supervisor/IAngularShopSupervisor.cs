using Angular_Shop.Domain.ApiModels;

namespace Angular_Shop.Domain.Supervisor
{
    public interface IAngularShopSupervisor
    {
        Task<IEnumerable<ProductApiModel>> GetAllProduct();
        Task<ProductApiModel> GetProductById(int id);
        Task<ProductApiModel> AddProduct(ProductApiModel newProductApiModel);
        Task<bool> UpdateProduct(ProductApiModel productApiModel);
        Task<bool> DeleteProduct(int id);
    }
}
