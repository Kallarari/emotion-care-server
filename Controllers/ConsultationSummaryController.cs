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
    public class ConsultationSummaryController : ControllerBase
    {
        private readonly IConsultationSummaryService _service;

        public ConsultationSummaryController(IConsultationSummaryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConsultationSummary>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultationSummary>> GetById(int id)
        {
            var summary = await _service.GetByIdAsync(id);
            if (summary == null) return NotFound();
            return Ok(summary);
        }

        [HttpPost]
        public async Task<ActionResult<ConsultationSummary>> Create(ConsultationSummary summary)
        {
            var createdSummary = await _service.CreateAsync(summary);
            return CreatedAtAction(nameof(GetById), new { id = createdSummary.Id }, createdSummary);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ConsultationSummary>> Update(int id, ConsultationSummary summary)
        {
            var updatedSummary = await _service.UpdateAsync(id, summary);
            if (updatedSummary == null) return NotFound();
            return Ok(updatedSummary);
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
