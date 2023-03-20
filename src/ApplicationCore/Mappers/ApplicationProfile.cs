using AutoMapper;
using EventBus.Messages.Events;
using Users.ApplicationCore.Entities;

namespace Users.ApplicationCore.Mappers;

public class ApplicationProfile :Profile
{
    public ApplicationProfile() 
    {
        CreateMap<UserCreatedEvent, UserEntity>();
    }
}
