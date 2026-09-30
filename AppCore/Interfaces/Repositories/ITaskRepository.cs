using AppCore.Features.Commands;
using AppCore.Features.Queries;
using AppCore.Interfaces.Commands;
using AppCore.Interfaces.Queries;

namespace AppCore.Interfaces.Repositories;

public interface ITaskRepository
    : IQueryHandler<GetAllTasksQuery, IEnumerable<Domain.Entities.Task>>,
        IQueryHandler<GetTaskByIdQuery, Domain.Entities.Task>,
        ICommandHandler<AddTaskCommand>,
        ICommandHandler<UpdateTaskCommand>,
        ICommandHandler<UpdateTaskCompletionCommand>,
        ICommandHandler<DeleteTaskCommand>;
