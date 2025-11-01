
using Shared.Pagination;

namespace Catalog.Products.Features.GetProducts;


 public record GetProductsRequests(PaginationRequest PaginationRequest);

public record GetProductsRespone(PaginatedResult<ProductDto> Products);

public class GetProductsEndpoint
    : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery(request));

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
