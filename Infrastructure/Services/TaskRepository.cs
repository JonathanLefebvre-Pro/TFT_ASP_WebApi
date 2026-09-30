using System.Data.Common;
using AppCore.Features.Commands;
using AppCore.Features.Queries;
using AppCore.Interfaces.Repositories;
using Dapper;
using DE = Domain.Entities;

namespace Infrastructure.Services;

public class TaskRepository : ITaskRepository
{
    private readonly DbConnection _dbConnection;

    public TaskRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        _dbConnection.Open();
    }

    public IEnumerable<DE.Task> Handle(GetAllTasksQuery query)
    {
        IEnumerable<DE.Task> tasks = Enumerable.Empty<DE.Task>();

        string sqlQuery = @"SELECT id, title, creationDate, done FROM Tasks";

        tasks = _dbConnection.Query<DE.Task>(sqlQuery);

        return tasks;
    }

    public DE.Task Handle(GetTaskByIdQuery query)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", query.Id);

        string sqlQuery = @"SELECT * FROM Tasks WHERE id=@id";

        return _dbConnection.QuerySingle<DE.Task>(sqlQuery, parameters)!;
    }

    public bool Handle(AddTaskCommand command)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@title", command.Title);

        string sqlQuery = @"INSERT INTO Tasks (title) VALUES (@title)";

        return 1 == _dbConnection.Execute(sqlQuery, parameters);
    }

    public bool Handle(UpdateTaskCommand command)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", command.Id);
        parameters.Add("@title", command.Title);

        string sqlQuery = @"UPDATE Tasks SET title=@title WHERE id=@id";

        return 1 == _dbConnection.Execute(sqlQuery, parameters);
    }

    public bool Handle(UpdateTaskCompletionCommand command)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", command.Id);

        string sqlQuery = @"UPDATE Tasks SET done=1 WHERE id=@id AND done=0";

        return 1 == _dbConnection.Execute(sqlQuery, parameters);
    }

    public bool Handle(DeleteTaskCommand command)
    {
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", command.Id);

        string sqlQuery = @"DELETE Tasks WHERE id=@id";

        return 1 == _dbConnection.Execute(sqlQuery, parameters);
    }
}
