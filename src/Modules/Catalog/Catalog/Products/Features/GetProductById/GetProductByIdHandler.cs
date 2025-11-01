namespace Catalog.Products.Features.GetProductById;

public record GetProductByIdQuery(Guid Id)
    : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(ProductDto Products);


internal class GetProductByIdHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        // Get products by category sing DbContext
        // Retern Result

        var products = await dbContext.Products
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == query.Id, cancellationToken);

        if(products is null)
        {
            throw new ProductNotFoundException(query.Id);
        }

        // mapping product entity to productdto Using Mapster
        var productDtos = products.Adapt<ProductDto>();


        return new GetProductByIdResult(productDtos);
    }
}

