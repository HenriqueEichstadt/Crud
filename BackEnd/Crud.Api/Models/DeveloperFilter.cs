using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Models
{
    public class DeveloperFilter
    {
        public long? Id { get; set; }
        public string Nome { get; set; }
        public char? Sexo { get; set; }
        public int? Idade { get; set; }
        public string Hobby { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}
