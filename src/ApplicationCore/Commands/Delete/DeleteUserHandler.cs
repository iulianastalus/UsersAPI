using MediatR;
using Users.ApplicationCore.Enum;
using Users.ApplicationCore.Interfaces;

namespace Users.ApplicationCore.Commands;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
{
    private readonly IUsersRepository _usersRepository;
    public DeleteUserHandler(IUsersRepository usersRepository)
    {
        _usersRepository= usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
    }
    public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _usersRepository.Delete(request.Id);
        return new DeleteUserResponse
        {
            Id = request.Id,
            Status = response == true ? OperationStatus.Success : OperationStatus.Error
        };
    }
}
