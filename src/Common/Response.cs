namespace Common;

public class Response<T>
{
    private Response(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }
        IsSuccess = isSuccess;
        Error = error;
    }

    public T? Data { get; set; }
    public Error Error { get; set; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public static Response<T> Success(T data) => new(true, Error.None) { Data = data };
    public static Response<T> Failure(Error error) => new(false, error);

}