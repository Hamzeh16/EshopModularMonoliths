namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCommand
    (ProductDto Product) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is Required");
        RuleFor(x => x.Product.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.Product.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

public class CreateProductHandler
    (CatalogDbContext dbContext, IValidator<CreateProductCommand> validator,
    ILogger<CreateProductHandler> logger)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        // Create Product entity from command object

        // Save to Database

        // Return Result

        // Validtion Part
        var result = await validator.ValidateAsync(command, cancellationToken);
        var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
        if (errors.Any())
        {
            throw new ValidationException(errors.FirstOrDefault());
        }

        //logging part
        logger.LogInformation("CreateProductCommandHandler.Handle called with {@Command}", command);

        //actual logic
        var product = CreateNewProduct(command.Product);

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }

    private Product CreateNewProduct(ProductDto ProductDto)
    {
        var product = Product.Create(
            Guid.NewGuid(),
            ProductDto.Name,
            ProductDto.Category,
            ProductDto.Description,
            ProductDto.ImageFile,
            ProductDto.Price);
        return product;
    }
}
