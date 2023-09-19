using API.Models;

namespace API.IRepositories
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
    }
}
