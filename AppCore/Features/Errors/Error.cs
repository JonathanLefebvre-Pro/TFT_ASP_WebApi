namespace AppCore.Features.Errors;

public record Error(string Code, string Message)
{
    internal static Error None => new Error("Error.None", "No message !");
    internal static Error Exception => new Error("Error.Exception", "An exception occured !");
    internal static Error Null => new Error("Error.Null", "Null value returned !");
}
