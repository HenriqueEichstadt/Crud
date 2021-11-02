using Crud.Api.Models;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Extensions
{
    public static class DeveloperFiltroExtensions
    {
        public static IQueryable<Developer> AplicaFiltro(this IQueryable<Developer> query, DeveloperFilter filtro)
        {
            if(filtro != null)
            {
                if (filtro.Id.HasValue && filtro.Id > 0)
                {
                    query = query.Where(p => p.Id == filtro.Id);
                }
                if (!string.IsNullOrEmpty(filtro.Nome))
                {
                    query = query.Where(p => p.Nome.Contains(filtro.Nome));
                }
                if (filtro.Sexo.HasValue)
                {
                    query = query.Where(p => p.Sexo == filtro.Sexo);
                }
                if (filtro.Idade.HasValue && filtro.Idade > 0)
                {
                    query = query.Where(p => p.Idade == filtro.Idade);
                }
                if (!string.IsNullOrEmpty(filtro.Hobby))
                {
                    query = query.Where(p => p.Hobby.Contains(filtro.Hobby));
                }
                if (filtro.DataNascimento.HasValue)
                {
                    query = query.Where(p => p.DataNascimento.Year == filtro.DataNascimento.Value.Year 
                    && p.DataNascimento.Month == filtro.DataNascimento.Value.Month
                    && p.DataNascimento.Day == filtro.DataNascimento.Value.Day);
                }
            }
            return query;
        }
    }
}
