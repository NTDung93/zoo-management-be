using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models.Data;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using API.Models.Dtos;
using API.Repositories.Impl;

namespace API.Controllers
{
    public class AnimalSpeciesController : BaseApiController
    {
        private readonly IAnimalSpeciesRepository _speciesRepository;
        private readonly IAnimalsRepository _animalsRepository;
        private readonly IMapper _mapper;

        public AnimalSpeciesController(IAnimalSpeciesRepository speciesRepository, IAnimalsRepository animalsRepository, IMapper mapper)
        {
            _animalsRepository = animalsRepository;
            _speciesRepository = speciesRepository;
            _mapper = mapper;
        }

        [HttpGet("species")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalSpeciesResponse>>> GetSpecies()
        {
            var species = await _speciesRepository.GetAnimalSpecies();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mappedSpecies = _mapper.Map<IEnumerable<AnimalSpeciesResponse>>(species);
            return Ok(mappedSpecies);
        }

        [HttpGet("species/resource-id")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<AnimalSpeciesResponse>> GetASpecies(int id)
        {
            var species = await _speciesRepository.GetAnimalSpecies(id);
            if (species == null) return NotFound("Species not found!");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var mappedSpecies = _mapper.Map<AnimalSpeciesResponse>(species);
            return Ok(mappedSpecies);
        }

        [HttpPut("species/resource-id")]
        [ProducesResponseType(204)]
        //[Authorize(Roles = "Trainer")]
        public async Task<IActionResult> UpdateSpecies([FromBody] AnimalSpeciesResponse species)
        {
            if (species == null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Species is empty!"
                });

            if (string.IsNullOrEmpty(species.SpeciesName))
                return BadRequest(new ProblemDetails
                {
                    Title = "Species name is required!"
                });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _speciesRepository.UpdateAnimalSpecies(species))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while updating species!"
                });
            return NoContent();
        }

        [HttpPost("species")]
        [ProducesResponseType(201)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalSpeciesResponse>>> CreateSpecies(AnimalSpeciesRequest species)
        {
            if (species == null)
                return BadRequest(new ProblemDetails
                {
                    Title = "Species is empty!" 
                });

            if (string.IsNullOrEmpty(species.SpeciesName))
                return BadRequest(new ProblemDetails
                {
                    Title = "Species name is required!"
                });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var mappedSpecies = _mapper.Map<AnimalSpecies>(species);
            if (!await _speciesRepository.CreateAnimalSpecies(mappedSpecies))
                return BadRequest(new ProblemDetails
                {
                    Title = "An error occurs while creating!"
                });

            var listSpecies = await _speciesRepository.GetAnimalSpecies();
            return CreatedAtAction("GetSpecies", _mapper.Map<IEnumerable<AnimalSpeciesResponse>>(listSpecies));
        }

        [HttpDelete("species/resource-id")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteSpecies([FromQuery] int id)
        {
            var animalspecies = await _animalsRepository.GetAnimalBySpeciesId(id);
            if (animalspecies.Any())
            {
                return BadRequest(new ProblemDetails { Title = "There are animals in this species" });
            } else
            {
                await _speciesRepository.DeleteAnimalSpecies(id);
            }
            return NoContent();
        }
    }
}
