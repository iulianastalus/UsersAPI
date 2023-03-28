using Microsoft.AspNetCore.Mvc;
using Users.ApplicationCore.Commands;
using MediatR;
namespace Users.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator) 
    {
        _mediator= mediator;
    }

    [HttpGet("GetUserDetails")]
    public IActionResult GetUserDetails(string id)
    {
        return Ok(new { id });
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUserCommand createUser)
    {
        createUser.Id = Guid.NewGuid();
        var result = await _mediator.Send(createUser);
        return Ok(result);
    }

    [HttpPost("DeleteUser")]
    public async Task<IActionResult> DeleteUser(DeleteUserCommand deleteUser)
    {
        await _mediator.Send(deleteUser);

        return Ok(new DeleteUserResponse
        {
            Id = deleteUser.Id,
            Status = ApplicationCore.Enum.OperationStatus.Success,
        });
    }

    [HttpPost("UpdateUser")]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUser)
    {
        await _mediator.Send(updateUser);

        return Ok(new UpdateUserResponse
        {
            Id = updateUser.Id,
            Status = ApplicationCore.Enum.OperationStatus.Success,
        });
    }

    [HttpPost]
    public async Task<IActionResult> RestoreUsersDb(RestoreUsersCommand restoreUsers)
    {
        var result = await _mediator.Send(restoreUsers);
        return Ok(new RestoreUserResponse
        {
            Id = result.Id,
            Status = ApplicationCore.Enum.OperationStatus.Success

        });
    }
}
