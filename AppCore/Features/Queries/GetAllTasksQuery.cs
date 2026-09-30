using AppCore.Interfaces.Queries;

namespace AppCore.Features.Queries;

public record GetAllTasksQuery() : IQueryDefinition<IEnumerable<Domain.Entities.Task>> { }
