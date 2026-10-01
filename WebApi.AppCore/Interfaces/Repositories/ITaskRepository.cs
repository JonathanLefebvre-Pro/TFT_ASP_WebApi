using WebApi.AppCore.Features.Commands;
using WebApi.AppCore.Features.Queries;
using WebApi.AppCore.Interfaces.Commands;
using WebApi.AppCore.Interfaces.Queries;
using DE = WebApi.Domain.Entities;

namespace WebApi.AppCore.Interfaces.Repositories;

public interface ITaskRepository
    : IQueryHandler<GetAllTasksQuery, IEnumerable<DE.Task>>,
        IQueryHandlerAsync<GetAllTasksQuery, IEnumerable<DE.Task>>,
        IQueryHandler<GetTaskByIdQuery, DE.Task>,
        IQueryHandlerAsync<GetTaskByIdQuery, DE.Task>,
        ICommandHandler<AddTaskCommand, int>,
        ICommandHandler<UpdateTaskCommand>,
        ICommandHandler<UpdateTaskCompletionCommand>,
        ICommandHandler<DeleteTaskCommand>;
