using AppCore.Interfaces.Queries;

namespace AppCore.Features.Queries;

public record GetTaskByIdQuery(int Id) : IQueryDefinition<Domain.Entities.Task>;
