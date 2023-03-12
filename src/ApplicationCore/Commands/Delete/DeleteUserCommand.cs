using MediatR;

namespace Users.ApplicationCore.Commands;

public class DeleteUserCommand : IRequest<DeleteUserResponse>
{
    public Guid Id { get; set; }
}
