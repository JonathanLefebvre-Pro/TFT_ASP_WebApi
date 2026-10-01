using WebApi.AppCore.Interfaces.Queries;
using DE = WebApi.Domain.Entities;

namespace WebApi.AppCore.Features.Queries;

public record GetTaskByIdQuery(int Id) : IQueryDefinition<DE.Task>;
