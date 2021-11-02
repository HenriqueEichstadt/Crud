using Crud.DataAccess.Common;
using Crud.DataAccess.Contexts;
using Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.IoC
{
    public class DependencyInjection
    {
        private IServiceCollection _services;

        public DependencyInjection(IServiceCollection services)
        {
            _services = services;
        }

        public void RegisterServices()
        {
            _services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            RegisterRepositories();
        }

        private void RegisterRepositories()
        {
            _services.AddTransient<IRepository<Developer>, RepositorioBase<Developer>>();
        }
    }
}
