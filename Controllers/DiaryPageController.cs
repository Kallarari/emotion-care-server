using EmotionCareServer.Models;
using EmotionCareServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmotionCareServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryPageController : ControllerBase
    {
        private readonly IDiaryPageService _diaryPageService;

        public DiaryPageController(IDiaryPageService diaryPageService)
        {
            _diaryPageService = diaryPageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var diaryPages = await _diaryPageService.GetAllAsync();
            return Ok(diaryPages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var diaryPage = await _diaryPageService.GetByIdAsync(id);
            if (diaryPage == null) return NotFound();

            return Ok(diaryPage);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DiaryPage diaryPage)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdDiaryPage = await _diaryPageService.CreateAsync(diaryPage);
            return CreatedAtAction(nameof(GetById), new { id = createdDiaryPage.Id }, createdDiaryPage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DiaryPage diaryPage)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedDiaryPage = await _diaryPageService.UpdateAsync(id, diaryPage);
            if (updatedDiaryPage == null) return NotFound();

            return Ok(updatedDiaryPage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _diaryPageService.DeleteAsync(id);
            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
