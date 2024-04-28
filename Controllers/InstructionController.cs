using Beachcombing_API.Models.Dto.Instruction;
using Microsoft.AspNetCore.Mvc;

namespace Beachcombing_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionController : ControllerBase
    {
        [HttpGet("Instruction")]
        public IActionResult GetInstructions()
        {
            var instructionDto = new InstructionDto
            {
                Title1 = "Beach Cleanup Guide! (Or find your group)",
                Url1 = "https://www.mcsuk.org/what-you-can-do/join-a-beach-clean/",
                Title2 = "Yikes, beach cleanup detailed instructions!",
                Url2 = "https://greenfins.net/blog/beach-cleanup/"
            };

            return Ok(instructionDto);
        }
    }
}
