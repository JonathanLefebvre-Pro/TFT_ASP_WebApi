using AppCore.Interfaces.Queries;
using DE = Domain.Entities;

namespace AppCore.Features.Queries;

public record GetAllTasksQuery() : IQueryDefinition<IEnumerable<DE.Task>>;
