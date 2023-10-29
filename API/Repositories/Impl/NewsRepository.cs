using API.Models;
using API.Models.Data;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class NewsRepository : INewsRepository
    {
        private readonly ZooManagementBackupContext _context;
        public NewsRepository(ZooManagementBackupContext context)
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
            return await _context.News.Include(x => x.Animal.Cage.Area).Include(t => t.Animal.AnimalSpecies).Include(y => y.Employee).Include(z => z.AnimalSpecies).OrderBy(a => a.NewsId).ToListAsync();
            //return await _context.News.Include(y => y.Employee).Include(z => z.AnimalSpecies).OrderBy(a => a.NewsId).ToListAsync();
        }

        public async Task<News> GetNewsById(int id)
        {
            return await _context.News.Include(x => x.Animal).Include(y => y.Employee).Include(z => z.AnimalSpecies).FirstOrDefaultAsync(a => a.NewsId == id);
        }

        public async Task<IEnumerable<News>> SearchNewsByTitle(string title)
        {
            return await _context.News.Include(x => x.Animal).Include(y => y.Employee).Include(z => z.AnimalSpecies).Where(a => a.Title.ToLower().Contains(title.Trim().ToLower())).ToListAsync();
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
            currentNews.Result.EmployeeId = newsDto.EmployeeId;
            await _context.SaveChangesAsync();
        }
    }
}
