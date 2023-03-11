using MediatR;

namespace Users.ApplicationCore.Commands;

public class UpdateUserCommand : IRequest<UpdateUserResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
}
