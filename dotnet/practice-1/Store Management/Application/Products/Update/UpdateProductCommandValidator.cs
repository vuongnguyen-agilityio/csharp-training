using Domain.Products;
using FluentValidation;

namespace Application.Products.Update
{
    public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductCommandValidator(IProductRepository repository)
        {
            RuleFor(p => p.Sku).MustAsync(async (sku, _) =>
            {
                return await repository.IsSkuUniqueAsync(Sku.Create(sku)!);
            }).WithMessage("The sku must be unique");
        }
    }
}
