namespace Catalog.Products.Events;

public record ProductPriceChagedEvent(Product Product)
    : IDomainEvent;
