using MediatR;
using Users.ApplicationCore.Enum;
using Users.ApplicationCore.Interfaces;

namespace Users.ApplicationCore.Commands;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUsersRepository _usersRepository;
    public DeleteUserHandler(IUsersRepository usersRepository)
    {
        _usersRepository= usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
    }
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _usersRepository.Delete(request.Id);        
    }
}
