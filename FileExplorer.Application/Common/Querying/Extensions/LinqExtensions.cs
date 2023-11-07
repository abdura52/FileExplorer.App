using FileExplorer.Application.Common.Models.Filtering;

namespace FileExplorer.Application.Common.Querying.Extensions;

public static class LinqExtensions
{
    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> source, FilterPagination paginationOptions)
        => source.Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize).Take(paginationOptions.PageSize);

    public static IEnumerable<T> ApplyPagination<T>(this IEnumerable<T> source, FilterPagination paginationOptions)
           => source.Skip((paginationOptions.PageToken - 1) * paginationOptions.PageSize).Take(paginationOptions.PageSize);
}
