using Crud.Api.Models;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Extensions
{
    public static class PagedDeveloperExtensions
    {
        public static PagedDeveloper ToPagedDeveloper(this IQueryable<Developer> query, Pagination pagination)
        {
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pagination.Size);
            bool HasPreviousPage = (pagination.Page> 1);
            bool hasNextPage = (pagination.Page < totalPages);

            return new PagedDeveloper()
            {
                Total = totalItems,
                TotalPages = totalPages,
                PageNumber = pagination.Page,
                PageSize = pagination.Size,
                Result = query
                    .Skip(pagination.Size * (pagination.Page - 1))
                    .Take(pagination.Size).ToList(),
                Previous = HasPreviousPage 
                ? $"developers?page={pagination.Page - 1}&size={pagination.Size}" 
                : "",
                Next = hasNextPage 
                ? $"developers?page={pagination.Page + 1}&size={pagination.Size}" 
                : "",
            };
        }
    }
}
