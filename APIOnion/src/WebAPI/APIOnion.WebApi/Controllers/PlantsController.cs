using APIOnion.Application.DTOs.Plants;
using APIOnion.Application.Interfaces.Repositories;
using APIOnion.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIOnion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {

        private readonly IPlantRepository _repository;
        private readonly IMapper _mapper;

        public PlantsController(IPlantRepository repository, IMapper mapper)
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
            Plant category = await _repository.GetById(id);
            if (category == null) return NotFound();
            PlantItemDto dto = _mapper.Map<PlantItemDto>(category);
            return Ok(dto);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Plant> plants = await _repository.GetAllAsync(null);
            List<PlantItemDto> dtos = _mapper.Map<List<PlantItemDto>>(plants);
            return Ok(dtos);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(PlantPostDto dto)
        //{
        //    Plant plant = _mapper.Map<Plant>(dto);
            
        //    await _repository.AddAsync(plant);
        //    return StatusCode(StatusCodes.Status201Created, dto);
        //}
       
    }
}
