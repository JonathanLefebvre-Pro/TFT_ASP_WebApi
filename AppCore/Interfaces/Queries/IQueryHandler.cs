using System;
using AppCore.Interfaces.Commands;

namespace AppCore.Interfaces.Queries;

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQueryDefinition<TResult>
{
    TResult Handle(TQuery query);
}
