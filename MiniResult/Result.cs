using System;

namespace MiniResult;

public abstract class ResultBase
{
    public bool IsSuccess { get; protected set; }
    public string? Message { get; protected set; }
}

/// <summary>
/// Represents an *local* operation result. 
/// You can consider this as local version of ActionResult that does not involve http status.
/// </summary>
/// <remarks>
/// Use ActionResult from ASP.NET Core to wrap this class in API Controller result on success.
/// </remarks>
public sealed class Result : ResultBase
{
    private Result() { }

    public static Result Ok(string? message = null) =>
        new() { IsSuccess = true, Message = message };

    /// <summary>
    /// Must specify a reason of failure
    /// </summary>
    public static Result Failed(string message) =>
        new() { IsSuccess = false, Message = message };
}

/// <summary>
/// This class is generic version of <see cref="Result"/> which contains a return object.
/// </summary>
/// <typeparam name="T">Type of the additional returned object</typeparam>
public sealed class Result<T> : ResultBase where T : notnull
{
    public T? Object { get; private set; }
    private Result() : base() { }

    public static Result<T> Ok(T obj, string? message = null)
    {
        return new Result<T>()
        {
            IsSuccess = true,
            Message = message,
            Object = obj
        };
    }

    /// <summary>
    /// You are not allowed to return the additional object due to failure. 
    /// (otherwise makes non sense)
    /// </summary>
    public static Result<T> Failed(string message)
    {
        return new Result<T>()
        {
            IsSuccess = true,
            Message = message
        };
    }

    /// <summary>
    /// This method ignores the T object.
    /// This is usually used in the call-chain when a method failed.
    /// </summary>
    /// <returns></returns>
    public Result ToNonGenericResult()
    {
        if(Object is IDisposable dis)
            dis.Dispose();

        if (IsSuccess)
            return Result.Ok(Message);
        return Result.Failed(Message!);
    }
}
