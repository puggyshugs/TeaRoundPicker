using Microsoft.AspNetCore.Mvc;
using TeaRoundPicker.Domain.Models;
using TeaRoundPicker.Services.Interfaces;

namespace TeaRoundPicker.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public ParticipantController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("getAll")]
        public ActionResult<List<Participant>> GetAllParticipants()
        {
            var participants = _cacheService.GetAllParticipants();
            return Ok(participants);
        }

        [HttpGet("get/{name}")]
        public ActionResult<Participant> GetParticipant(string name)
        {
            var participant = _cacheService.GetParticipant(name);
            if (participant == null)
                return NotFound(Domain.Enums.SuccessMessages.ParticipantNotFound);

            return Ok(participant);
        }

        [HttpPost("create")]
        public ActionResult<string> CreateParticipant([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Participant name cannot be empty.");

            var result = _cacheService.CreateParticipant(name);

            return Ok(result);
        }

        [HttpPost("createMultiple")]
        public ActionResult<string> CreateParticipants([FromBody] List<string> names)
        {
            if (names == null || names.Count == 0)
                return BadRequest("Participant names cannot be empty.");

            var result = _cacheService.CreateParticipants(names);
            if (result == Domain.Enums.SuccessMessages.DuplicateParticipantName.ToString())
                return Conflict(result);

            return Ok(result);
        }
    }
}
