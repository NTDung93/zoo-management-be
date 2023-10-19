using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ImportHistoriesController : BaseApiController
    {
        private readonly IImportHistoryRepository _importHistoryRepository;
        private readonly IMapper _mapper;

        public ImportHistoriesController(IImportHistoryRepository importHistoryRepository, 
            IMapper mapper)
        {
            _importHistoryRepository = importHistoryRepository;
            _mapper = mapper;
        }

        [HttpGet("import-histories")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ImportHistoryResponse>>> GetImportHistories()
        {
            var impHistories = await _importHistoryRepository.GetImportHistories();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var mappedImpHistories = _mapper.Map<IEnumerable<ImportHistoryResponse>>(impHistories);
            return Ok(mappedImpHistories);
        }

        [HttpPost("import-food")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ImportHistoryResponse>> ImportAFood([FromBody] ImportHistoryRequest import)
        {
            if (import.ImportQuantity <= 0) return BadRequest(new ProblemDetails
            {
                Title = "Import quantity must be positive integer!"
            });

            if (string.IsNullOrEmpty(import.FoodId)) return BadRequest(new ProblemDetails
            {
                Title = "Food's id must not be empty!"
            });

            var mappedImport = _mapper.Map<ImportHistory>(import);
            var result = await _importHistoryRepository.ImportAFood(mappedImport);
            if (!result) return BadRequest(new ProblemDetails
            {
                Title = "An error occurs while importing a food!"
            });
            return CreatedAtAction(nameof(GetImportHistories), new {no = mappedImport.No}, 
                _mapper.Map<ImportHistoryResponse>(mappedImport));
        }

    }
}
