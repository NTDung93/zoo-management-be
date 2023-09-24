using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using API.Models.Dtos;

namespace API.Controllers
{
    
    public class AnimalSpeciesController : BaseApiController
    {
        private readonly IAnimalSpeciesRepository _speciesRepository;
        private readonly IMapper _mapper;

        public AnimalSpeciesController(IAnimalSpeciesRepository speciesRepository, IMapper mapper)
        {
            _speciesRepository = speciesRepository;
            _mapper = mapper;
        }
        
        [HttpGet("animal-species")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalSpeciesDto>>> GetAnimalSpecies()
        {
            var species = await _speciesRepository.GetSpecies();
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var speciesDto = _mapper.Map<IEnumerable<AnimalSpeciesDto>>(species);
            return Ok(speciesDto);
        }

        [HttpGet("animal-species/{id}")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult<AnimalSpeciesDto>> GetAnimalSpecies(int id)
        {
            if (!await _speciesRepository.HasSpecies(id))
                return NotFound("Species not found!");
            var species = await _speciesRepository.GetSpeciesById(id);
            if (!ModelState.IsValid) 
                return BadRequest();
            var speciesDto = _mapper.Map<AnimalSpeciesDto>(species);
            return Ok(speciesDto);
        }

        [HttpGet("animal-species/cages/{cageId}")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<AnimalSpeciesDto>>> SearchSpeciesByCageId(string cageId)
        {
            if (string.IsNullOrWhiteSpace(cageId))
                return BadRequest("Must provide the cageId!");
            var species = await _speciesRepository.GetSpeciesByCageId(cageId);
            if (!species.Any())
                return NotFound("Species not found!");
            if (!ModelState.IsValid)
                return BadRequest();
            var speciesDto = _mapper.Map<IEnumerable<AnimalSpeciesDto>>(species);
            return Ok(speciesDto);
        }

        // PUT: api/AnimalSpecies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnimalSpecy(int id, AnimalSpecy animalSpecy)
        //{
        //    if (id != animalSpecy.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(animalSpecy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnimalSpecyExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/AnimalSpecies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("animal-species")]
        [ProducesResponseType(201)]
        [Authorize(Roles = "Trainer")]
        public async Task<ActionResult<AnimalSpecy>> CreateAnimalSpecies(AnimalSpeciesDto speciesDto)
        {
            if (speciesDto == null)
                return ValidationProblem("Species is nullable!");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var species = _mapper.Map<AnimalSpecy>(speciesDto);
            if (!await _speciesRepository.CreateAnimalSpecies(species))
                return UnprocessableEntity("An error occurs while creating!");
            return CreatedAtAction("GetAnimalSpecies", new { id = species.Id }, species);
        }

        [HttpDelete("animal-species/{id}")]
        [ProducesResponseType(200)]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteAnimalSpecies(int id)
        {
            if (!await _speciesRepository.HasSpecies(id))
                return NotFound("Species not found!");
            if (!ModelState.IsValid)
                return BadRequest();
            if (!await _speciesRepository.DeleteAnimalSpecies(id))
                return UnprocessableEntity("An error occurs while deleting!");
            return NoContent();
        }

    }
}
