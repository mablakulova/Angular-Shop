using Angular_Shop.Domain.Converters;
using Angular_Shop.Domain.Entities;

namespace Angular_Shop.Domain.ApiModels
{
    public class ProductApiModel : BaseApiModel, IConvertModel<ProductApiModel, Product>
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double StarRating { get; set; }
        public string ImageUrl { get; set; }
        public Product Convert() =>
            new()
            {
                Id = Id,
                ProductName = ProductName,
                ProductCode = ProductCode,
                ReleaseDate = ReleaseDate,
                Description = Description,
                Price = Price,
                StarRating = StarRating,
                ImageUrl = ImageUrl
            };
    }
}
