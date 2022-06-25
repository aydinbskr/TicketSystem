namespace TicketSystem.Core.Utilities.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(bool success, T data, string message) : this(success)
        {
            Data = data;
            Message = message;
        }
        public DataResult(bool success)
        {
            Success = success;
        }
        public DataResult(bool success, T data) : this(success)
        {
            Data = data;
        }
        public T Data { get; }

        public string? Message { get; }

        public bool Success { get; }
    }
}
