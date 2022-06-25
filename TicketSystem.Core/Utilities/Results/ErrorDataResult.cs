namespace TicketSystem.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult() : base(false, default(T))
        {
        }
        public ErrorDataResult(string messages) : base(false, default(T), default(string))
        {
        }
    }
}
