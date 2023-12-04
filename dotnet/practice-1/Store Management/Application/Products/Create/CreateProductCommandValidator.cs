using Domain.Products;
using FluentValidation;

namespace Application.Products.Create
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator(IProductRepository repository)
        {
            RuleFor(p => p.Sku).MustAsync(async (sku, _) =>
            {
                return await repository.IsSkuUniqueAsync(Sku.Create(sku)!);
            }).WithMessage("The sku must be unique");
        }
    }
}
