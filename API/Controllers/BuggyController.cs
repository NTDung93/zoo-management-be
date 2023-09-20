using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("bad-request")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ProblemDetails { Title = "This is a bad request!"});
        }

        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("validation-error")]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("Error 1", "Duplicate of ID!");
            ModelState.AddModelError("Error 2", "Field is required!");
            return ValidationProblem();
        }

        [HttpGet("unprocessable")]
        public ActionResult GetUnprocessable()
        {
            return GetUnprocessable();
        }
    }
}
