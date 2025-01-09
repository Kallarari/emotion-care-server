using EmotionCareServer.Models;
using EmotionCareServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionCareServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IndicationController : ControllerBase
    {
        private readonly IIndicationService _service;

        public IndicationController(IIndicationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Indication>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Indication>> GetById(int id)
        {
            var indication = await _service.GetByIdAsync(id);
            if (indication == null) return NotFound();
            return Ok(indication);
        }

        [HttpPost]
        public async Task<ActionResult<Indication>> Create(Indication indication)
        {
            var createdIndication = await _service.CreateAsync(indication);
            return CreatedAtAction(nameof(GetById), new { id = createdIndication.Id }, createdIndication);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Indication>> Update(int id, Indication indication)
        {
            var updatedIndication = await _service.UpdateAsync(id, indication);
            if (updatedIndication == null) return NotFound();
            return Ok(updatedIndication);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
