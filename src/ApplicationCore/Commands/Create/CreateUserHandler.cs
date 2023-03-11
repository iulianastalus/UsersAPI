

using AutoMapper;
using MediatR;
using Users.ApplicationCore.Entities.UserAggregates;
using Users.ApplicationCore.Interfaces;

namespace Users.ApplicationCore.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    IUsersRepository _usersRepository;
    IMapper _mapper;

    public CreateUserHandler(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository= usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        _mapper = mapper ?? throw new ArgumentNullException();
    }
    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = _mapper.Map<UserEntity>(request);
        await _usersRepository.Create(userEntity);

        var user = await _usersRepository.GetById(userEntity.Id);
        
        return new CreateUserResponse
        {
           Id = user.Id,
           Success= user.Id != Guid.Empty,
        };

    }
}
