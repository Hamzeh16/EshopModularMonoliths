using MediatR;

namespace Shared.CQRS;

public interface IQueryHandler<in TQuery, TRespone>
    : IRequestHandler<TQuery, TRespone>
    where TQuery : IQuery<TRespone>
    where TRespone : notnull
{
}

