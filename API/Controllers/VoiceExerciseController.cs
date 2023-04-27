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

        [HttpPost("CheckRecognizedText")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<bool>> CheckRecognizedText([FromBody] CheckVoiceRequest checkVoice)
        {
            try
            {
                var result = await service.CheckRecognizedText(checkVoice);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpPost("AddVoiceExercise")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddVoiceExercise([FromBody] VoiceExerciseRequest request)
        {
            try
            {
                await service.AddVoiceExercise(request);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpPut("UpdateVoiceExercise")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateVoiceExercise([FromBody] VoiceExerciseRequest request)
        {
            try
            {
                await service.UpdateVoiceExercise(request);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete("DeleteVoiceExerciseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> DeleteVoiceExerciseById(string id)
        {
            try
            {
                int _id = Int32.Parse(id);
                await service.DeleteVoiceExercise(_id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
