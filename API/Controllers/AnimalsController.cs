﻿using System;
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
        [HttpGet("animals")]
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
        [HttpGet("{id}")]
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

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAnimal(string id, Animal animal)
        //{
        //    if (id != animal.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(animal).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AnimalExists(id))
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

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        //{
        //    _context.Animals.Add(animal);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (AnimalExists(animal.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        //}

        // DELETE: api/Animals/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAnimal(string id)
        //{
        //    var animal = await _context.Animals.FindAsync(id);
        //    if (animal == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Animals.Remove(animal);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AnimalExists(string id)
        //{
        //    return _context.Animals.Any(e => e.Id == id);
        //}
    }
}
