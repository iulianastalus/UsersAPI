using AutoMapper;
using Users.ApplicationCore.Commands;
using Users.Domain.Entities;

namespace Users.ApplicationCore.Mappers;

public class ApplicationProfile :Profile
{
    public ApplicationProfile() 
    {
        CreateMap<CreateUserCommand, UserEntity>(); ;
    }
}
