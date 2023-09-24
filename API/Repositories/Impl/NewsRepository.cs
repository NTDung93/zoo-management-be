using API.Models;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class NewsRepository : INewsRepository
    {
        private readonly ZooManagementContext _context;
        public NewsRepository(ZooManagementContext context)
        {
            _context = context;
        }

        public async Task CreateNews(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNews(int id)
        {
            var currentNews = GetNewsById(id);
            _context.News.Remove(currentNews.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<News>> GetNews()
        {
            return await _context.News.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<News> GetNewsById(int id)
        {
            return await _context.News.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<News>> SearchNewsByTitle(string title)
        {
            return await _context.News.Where(a => a.Title.ToLower().Contains(title.Trim().ToLower())).ToListAsync();
        }

        public async Task UpdateNews(int id, NewsDto newsDto)
        {
            var currentNews = GetNewsById(id);
            currentNews.Result.Title = newsDto.Title;
            currentNews.Result.Content = newsDto.Content;
            currentNews.Result.Image = newsDto.Image;
            currentNews.Result.WritingDate = newsDto.WritingDate;
            currentNews.Result.SpeciesId = newsDto.SpeciesId;
            currentNews.Result.AnimalId = newsDto.AnimalId;
            currentNews.Result.EmpId = newsDto.EmpId;
            await _context.SaveChangesAsync();
        }
    }
}
