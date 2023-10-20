using API.Models.Dtos;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TransactionHistoriesController : BaseApiController
    {
        private readonly ITransactionHistoriesRepository _transRepo;
        private readonly IMapper _mapper;

        public TransactionHistoriesController(ITransactionHistoriesRepository transactionHistoriesRepository, IMapper mapper)
        {
            _transRepo = transactionHistoriesRepository;
            _mapper = mapper;
        }

        [HttpGet("transactions", Name = "GetTransactions")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<TransactionHistoryDto>>> GetTransactions()
        {
            var transactions = await _transRepo.GetTransactions();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!transactions.Any())
            {
                return NotFound();
            }
            var transactionsDto = _mapper.Map<IEnumerable<TransactionHistoryDto>>(transactions);
            return Ok(transactionsDto);
        }
    }
}
