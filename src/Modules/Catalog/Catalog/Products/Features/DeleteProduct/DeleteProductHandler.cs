using Catalog.Products.Features.UpdateProduct;

namespace Catalog.Products.Features.DeleteProduct;


public record DeleteProductCommand(Guid ProductId)
    : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product Id is Required");
    }
}

internal class DeleteProductHandler(CatalogDbContext dbContext)
     : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        // Create Product entity from command object

        // Save to Database

        // Return Result

        var product = await dbContext.Products
            .FindAsync([command.ProductId], cancellationToken: cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.ProductId);
        }

        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}

