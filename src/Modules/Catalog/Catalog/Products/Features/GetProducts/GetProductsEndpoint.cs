
namespace Catalog.Products.Features.GetProducts;


// public record GetProductsRequests();

public record GetProductsRespone(IEnumerable<ProductDto> Products);

public class GetProductsEndpoint
    : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());

            var response = result.Adapt<GetProductsRespone>();

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductsRespone>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}
