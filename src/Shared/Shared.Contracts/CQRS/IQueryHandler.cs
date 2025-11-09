using MediatR;

namespace Shared.Contracts.CQRS;

public interface IQueryHandler<in TQuery, TRespone>
    : IRequestHandler<TQuery, TRespone>
    where TQuery : IQuery<TRespone>
    where TRespone : notnull
{
}

