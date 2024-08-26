using MicroservicesWithCQRSDesignPattern.Interfaces;
using MicroservicesWithCQRSDesignPattern.Queries.CommandModel;
using MicroservicesWithCQRSDesignPattern.Model;
using MicroservicesWithCQRSDesignPattern.Queries.QueryModel;

namespace MicroservicesWithCQRSDesignPattern.Handlers
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand command)
        {
            // Fetch the product to update from the repository
            var productToUpdate = await _repository.GetByIdAsync(command.Id);

            if (productToUpdate != null)
            {
                // Update the product properties
                productToUpdate.ProductName = command.Name;
                productToUpdate.UnitPrice = command.Price;
                // Update other properties

                // Save changes to the repository
                await _repository.UpdateAsync(productToUpdate);
                await _repository.SaveAsync();
            }
            else
            {
                throw new Exception("Product not found"); // Handle product not found scenario
            }
        }
    }
}

