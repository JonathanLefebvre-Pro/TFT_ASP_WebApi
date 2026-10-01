using System.Data.Common;
using Dapper;
using WebApi.AppCore.Features.Commands;
using WebApi.AppCore.Features.Errors;
using WebApi.AppCore.Features.Queries;
using WebApi.AppCore.Features.Results;
using WebApi.AppCore.Interfaces.Repositories;
using DE = WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Services;

public class TaskRepository : ITaskRepository
{
    private readonly DbConnection _dbConnection;

    public TaskRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        _dbConnection.Open();
    }

    public Result<IEnumerable<DE.Task>> Handle(GetAllTasksQuery query)
    {
        string sqlQuery = @"SELECT id, title, creationDate, done FROM Tasks";

        return _dbConnection.Query<DE.Task>(sqlQuery).ToList();
    }

    public async Task<Result<IEnumerable<DE.Task>>> HandleAsync(GetAllTasksQuery query)
    {
        string sqlQuery = @"SELECT id, title, creationDate, done FROM Tasks";

        /*IEnumerable<DE.Task> tasks =*/return (await _dbConnection.QueryAsync<DE.Task>(sqlQuery)).ToList();

        //return Result<IEnumerable<DE.Task>>.Success(tasks);
    }

    public Result<DE.Task> Handle(GetTaskByIdQuery query)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", query.Id);

        string sqlQuery = @"SELECT * FROM Tasks WHERE id=@id";

        DE.Task? task = _dbConnection.QuerySingleOrDefault<DE.Task>(sqlQuery, parameters);

        if (task is null)
            return TaskError.NotFound;

        return task;
    }

    public async Task<Result<DE.Task>> HandleAsync(GetTaskByIdQuery query)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", query.Id);

        string sqlQuery = @"SELECT * FROM Tasks WHERE id=@id";

        DE.Task? task = await _dbConnection.QuerySingleOrDefaultAsync<DE.Task>(
            sqlQuery,
            parameters
        );

        if (task is null)
            return TaskError.NotFound;

        return task;
    }

    public Result<int> Handle(AddTaskCommand command)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@title", command.Title);

        string sqlQuery = @"INSERT INTO Tasks (title) OUTPUT inserted.id VALUES (@title)";

        try
        {
            int? id = (int?)_dbConnection.ExecuteScalar(sqlQuery, parameters);

            if (!id.HasValue)
                return TaskError.NotInserted;

            return id;
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    public Result Handle(UpdateTaskCommand command)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", command.Id);
        parameters.Add("@title", command.Title);
        parameters.Add("@completed", command.Completed);

        string sqlQuery = @"UPDATE Tasks SET title=@title, done=@completed WHERE id=@id";

        try
        {
            int rows = _dbConnection.Execute(sqlQuery, parameters);
            if (rows is 0)
                return Result.Failure(TaskError.NotUpdated);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    public Result Handle(UpdateTaskCompletionCommand command)
    {
        Result<DE.Task> task = Handle(new GetTaskByIdQuery(command.Id));

        if (task.IsFailure)
            return TaskError.NotFound;

        if (task.Data.Done)
            return TaskError.AlreadyCompleted;

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", command.Id);

        string sqlQuery = @"UPDATE Tasks SET done=1 WHERE id=@id AND done=0";

        try
        {
            int rows = _dbConnection.Execute(sqlQuery, parameters);
            if (rows is 0)
                return Result.Failure(TaskError.NotUpdated);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return ex;
        }
    }

    public Result Handle(DeleteTaskCommand command)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", command.Id);

        string sqlQuery = @"DELETE Tasks WHERE id=@id";

        try
        {
            int rows = _dbConnection.Execute(sqlQuery, parameters);
            if (rows is 0)
                return Result.Failure(TaskError.NotDeleted);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return ex;
        }
    }
}
