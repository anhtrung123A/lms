using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _manager;
        public StockController(ApplicationDBContext context, IStockRepository stockRepository, UserManager<AppUser> manager)
        {
            _context = context;
            _stockRepo = stockRepository;
            _manager = manager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll(){
            var user = await _manager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            var role = await _manager.GetRolesAsync(user!);
            return Ok();     
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var stock = await _stockRepo.FindByIdAsync(id);
            if (stock == null){
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto request){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var stockModel = request.ToStockFromRequestDTO();
            await _stockRepo.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto request){
            var stockModel = await _stockRepo.UpdateAsync(id, request);
            if (stockModel == null){
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var stockModel = await _stockRepo.DeleteAsync(id);
            if (stockModel == null){
                return NotFound();
            }
            return Ok();
        }
    }
}