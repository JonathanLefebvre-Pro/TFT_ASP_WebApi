using AppCore.Features.Commands;
using AppCore.Features.Queries;
using AppCore.Interfaces.Commands;
using AppCore.Interfaces.Queries;
using DE = Domain.Entities;

namespace AppCore.Interfaces.Repositories;

public interface ITaskRepository
    : IQueryHandler<GetAllTasksQuery, IEnumerable<DE.Task>>,
        IQueryHandlerAsync<GetAllTasksQuery, IEnumerable<DE.Task>>,
        IQueryHandler<GetTaskByIdQuery, DE.Task>,
        IQueryHandlerAsync<GetTaskByIdQuery, DE.Task>,
        ICommandHandler<AddTaskCommand, int>,
        ICommandHandler<UpdateTaskCommand>,
        ICommandHandler<UpdateTaskCompletionCommand>,
        ICommandHandler<DeleteTaskCommand>;
