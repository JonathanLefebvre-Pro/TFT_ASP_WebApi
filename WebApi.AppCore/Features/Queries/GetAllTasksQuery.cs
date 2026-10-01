using WebApi.AppCore.Interfaces.Queries;
using DE = WebApi.Domain.Entities;

namespace WebApi.AppCore.Features.Queries;

public record GetAllTasksQuery() : IQueryDefinition<IEnumerable<DE.Task>>;
