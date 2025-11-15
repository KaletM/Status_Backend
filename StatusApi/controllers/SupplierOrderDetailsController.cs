using Microsoft.AspNetCore.Mvc;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierOrderDetailsController : ControllerBase
    {
        private readonly ISupplierOrderDetailRepository _repository;

        public SupplierOrderDetailsController(ISupplierOrderDetailRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierOrderDetail>>> GetAll()
        {
            var details = await _repository.GetAllAsync();
            return Ok(details);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierOrderDetail>> GetById(int id)
        {
            var detail = await _repository.GetByIdAsync(id);
            if (detail == null) return NotFound();
            return Ok(detail);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierOrderDetail>> Create(SupplierOrderDetail detail)
        {
            var created = await _repository.AddAsync(detail);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SupplierOrderDetail>> Update(int id, SupplierOrderDetail detail)
        {
            var updated = await _repository.UpdateAsync(id, detail);
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
