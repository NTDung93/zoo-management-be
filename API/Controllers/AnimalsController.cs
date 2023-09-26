using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using AutoMapper;
using API.Repositories;
using API.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using API.Models.Entities;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    public class AnimalsController : BaseApiController
    {
        private readonly IAnimalsRepository _animalRepo;
        private readonly IMapper _mapper;
        //private readonly BuggyController _buggy;

        public AnimalsController(IAnimalsRepository animalRepo, IMapper mapper)
        {
            _animalRepo = animalRepo;
            _mapper = mapper;
        }

        // GET: api/Animals
        [HttpGet("animals", Name = "GetAnimals")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAnimals()
        {
            var animals = await _animalRepo.GetAnimals();
            if (!ModelState.IsValid)
                return BadRequest();
            var animaslDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
            return Ok(animaslDto);
        }

        // GET: api/Animals/5
        [HttpGet("animal")]
        public async Task<ActionResult<AnimalDto>> GetAnimal(string id)
        {
            var animal = await _animalRepo.GetAnimalById(id);

            if (animal == null)
            {
                return NotFound();
            }
            var animalDto = _mapper.Map<AnimalDto>(animal);
            return animalDto;
        }

        [HttpGet("search-animals")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> SearchAnimalsByName([FromQuery] string animalName)
        {
            if (animalName.Trim().Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else
            {
                var animals = await _animalRepo.SearchAnimalsByName(animalName.Trim());
                if (!animals.Any())
                {
                    return NotFound();
                }
                else
                {
                    var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
                    return Ok(animalsDto);
                }
            }
        }

        [HttpDelete("delete-animal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AnimalDto>> DeleteAnimal([FromQuery] string animalId)
        {
            var currAnimal = await _animalRepo.GetAnimalById(animalId);
            if (currAnimal != null)
            {
                await _animalRepo.DeleteAnimal(animalId);
                var animals = await _animalRepo.GetAnimals();
                var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
                if (!ModelState.IsValid)
                    BadRequest(ModelState);
                return CreatedAtRoute("GetAnimals", animalsDto);
            }
            return NotFound();
        }

        [HttpPost("create-animal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AnimalDto>> CreateNewAnimals([FromBody] AnimalDto animalDto)
        {
            var animals = await _animalRepo.GetAnimals();
            var id = animals.OrderByDescending(a => a.Id).First();
            if (animalDto.Name.Trim().Length == 0 || animalDto.Region.Trim().Length == 0 || animalDto.Behavior.Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else
            {
                var animal = new Animal 
                { 
                    Id = (int.Parse(id.Id) + 1).ToString(),
                    Name = animalDto.Name,
                    Region = animalDto.Region,
                    Behavior = animalDto.Behavior,
                    Gender = animalDto.Gender,
                    BirthDate = animalDto.BirthDate,
                    Image = animalDto.Image,
                    HealthStatus = animalDto.HealthStatus,
                    Rarity = animalDto.Rarity,
                    IsDeleted = animalDto.IsDeleted,
                    EmpId = animalDto.EmpId,
                    CageId = animalDto.CageId,
                };
                await _animalRepo.CreateNewAnimal(animal);
                animals = await _animalRepo.GetAnimals();
                var animalsDto = _mapper.Map<IEnumerable<AnimalDto>>(animals);
                return CreatedAtRoute("GetAnimals", animalsDto);
            }
        }

        [HttpPut("update-animal")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateAnimal([FromQuery] string animalId, [FromBody] AnimalDto animalDto)
        {
            var areas = await _animalRepo.GetAnimals();
            var currAnimal = await _animalRepo.GetAnimalById(animalId);
            if (animalDto.Name.Trim().Length == 0 || animalDto.Region.Trim().Length == 0 || animalDto.Behavior.Length == 0)
            {
                return BadRequest(new ProblemDetails { Title = "Do not allow Empty!" });
            }
            else if (currAnimal != null)
            {
                await _animalRepo.UpdateAnimal(animalId, animalDto);
                return Ok("Update Animal Success!");
            }
            return NotFound();
        }
    }
}
