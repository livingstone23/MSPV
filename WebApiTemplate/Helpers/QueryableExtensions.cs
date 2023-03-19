using WebApiTemplate.DTOs;

namespace WebApiTemplate.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginationDTO paginationDto)
        {
            return queryable
                .Skip((paginationDto.Page -1) * paginationDto.RegisterByPage)
                .Take(paginationDto.RegisterByPage);
        }
    }
}
