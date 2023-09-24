using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        //[HttpGet("not-found")]
        //public ActionResult GetNotFound(string message)
        //{
        //    return NotFound(message);
        //}

        //[HttpGet("bad-request")]
        //public ActionResult GetBadRequest(string message)
        //{
        //    return BadRequest(new ProblemDetails { Title = message});
        //}

        //[HttpGet("unauthorized")]
        //public ActionResult GetUnauthorized()
        //{
        //    return Unauthorized();
        //}

        //[HttpGet("validation-error")]
        //public ActionResult GetValidationError(string message)
        //{
        //    ModelState.AddModelError("", message);
        //    return ValidationProblem();
        //}

        //[HttpGet("unprocessable")]
        //public ActionResult GetUnprocessable()
        //{
        //    return GetUnprocessable();
        //}
    }
}
