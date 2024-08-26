using MicroservicesWithCQRSDesignPattern.Interfaces;
using MicroservicesWithCQRSDesignPattern.Model;
using MicroservicesWithCQRSDesignPattern.Queries.CommandModel;

namespace MicroservicesWithCQRSDesignPattern.Handlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = new Product
            {
                ProductName = command.Name,
                UnitPrice = command.Price
            };

            await _repository.AddAsync(product);
            await _repository.SaveAsync();
        }
    }
}
