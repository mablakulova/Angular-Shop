using Angular_Shop.Data.Data;
using Angular_Shop.Data.Repositories;
using Angular_Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Angular_Shop.UnitTests.Repositories
{
    public class ProductRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;

        public ProductRepositoryTest()
        {
            _options = ProductHelperTests.DataContextOptionsEfCoreInMemory();
            ProductHelperTests.CreateDataBaseEfCoreInMemory(_options);
        }

        [Fact]
        public async void GetAll_ShouldReturnAListOfProducts_WhenProductExists()
        {
            await using var context = new DataContext(_options);
            var productRepository = new ProductRepository(context);
            var products = await productRepository.GetAll();

            Assert.NotNull(products);
            Assert.IsType<List<Product>>(products);
        }

        [Fact]
        public async void GetAll_ShouldReturnEmptyList_WhenProductDoNotExist()
        {
            await ProductHelperTests.CleanDataBase(_options);

            await using var context = new DataContext(_options);
            var productRepository = new ProductRepository(context);
            var products = await productRepository.GetAll();

            Assert.NotNull(products);
            Assert.Empty(products);
            Assert.IsType<List<Product>>(products);
            
        }

        [Fact]
        public async void GetById_ShouldReturnProduct_WhenProductExist()
        {
            await using var context = new DataContext(_options);

            var productReposiory = new ProductRepository(context);
            var product = await productReposiory.GetById(1);

            Assert.NotNull(product);
            Assert.IsType<Product>(product);
        }

        [Fact]
        public async void GetById_ShouldReturnNull_WhenProductDoNotExist()
        {
            await ProductHelperTests.CleanDataBase(_options);

            await using var context = new DataContext(_options);

            var productReposiory = new ProductRepository(context);
            var product = await productReposiory.GetById(1);

            Assert.Null(product);
        }

        [Fact]
        public async void AddProduct_ShouldAddProductWithCorrectValues_WhenProductValid()
        {
            Product productToAdd = null;

            await using var context = new DataContext(_options);
            var productRepository = new ProductRepository(context);
            productToAdd = CreateProduct();

            await productRepository.Add(productToAdd);
            var productResult = await context.Products.Where(a => a.Id == 4).FirstOrDefaultAsync();
            

            Assert.NotNull(productResult);
            Assert.IsType<Product>(productResult);
            Assert.Equal(productToAdd.Id, productResult.Id);
            Assert.Equal(productToAdd.ProductName, productResult.ProductName);
            Assert.Equal(productToAdd.ProductCode, productResult.ProductCode);
            Assert.Equal(productToAdd.Price, productResult.Price);
            Assert.Equal(productToAdd.Description, productResult.Description);
            Assert.Equal(productToAdd.StarRating, productResult.StarRating);
            Assert.Equal(productToAdd.ImageUrl, productResult.ImageUrl);
        }

        [Fact]
        public async void UpdateProduct_ShouldUpdateProductWithCorrectValues_WhenProductIsValid()
        {
            Product productToUpdate = null;

            await using var context = new DataContext(_options);
            productToUpdate = await context.Products.Where(a => a.Id == 1).FirstOrDefaultAsync();

            productToUpdate.ProductName = "Updated Product Name";
            productToUpdate.ProductCode = "Updated Product Code";
            productToUpdate.Description = "Updated Description";
            productToUpdate.Price = 12;
            productToUpdate.ReleaseDate = "Tune 15, 2022";
            productToUpdate.StarRating = 2;
            productToUpdate.ImageUrl = "Updated Image Url";

            var productRepository = new ProductRepository(context);
            await productRepository.Update(productToUpdate);
   
            var updatedProduct = await context.Products.Where(a => a.Id == 1).FirstOrDefaultAsync();

            Assert.NotNull(updatedProduct);
            Assert.IsType<Product>(updatedProduct);
            Assert.Equal(productToUpdate.Id, updatedProduct.Id);
            Assert.Equal(productToUpdate.ProductName, updatedProduct.ProductName);
            Assert.Equal(productToUpdate.ProductCode, updatedProduct.ProductCode);
            Assert.Equal(productToUpdate.Description, updatedProduct.Description);
            Assert.Equal(productToUpdate.Price, updatedProduct.Price);
            Assert.Equal(productToUpdate.ReleaseDate, updatedProduct.ReleaseDate);
            Assert.Equal(productToUpdate.StarRating, updatedProduct.StarRating);
            Assert.Equal(productToUpdate.ImageUrl, updatedProduct.ImageUrl);
        }

        [Fact]
        public async void DeleteProduct_ShouldDeleteProduct_WhenProductIsValid()
        {
            Product productToDelete = null;

            await using var context = new DataContext(_options);
            productToDelete = await context.Products.Where(a => a.Id == 1).FirstOrDefaultAsync();

            var productRepository = new ProductRepository(context);
            await productRepository.Delete(productToDelete.Id);
            
            var deletedProduct = await context.Products.Where(a => a.Id == 1).FirstOrDefaultAsync();

            Assert.Null(deletedProduct);
        }
        private Product CreateProduct()
        {
            return new Product()
            {
                Id = 4,
                ProductName = "Saw",
                ProductCode = "TBX-0022",
                ReleaseDate = "May 15, 2021",
                Description = "15-inch steel blade hand saw.",
                Price = 11.55,
                StarRating = 3.7,
                ImageUrl = "assets/images/saw.png"
            };
        }
    }
}
