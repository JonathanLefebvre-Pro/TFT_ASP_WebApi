using AppCore.Interfaces.Queries;
using DE = Domain.Entities;

namespace AppCore.Features.Queries;

public record GetTaskByIdQuery(int Id) : IQueryDefinition<DE.Task>;
