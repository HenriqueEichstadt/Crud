using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Models
{
    public class PagedDeveloper
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IList<Developer> Result { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
    }
}
