
namespace Catalog.Products.EventHandlers;

public class ProductPriceChangedEventHandler(ILogger<ProductPriceChangedEventHandler> logger)
    : INotificationHandler<ProductPriceChagedEvent>
{
    public Task Handle(ProductPriceChagedEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

