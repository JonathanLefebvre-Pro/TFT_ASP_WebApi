using AppCore.Features.Results;

namespace AppCore.Interfaces.Queries;

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQueryDefinition<TResult>
{
    Result<TResult> Handle(TQuery query);
}

public interface IQueryHandlerAsync<TQuery, TResult>
    where TQuery : IQueryDefinition<TResult>
{
    Task<Result<TResult>> HandleAsync(TQuery query);
}
