using System.Threading.Tasks;
using LibraryService.WebAPI.Entities;
using LibraryService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FraudController : ControllerBase
    {
        private readonly IFraudService _fraudService;

        public FraudController(IFraudService fraudService)
        {
            _fraudService = fraudService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var frauds = await _fraudService.Get(null);
            return Ok(frauds);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Fraud fraud)
        {
            var created = await _fraudService.Add(fraud);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
    }
}
