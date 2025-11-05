

namespace Basket.Basket.Features.GetBasket;

public record GetBasketQuery(string UserName)
    : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCartDto ShoppingCart);

internal class GetBasketHandler(IBasketRepossitory repossitory)
    : IQueryHandler<GetBasketQuery, GetBasketResult>

{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        // get basket with userName
        var basket = await repossitory.GetBasket(query.UserName,true,cancellationToken);

        //mapping basket entity to shoppingcartdto
        var basketDto = basket.Adapt<ShoppingCartDto>();

        return new GetBasketResult(basketDto);
    }
}

