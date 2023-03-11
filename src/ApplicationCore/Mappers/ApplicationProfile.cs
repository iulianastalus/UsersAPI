using AutoMapper;
using Users.ApplicationCore.Commands;
using Users.ApplicationCore.Entities.UserAggregates;

namespace Users.ApplicationCore.Mappers;

public class ApplicationProfile :Profile
{
    public ApplicationProfile() 
    {
        CreateMap<CreateUserCommand, UserEntity>();
    }
}
