using MediatR;

namespace Users.ApplicationCore.Commands;

public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}
