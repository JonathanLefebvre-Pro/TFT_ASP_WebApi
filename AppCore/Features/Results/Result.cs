using AppCore.Features.Errors;

namespace AppCore.Features.Results;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static implicit operator Result(Error error)
    {
        return Failure(error);
    }

    public static implicit operator Result(Exception exception)
    {
        return Failure(Error.Exception);
    }

    public static Result Success()
    {
        return new Result(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        if (string.IsNullOrWhiteSpace(error.Code))
            throw new ArgumentException("Code cannot be null or empty !");

        if (string.IsNullOrWhiteSpace(error.Message))
            throw new ArgumentException("Message cannot be null or empty !");

        return new Result(false, error);
    }

    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
}

public class Result<TResult>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public TResult Data { get; }

    public static implicit operator Result<TResult>(Error error)
    {
        return Failure(error);
    }

    public static implicit operator Result<TResult>(Exception exception)
    {
        return Failure(Error.Exception);
    }

    public static implicit operator Result<TResult>(TResult data)
    {
        return Success(data);
    }

    public static Result<TResult> Success(TResult data)
    {
        if (data is null)
            return new Result<TResult>(false, Error.Null);

        return new Result<TResult>(true, Error.None, data);
    }

    public static Result<TResult> Failure(Error error)
    {
        if (string.IsNullOrWhiteSpace(error.Code))
            throw new ArgumentException("Code cannot be null or empty !");

        if (string.IsNullOrWhiteSpace(error.Message))
            throw new ArgumentException("Message cannot be null or empty !");

        return new Result<TResult>(false, error);
    }

    private Result(bool isSuccess, Error error, TResult data = default!)
    {
        IsSuccess = isSuccess;
        Error = error;
        Data = data;
    }
}
