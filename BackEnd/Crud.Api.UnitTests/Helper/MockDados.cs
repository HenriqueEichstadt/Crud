using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Api.UnitTests.Helper
{
    internal class MockDados
    {
        public IQueryable<Developer> GetListDevelopersFake()
        {
            var result = new List<Developer>()
            {
                new Developer(1, "João", 'M', 30, "Passear no parque", new DateTime(1991, 12, 05)),
                new Developer(2, "Maria", 'F', 26, "Cinema", new DateTime(1991, 12, 05)),
                new Developer(3, "Aline", 'F', 34, "Estudar", new DateTime(1991, 12, 05)),
                new Developer(4,"Henrique", 'M', 59, "Ler livros", new DateTime(1991, 12, 05)),
                new Developer(5,"Cristofer", 'M', 64, "Assistir filmes", new DateTime(1991, 12, 05)),
                new Developer(6,"Daniel", 'M', 76, "Netflix", new DateTime(1991, 12, 05)),
                new Developer(7,"Alex", 'M', 23, "Gastronomia", new DateTime(1991, 12, 05)),
                new Developer(8,"Felipe", 'M', 64, "Teatro", new DateTime(1991, 12, 05)),
                new Developer(9,"Lucas", 'M', 64, "Cinema", new DateTime(1991, 12, 05)),
                new Developer(10,"Bianca", 'F', 12, "Jogos", new DateTime(1991, 12, 05))
            };

            return result.AsQueryable();
        }

        public Developer GetValidDeveloper() 
        {
            return GetListDevelopersFake().First();
        }

        public Developer GetInvalidDeveloper()
        {
            return new Developer() 
            {
                Id = 0,
                Sexo = 'M',
                Hobby = "Ler",
                DataNascimento = new DateTime(1990, 01, 01),
                Idade = 31
            };
        }
    }
}
