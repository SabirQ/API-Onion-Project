using APIOnion.Application.DTOs.Categories;
using APIOnion.Application.Interfaces.Repositories;
using APIOnion.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIOnion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest(new
            {
                code = "id",
                description = "you can bot set id to 0"
            });
            Category category = await _repository.GetById(id);
            if (category == null) return NotFound();
            CategoryItemDto dto = _mapper.Map<CategoryItemDto>(category);
            return Ok(dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Category> categories = await _repository.GetAllAsync(null);
            List<CategoryItemDto> dtos = _mapper.Map<List<CategoryItemDto>>(categories);
            return Ok(dtos);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryPostDto dto)
        {
            Category category = _mapper.Map<Category>(dto);
            category.CreatedAt = DateTime.Now;
            category.ModifiedAt = DateTime.Now;
            await _repository.AddAsync(category);
            return StatusCode(StatusCodes.Status201Created, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryPostDto dto)
        {
            if (id == 0) return BadRequest(new
            {
                code = "id",
                description = "you can bot set id to 0"
            });
            Category category = await _repository.GetById(id);
            if (category == null) return NotFound();
            _repository.Update(category);
            category.Name = dto.Name;
            category.ModifiedAt = DateTime.Now;
            await _repository.SaveAsync();
            return Ok(dto);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest(new
            {
                code = "id",
                description = "you can bot set id to 0"
            });
            Category category = await _repository.GetById(id);
            if (category == null) return NotFound();
            await _repository.DeleteAsync(category);
            return NoContent();
        }
    }
}
