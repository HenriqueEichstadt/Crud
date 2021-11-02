using Crud.Api.Extensions;
using Crud.Api.Models;
using Crud.DataAccess.Common;
using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class DevelopersController : ControllerBase
    {
        private readonly IRepository<Developer> _repository;

        public DevelopersController(IRepository<Developer> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os desenvolvedores
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var list = _repository.All.ToList();

            return Ok(list); //Status code 200
        }

        /// <summary>
        /// Retorna os desenvolvedores de acordo com o termo passado via querystring e paginação
        /// </summary>
        // Necessário alterar nome da rota pois .NET não permite múltiplos EndPoints
        [HttpGet("filter")]
        public IActionResult GetByFilterAndPagination([FromQuery] DeveloperFilter filter, [FromQuery] Pagination pagination)
        {
            var pagedDeveloperList = _repository.All
                .AplicaFiltro(filter)
                .ToPagedDeveloper(pagination);


            if (!pagedDeveloperList.Result.Any())
            {
                return NotFound(); // Status code 404
            }

            return Ok(pagedDeveloperList); //Status code 200
        }

        /// <summary>
        /// Retorna os dados de um desenvolvedor
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var model = _repository.Find(id);

            if (model == null)
            {
                return NotFound(); // Status code 404
            }

            return Ok(model); //Status code 200
        }

        /// <summary>
        /// Adiciona um novo desenvolvedor
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] Developer developer)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(developer);
                var uri = Url.Action("GetById", new { id = developer.Id });
                return Created(uri, developer); //Status code 201
            }
            return BadRequest(); //Status code 400
        }

        /// <summary>
        /// Atualiza os dados de um desenvolvedor
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Developer developer)
        {
            if (ModelState.IsValid && developer.Id == id)
            {
                _repository.Update(developer);
                return Ok(); //Status code 200
            }
            return BadRequest(); //Status code 400
        }

        /// <summary>
        /// Apaga o registro de um desenvolvedor
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var model = _repository.Find(id);

            if (model == null)
                return NotFound(); // Status code 404

            _repository.Delete(model);
            return NoContent(); // Status code 204
        }
    }
}
