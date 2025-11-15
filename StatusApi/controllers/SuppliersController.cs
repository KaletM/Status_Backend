using Microsoft.AspNetCore.Mvc;
using StatusApi.Services.Repositories;
using StatusERP.Domain.Models;

namespace StatusApi.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _repository;

        public SuppliersController(ISupplierRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
        {
            var suppliers = await _repository.GetAllAsync();
            return Ok(suppliers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Supplier>> GetById(int id)
        {
            var supplier = await _repository.GetByIdAsync(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> Create(Supplier supplier)
        {
            var created = await _repository.AddAsync(supplier);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Supplier>> Update(int id, Supplier supplier)
        {
            var updated = await _repository.UpdateAsync(id, supplier);
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
