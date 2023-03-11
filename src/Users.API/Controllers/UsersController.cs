using Microsoft.AspNetCore.Mvc;

namespace Users.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    public UsersController() { }

    [HttpGet]
    public IActionResult Get(string id)
    {
        return Ok(new { id });
    }

    [HttpPost]
    public IActionResult Crea(string id)
    {
        return Ok();
    }
}
