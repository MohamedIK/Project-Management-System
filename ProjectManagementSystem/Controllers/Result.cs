namespace ProjectManagementSystem.Controllers
{
    public sealed class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Value { get; set; }
        public string Error { get; set; } = string.Empty;

        public static Result<T> Success(T value)
        {
            return new Result<T> { IsSuccess = true, Value = value };
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T> { IsSuccess = false, Error = error };
        }
    }
}