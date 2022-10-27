using Microsoft.AspNetCore.Mvc;

namespace FaceCheck.Controllers
{

    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FaceController : ControllerBase
    {

        public FaceController()
        {

        }

        [ApiVersion("1.0")]
        [ApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetFaces()
        {
            return Ok();
        }
    }
}