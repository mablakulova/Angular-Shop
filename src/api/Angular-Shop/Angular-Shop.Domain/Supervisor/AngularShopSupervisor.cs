using Angular_Shop.Domain.ApiModels;
using Angular_Shop.Domain.Entities;
using Angular_Shop.Domain.Interfaces;
using FluentValidation;
using Angular_Shop.Domain.Extensions;

namespace Angular_Shop.Domain.Supervisor
{
    public class AngularShopSupervisor : IAngularShopSupervisor
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<ProductApiModel> _productValidator;

        public AngularShopSupervisor(IProductRepository productRepository, IValidator<ProductApiModel> productValidator)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
        }

        public async Task<IEnumerable<ProductApiModel>> GetAllProduct()
        {
            var products = await _productRepository.GetAll();
            var productApiModels = products.ConvertAll();

            return productApiModels;
        }

        public async Task<ProductApiModel> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null) return null;

            var productApiModel = product.Convert();
            return productApiModel; 
        }


        public async Task<ProductApiModel> AddProduct(ProductApiModel newProductApiModel)
        {
            await _productValidator.ValidateAndThrowAsync(newProductApiModel);

            var product = newProductApiModel.Convert();

            product = await _productRepository.Add(product);
            newProductApiModel.Id = product.Id;
            return newProductApiModel;
        }

        public async Task<bool> UpdateProduct(ProductApiModel productApiModel)
        {
            await _productValidator.ValidateAndThrowAsync(productApiModel);

            var product = await _productRepository.GetById(productApiModel.Id);

            if (product is null) { return false; }

            product.Id = productApiModel.Id;
            product.ProductName = productApiModel.ProductName;
            product.ProductCode = productApiModel.ProductCode;
            product.Description = productApiModel.Description;
            product.ReleaseDate = productApiModel.ReleaseDate;
            product.StarRating = productApiModel.StarRating;
            product.Price = productApiModel.Price;
            product.ImageUrl = productApiModel.ImageUrl;

            return await _productRepository.Update(product);    
        }

        public async Task<bool> DeleteProduct(int id) => await _productRepository.Delete(id);
    }
}
