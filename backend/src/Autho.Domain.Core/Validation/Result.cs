namespace Autho.Domain.Core.Validation
{
    public class Result : IResult
    {
        public ResultType Type { get; set; }
        public ICollection<IResultError> Errors { get; set; }

        public Result(ResultType type, IResultError error)
        {
            Type = type;
            Errors = new List<IResultError>
            {
                error
            };
        }

        public Result(ResultType type)
        {
            Type = type;
            Errors = new List<IResultError>();
        }
    }

    public class Result<TItem> : Result, IResult<TItem>
    {
        public TItem? Item { get; set; }

        public Result(TItem item, ResultType type) : base(type)
        {
            Item = item;
        }

        public Result(TItem item, ResultType type, IResultError error) : base(type, error)
        {
            Item = item;
        }

        public Result(ResultType type, IResultError error) : base(type, error)
        {
        }
    }

    public class ResultError : IResultError
    {
        public string Type { get; set; }
        public string Error { get; set; }
        public string Detail { get; set; }

        public ResultError(string type, string error, string detail)
        {
            Type = type;
            Error = error;
            Detail = detail;
        }
    }
}
