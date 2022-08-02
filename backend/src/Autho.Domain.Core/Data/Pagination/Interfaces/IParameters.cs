namespace Autho.Domain.Core.Data.Pagination.Interfaces
{
    public interface IParameters
    {
        int Page { get; set; }
        int Size { get; set; }
        string? Order { get; set; }
    }
}
