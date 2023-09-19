using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.IRepositories;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    
    public class ProductController : BaseApiController
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        private readonly BuggyController _buggy;

        public ProductController(IProductRepo productRepo, IMapper mapper, BuggyController buggy)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _buggy = buggy;
        }

        // GET: api/Product
        [HttpGet("products")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _productRepo.GetProducts();
            if (!ModelState.IsValid) 
                return _buggy.GetBadRequest();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        // GET: api/Product/5
        [HttpGet("products/{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            if (!await _productRepo.HasProduct(id)) 
                return _buggy.GetNotFound();
            var product = await _productRepo.GetProductById(id);
            if (!ModelState.IsValid) 
                return _buggy.GetBadRequest();
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("product/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            if (productDto == null) 
                return _buggy.GetBadRequest();
            if (id != productDto.Id)
            {
                return _buggy.GetBadRequest();
            }
            if (!ModelState.IsValid)
                return _buggy.GetBadRequest();
            if (!await _productRepo.UpdateProduct(_mapper.Map<Product>(productDto))) 
                return _buggy.GetUnprocessable();
            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("product")]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto productDto, [FromQuery] int categoryId)
        {
            if (productDto == null) 
                return _buggy.GetBadRequest();
            if (!ModelState.IsValid) 
                return _buggy.GetBadRequest();
            if (await _productRepo.HasProduct(productDto.Id)) 
                return _buggy.GetValidationError();
            var product = _mapper.Map<Product>(productDto);
            product.CategoryId = categoryId;
            if (!await _productRepo.CreateProduct(product)) 
                return _buggy.GetUnprocessable();
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("product/{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!await _productRepo.HasProduct(id))
                return _buggy.GetNotFound();
            var product = await _productRepo.GetProductById(id);
            if (!ModelState.IsValid)
                return _buggy.GetBadRequest();
            if (!await _productRepo.DeleteProduct(product))
                return _buggy.GetUnprocessable();
            return NoContent();
        }
        
    }
}
