using Microsoft.EntityFrameworkCore;

namespace WebApiTemplate.Helpers
{
    public static class HttpContextExtensions
    {

        public async static Task InsertPararmetersPagination<T>(this HttpContext httpContext, IQueryable<T> queryable, int registerByPage)
        {
            double quantity = await queryable.CountAsync();
            double quantityPages = Math.Ceiling(quantity / registerByPage);
            httpContext.Response.Headers.Add("quantityPage", quantityPages.ToString());
        }

    }

}
