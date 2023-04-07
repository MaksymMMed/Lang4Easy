using BLL.DTO.Request;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceExerciseController:ControllerBase
    {
        private readonly IVoiceExerciseService service;

        public VoiceExerciseController(IVoiceExerciseService service)
        {
            this.service = service;
        }

        [HttpPost("SayText")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CheckTranslate([FromQuery] VoiceExerciseRequest request)
        {
            try
            {
                await service.SayText(request);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
