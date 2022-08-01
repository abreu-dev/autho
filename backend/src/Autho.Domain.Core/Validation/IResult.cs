namespace Autho.Domain.Core.Validation
{
    public interface IResult
    {
        ResultType Type { get; set; }
        ICollection<IResultError> Errors { get; set; }
    }

    public interface IResult<TItem> : IResult
    {
        TItem? Item { get; set; }
    }

    public interface IResultError
    {
        string Type { get; set; }
        string Error { get; set; }
        string Detail { get; set; }
    }
}
