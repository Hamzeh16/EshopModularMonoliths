
namespace Catalog.Products.EventHandlers;

public class ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
    : INotificationHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        // TODO: Publish product price changed integration event for update basket prices
        
        logger.LogInformation("Domain Event havdled: {DomainEvent}",notification.GetType().Name);
        return Task.CompletedTask;
    }
}
