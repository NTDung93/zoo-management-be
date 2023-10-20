namespace API.Repositories
{
    public interface ICartRepository
    {
        Task<string> Checkout();
    }
}
