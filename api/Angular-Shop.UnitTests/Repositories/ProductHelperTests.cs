using Angular_Shop.Data.Data;
using Angular_Shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Angular_Shop.UnitTests.Repositories
{
    public static class ProductHelperTests
    {
        public static DbContextOptions<DataContext> DataContextOptionsEfCoreInMemory()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase($"ProductDatabase{Guid.NewGuid()}")
                .Options;

            return options;
        } 

        public static async void CreateDataBaseEfCoreInMemory(DbContextOptions<DataContext> options)
        {
            await using var context = new DataContext(options);
            CreateData(context);
        } 

        public static async Task CleanDataBase(DbContextOptions<DataContext> options)
        {
            await using var context = new DataContext(options);
            
            foreach (var product in context.Products)
            context.Products.Remove(product);

            await context.SaveChangesAsync();
        }

        private static void CreateData(DataContext dataContext)
        {
            dataContext.Products.Add(new Product()
            {
                Id = 1,
                ProductName = "Leaf Rake1",
                ProductCode = "GDN-0011",
                ReleaseDate = "March 19, 2021",
                Description = "Leaf rake with 48-inch wooden handle.",
                Price = 19.95,
                StarRating = 3.2,
                ImageUrl = "assets/images/leaf_rake.png"
            });
            dataContext.Products.Add(new Product()
            {
                Id = 2,
                ProductName = "Garden Cart",
                ProductCode = "GDN-0023",
                ReleaseDate = "March 18, 2021",
                Description = "15 gallon capacity rolling garden cart.",
                Price = 32.99,
                StarRating = 4.2,
                ImageUrl = "assets/images/garden_cart.png"
            });
            dataContext.Products.Add(new Product()
            {
                Id = 3,
                ProductName = "Hammer",
                ProductCode = "TBX-0048",
                ReleaseDate = "May 21, 2021",
                Description = "Curved claw steel hammer.",
                Price = 8.9,
                StarRating = 4.8,
                ImageUrl = "assets/images/saw.png"
            });

            dataContext.SaveChangesAsync();
        }
    }
}
