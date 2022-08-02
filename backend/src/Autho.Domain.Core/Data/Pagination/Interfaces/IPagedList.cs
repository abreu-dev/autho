namespace Autho.Domain.Core.Data.Pagination.Interfaces
{
    public interface IPagedList<T>
    {
        IEnumerable<T> Data { get; set; }
        int CurrentPage { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; set; }
    }
}
