using EmotionCareServer.Models;
using Microsoft.AspNetCore.Mvc;
using EmotionCareServer.Services;
using Microsoft.AspNetCore.Authorization;

namespace EmotionCareServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PsychologistController : ControllerBase
    {
        private readonly IPsychologistService _service;

        public PsychologistController(IPsychologistService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Psychologist>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Psychologist>> GetById(int id)
        {
            var psychologist = await _service.GetByIdAsync(id);
            if (psychologist == null) return NotFound();
            return Ok(psychologist);
        }

        [HttpPost]
        public async Task<ActionResult<Psychologist>> Create(Psychologist psychologist)
        {
            var created = await _service.CreateAsync(psychologist);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Psychologist>> Update(int id, Psychologist psychologist)
        {
            var updated = await _service.UpdateAsync(id, psychologist);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
