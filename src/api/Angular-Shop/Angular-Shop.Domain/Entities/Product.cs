using Angular_Shop.Domain.ApiModels;
using Angular_Shop.Domain.Converters;

namespace Angular_Shop.Domain.Entities
{
    public partial class Product : BaseEntity, IConvertModel<Product, ProductApiModel>
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double StarRating { get; set; }
        public string ImageUrl { get; set; }

        public ProductApiModel Convert() =>
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
