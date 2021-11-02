﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Models
{
    public class Pagination
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
