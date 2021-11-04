using Crud.Api.Controllers;
using Crud.Api.Models;
using Crud.Api.UnitTests.Helper;
using Crud.DataAccess.Common;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Crud.Api.UnitTests.Controllers
{
    [TestFixture]
    class DevelopersControllerTests
    {
        private DevelopersController _target;
        private MockDados _mockDados;

        public DevelopersControllerTests()
        {
            _mockDados = new MockDados();
        }

        [SetUp]
        public void SetUp()
        {
            var repository = Substitute.For<IRepository<Developer>>();
            var listDevelopersFake = _mockDados.GetListDevelopersFake();

            repository.All.Returns(listDevelopersFake);
            repository.Find(10).Returns(listDevelopersFake.First(p => p.Id == 10));

            _target = new DevelopersController(repository);
            _target.Url = Substitute.For<IUrlHelper>();
            _target.Url.Action(default).ReturnsForAnyArgs("");
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void Get_ComDadosValidos_DeveRetornarStatusCode200()
        {
            var result = _target.Get();

            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public void Get_ComDadosValidos_DeveRetornarRegistros()
        {
            var result = _target.Get() as OkObjectResult;
            var developers = result.Value as IList<Developer>;
            int expectedDevelopers = 10;

            Assert.AreEqual(expectedDevelopers, developers.Count);
        }

        [Test]
        public void GetById_ComRegistroValido_DeveRetornarStatusCode200()
        {
            var result = _target.GetById(10);

            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public void GetById_ComRegistroInvalido_DeveRetornarStatusCode404()
        {
            var result = _target.GetById(999);

            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }

        [Test]
        public void GetById_ComRegistroValido_DeveRetornarRegistro()
        {
            var result = _target.GetById(10) as OkObjectResult;
            var developer = result.Value as Developer;
            var expectedId = 10;

            Assert.Pass("Retornou apenas um desenvolvedor");
            Assert.AreEqual(expectedId, developer.Id);
        }

        [Test]
        public void Post_ComDesenvolvedorValido_DeveRetornarStatusCode201()
        {
            var validDeveloper = _mockDados.GetValidDeveloper();
            var result = _target.Post(validDeveloper);

            Assert.IsInstanceOf(typeof(CreatedResult), result);
        }

        [Test]
        public void Post_ComDesenvolvedorInvalido_DeveRetornarStatusCode400()
        {
            var invalidDeveloper = _mockDados.GetInvalidDeveloper();
            _target.ModelState.AddModelError("Nome", "Nome is required");
            var result = _target.Post(invalidDeveloper);

            Assert.IsInstanceOf(typeof(BadRequestResult), result);
        }

        [Test]
        public void Put_ComDesenvolvedorValido_DeveRetornarStatusCode200()
        {
            var validDeveloper = _mockDados.GetValidDeveloper();
            var result = _target.Put(1, validDeveloper);

            Assert.IsInstanceOf(typeof(OkResult), result);
        }

        [Test]
        public void Put_ComDesenvolvedorInvalido_DeveRetornarStatusCode400()
        {
            var invalidDeveloper = _mockDados.GetInvalidDeveloper();
            invalidDeveloper.Id = 1;
            _target.ModelState.AddModelError("Nome", "Nome is required");
            var result = _target.Put(1, invalidDeveloper);

            Assert.IsInstanceOf(typeof(BadRequestResult), result);
        }

        [Test]
        public void Delete_ComDesenvolvedorValido_DeveRetornarStatusCode204()
        {
            var result = _target.Delete(10);

            Assert.IsInstanceOf(typeof(NoContentResult), result);
        }

        [Test]
        public void Delete_ComDesenvolvedorInvalido_DeveRetornarStatusCode404()
        {
            var result = _target.Delete(999);

            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }

        [Test]
        public void GetByFilterAndPagination_ComFiltroValido_DeveRetornarRegistro()
        {
            var filter = new DeveloperFilter()
            {
                Nome = "Alex"
            };

            var result = _target.GetByFilterAndPagination(filter, new Pagination()) as OkObjectResult;
            var developer = result.Value as PagedDeveloper;
            var expectedId = 7;

            Assert.AreEqual(expectedId, developer.Result.First().Id);
        }

        [Test]
        public void GetByFilterAndPagination_ComFiltroEPaginacaoValida_DeveRetornarRegistro()
        {
            var filter = new DeveloperFilter()
            {
                Nome = "Alex"
            };

            var pagination = new Pagination()
            {
                Page = 1,
                Size = 1
            };

            var result = _target.GetByFilterAndPagination(filter, pagination) as OkObjectResult;
            var developer = result.Value as PagedDeveloper;
            var expectedId = 7;

            Assert.AreEqual(expectedId, developer.Result.First().Id);
        }

        [Test]
        public void GetByFilterAndPagination_ComFiltroInvalido_DeveRetornarStatusCode404()
        {
            var filter = new DeveloperFilter()
            {
                Nome = "ZZZ"
            };

            var result = _target.GetByFilterAndPagination(filter, new Pagination());

            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }

        [Test]
        public void GetByFilterAndPagination_ComFiltroValido_DeveRetornarStatusCode200()
        {
            var filter = new DeveloperFilter()
            {
                Nome = "Alex"
            };

            var result = _target.GetByFilterAndPagination(filter, new Pagination());

            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }
    }
}
