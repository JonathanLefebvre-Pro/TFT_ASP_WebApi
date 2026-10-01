namespace AppCore.Features.Errors;

public static class TaskError
{
    public static Error NotFound => new Error("TaskError.NotFound", "No task found !");
    public static Error NotInserted =>
        new Error("TaskError.NotInserted", "Task was not inserted !");
    public static Error NotUpdated => new Error("TaskError.NotUpdated", "Task was not updated !");
    public static Error NotDeleted => new Error("TaskError.NotDeleted", "Task was not deleted !");
    public static Error AlreadyCompleted =>
        new Error("TaskError.AlreadyCompleted", "Task was already completed !");
}
