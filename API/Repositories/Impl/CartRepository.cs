namespace API.Repositories.Impl
{
    public class CartRepository : ICartRepository
    {
        private readonly HttpClient _http;

        public CartRepository(HttpClient http)
        {
            _http = http;
        }
        //public async Task<string> Checkout()
        //{
        //    var result = await _http.PostAsJsonAsync("api/payment/checkout", await GetCartItem());
        //}
    }
}
