using API.Models.Entities;

namespace API.Repositories
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetNews();
        Task<IEnumerable<News>> SearchNewsByTitle(string title);
        Task<News> GetNewsById(int id);
        Task DeleteNews(int id);
        Task CreateNews(News news);
        Task UpdateNews(int id, NewsDto newsDto);
    }
}
