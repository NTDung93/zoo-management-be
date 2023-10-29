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

        public NewsController(INewsRepository newsRepo, IMapper mapper)
        {
            _newsRepo = newsRepo;
            _mapper = mapper;
        }

        [HttpPost("post-news")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<NewsDto>> PostNews([FromBody] NewsDto newsDto)
        {
            var news = _mapper.Map<News>(newsDto);
            await _newsRepo.CreateNews(news);
            var listNews = await _newsRepo.GetNews();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtRoute("GetNews", _mapper.Map<IEnumerable<NewsDto>>(listNews));
        }

        [HttpGet("load-news", Name = "GetNews")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews()
        {
            var news = await _newsRepo.GetNews();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!news.Any())
            {
                return NotFound();
            }
            var newsDto = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDto);
        }

        [HttpGet("search")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<NewsDto>>> SearchNewsByTitle([FromQuery] string title)
        {
            var news = await _newsRepo.SearchNewsByTitle(title);
            if (!news.Any())
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newsDto = _mapper.Map<IEnumerable<NewsDto>>(news);
            return Ok(newsDto);
        }

        [HttpGet("get-news")]
        public async Task<ActionResult<NewsDto>> GetNews([FromQuery] int id)
        {
            var news = await _newsRepo.GetNewsById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (news == null)
            {
                return NotFound();
            }
            else
            {
                var newsDto = _mapper.Map<NewsDto>(news);
                return Ok(newsDto);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> PutNews([FromQuery] int id, [FromBody] NewsDto newsDto)
        {
            if (id != newsDto.NewsId || newsDto == null)
            {
                return BadRequest("Invalid news data or mismatched IDs.");
            }

            var currentNews = await _newsRepo.GetNewsById(id);

            if (currentNews == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    await _newsRepo.UpdateNews(id, newsDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return Ok("Update news successfully.");
        }

        [HttpDelete("delete")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteNews([FromQuery] int id)
        {
            var news = await _newsRepo.GetNewsById(id);
            if (news == null)
            {
                return BadRequest(new ProblemDetails { Title = "News not found!"});
            }
            await _newsRepo.DeleteNews(id);
            var listNews = await _newsRepo.GetNews();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtRoute("GetNews", _mapper.Map<IEnumerable<NewsDto>>(listNews));
        }
    }
}
