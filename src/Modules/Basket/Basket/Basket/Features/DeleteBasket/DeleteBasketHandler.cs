
namespace Basket.Basket.Features.DeleteBasket;

public record DeleteBasketCommand(string UserName)
    : ICommand<DeleteBasketResult>;

public record DeleteBasketResult(bool IsSuccess);

internal class DeleteBasketHandler(IBasketRepossitory repossitory)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        //Delete Basket entity from command object
        //save to database
        //return result

        await repossitory.DeleteBasket(command.UserName, cancellationToken);

        return new DeleteBasketResult(true);
    }
}

