using Microsoft.AspNetCore.Mvc;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierOrdersController : ControllerBase
    {
        private readonly ISupplierOrderRepository _repository;

        public SupplierOrdersController(ISupplierOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierOrder>>> GetAll()
        {
            var orders = await _repository.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierOrder>> GetById(int id)
        {
            var order = await _repository.GetByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierOrder>> Create(SupplierOrder order)
        {
            var created = await _repository.AddAsync(order);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SupplierOrder>> Update(int id, SupplierOrder order)
        {
            var updated = await _repository.UpdateAsync(id, order);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
