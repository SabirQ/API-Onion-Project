using APIOnion.Application.Interfaces.Repositories;
using APIOnion.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIOnion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest(new
            {
                code = "id",
                description = "you can bot set id to 0"
            });
           Category category=await _repository.GetById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }
    }
}
