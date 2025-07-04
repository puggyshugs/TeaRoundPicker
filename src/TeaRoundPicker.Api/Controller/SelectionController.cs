using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaRoundPicker.Services.Helpers;
using TeaRoundPicker.Services.Interfaces;

namespace TeaRoundPicker.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SelectionController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public SelectionController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpGet("select")]
        public ActionResult<string> SelectParticipant()
        {
            var participants = _cacheService.GetAllParticipants();
            if (participants == null || participants.Count == 0)
                return NotFound("No participants available for selection.");

            var selectedParticipant = FairnessHelper.PickRandom(participants);
            return Ok(selectedParticipant.Name);
        }
    }
}
