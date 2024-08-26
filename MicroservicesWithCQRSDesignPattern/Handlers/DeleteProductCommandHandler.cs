using MicroservicesWithCQRSDesignPattern.Interfaces;
using MicroservicesWithCQRSDesignPattern.Queries.CommandModel;
using MicroservicesWithCQRSDesignPattern.Model;
using MicroservicesWithCQRSDesignPattern.Queries.QueryModel;

namespace MicroservicesWithCQRSDesignPattern.Handlers
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProductCommand command)
        {
            var productToDelete = await _repository.GetByIdAsync(command.Id);

            if (productToDelete != null)
            {
                await _repository.DeleteAsync(productToDelete);
            }
            else
            {
                throw new Exception("Product not found"); // Handle product not found scenario
            }
        }
    }
}
