using A.Api.Insfrastructure;
using Microsoft.AspNetCore.Mvc;

namespace A.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BaseController : ControllerBase
{
    protected IActionResult GenericClientError(string message)
    {
        List<string> errors = new List<string>() { message };

        var error = new HttpErrorResponse(errors);

        return BadRequest(error);
    }

    protected void EnsureModelValidity()
    {
        if (ModelState.IsValid) return;

        var errors = new List<Exception>();
        var err = ModelState.Values.SelectMany(v => v.Errors);

        foreach (var item in err)
        {
            var ex = new Exception(item.ErrorMessage);
            errors.Add(ex);
        }

        throw new AggregateException(errors);
    }
}
