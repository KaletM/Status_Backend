using Microsoft.AspNetCore.Mvc;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryMovementsController : ControllerBase
    {
        private readonly IInventoryMovementRepository _repository;

        public InventoryMovementsController(IInventoryMovementRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryMovement>>> GetAll()
        {
            var items = await _repository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InventoryMovement>> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<InventoryMovement>> Create(InventoryMovement movement)
        {
            var created = await _repository.AddAsync(movement);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<InventoryMovement>> Update(int id, InventoryMovement movement)
        {
            var updated = await _repository.UpdateAsync(id, movement);
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
