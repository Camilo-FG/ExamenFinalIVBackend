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

        // GET api/fraud -> 200 con la lista de reportes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var frauds = await _fraudService.Get(null);
            return Ok(frauds);
        }

        // POST api/fraud -> 201 si se crea, 400 si los datos son inválidos
        [HttpPost]
        public async Task<IActionResult> Add(Fraud fraud)
        {
            // [Required] no rechaza cadenas con solo espacios; se valida aquí
            if (string.IsNullOrWhiteSpace(fraud.ImpostorDetails))
                return BadRequest(new { error = "Los detalles del impostor son obligatorios y no pueden estar vacíos." });

            if (string.IsNullOrWhiteSpace(fraud.ContactInfo))
                return BadRequest(new { error = "La información de contacto es obligatoria y no puede estar vacía." });

            var created = await _fraudService.Add(fraud);
            return CreatedAtAction(nameof(GetAll), new { id = created.Id }, created);
        }
    }
}
