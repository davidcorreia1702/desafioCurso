namespace api.Shared
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string Error { get; private set; }

        private Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, null);
        public static Result Failure(string error) => new Result(false, error);
    }
}
