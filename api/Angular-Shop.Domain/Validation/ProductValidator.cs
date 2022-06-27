using Angular_Shop.Domain.ApiModels;
using FluentValidation;

namespace Angular_Shop.Domain.Validation
{
    public class ProductValidator : AbstractValidator<ProductApiModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotNull();
            RuleFor(p => p.Description).MinimumLength(5);
            RuleFor(p => p.ProductCode).NotNull();
        }
    }
}
