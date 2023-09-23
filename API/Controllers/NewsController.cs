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
using API.Models.Dtos;
using NuGet.ContentModel;

namespace API.Controllers
{
    public class NewsController : BaseApiController
    {
        private readonly INewsRepository _newsRepo;
        private readonly IMapper _mapper;
        private readonly BuggyController _buggy;

        public NewsController(INewsRepository newsRepo, IMapper mapper, BuggyController buggy)
        {
            _newsRepo = newsRepo;
            _mapper = mapper;
            _buggy = buggy;
        }

        // POST: api/News
        [HttpPost("post-news")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<NewsDto>> PostNews([FromBody]NewsDto newsDto)
        {
            var news = _mapper.Map<News>(newsDto);
            await _newsRepo.CreateNews(news);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtRoute("GetNews", new { id = news.Id }, news);
            //return Ok(_mapper.Map<NewsDto>(news));
        }

        // GET: api/News
        [HttpGet("load-news")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews()
        {
            var news = await _newsRepo.GetNews();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newsDto = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDto);
        }

        //enpoint to search news by title
        [HttpGet("search")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<NewsDto>>> SearchNewsByTitle([FromQuery] string title)
        {
            var news = await _newsRepo.SearchNewsByTitle(title);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newsDto = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDto);
        }

        // DELETE: api/News/5
        [HttpDelete("delete")]
        [ProducesResponseType(200)]
        public async Task DeleteNews([FromQuery]int id)
        {
            await _newsRepo.DeleteNews(id);
            if (!ModelState.IsValid)
                BadRequest(ModelState);
        }



        //// GET: api/News/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<News>> GetNews(int id)
        //{
        //    var news = await _context.News.FindAsync(id);

        //    if (news == null)
        //    {
        //        return NotFound();
        //    }

        //    return news;
        //}

        //// PUT: api/News/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutNews(int id, News news)
        //{
        //    if (id != news.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(news).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!NewsExists(id))
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





        //private bool NewsExists(int id)
        //{
        //    return _context.News.Any(e => e.Id == id);
        //}
    }
}
