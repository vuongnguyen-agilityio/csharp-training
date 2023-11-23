﻿using Application.Data;
using Domain.Products;
using MediatR;

namespace Application.Products.Create
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                new ProductId(Guid.NewGuid()),
                request.Name,
                new Money(request.Currency, request.Amount),
                Sku.Create(request.Sku)!);

            _repository.Add(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
