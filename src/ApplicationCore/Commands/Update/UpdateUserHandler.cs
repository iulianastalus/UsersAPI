using MediatR;
using Users.ApplicationCore.Interfaces;

namespace Users.ApplicationCore.Commands;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
{
    private readonly IUsersRepository _usersRepository;
    public UpdateUserHandler(IUsersRepository usersRepository)
    {
        _usersRepository= usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
    }
    public Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
