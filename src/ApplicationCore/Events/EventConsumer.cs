using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Users.ApplicationCore.Entities;
using Users.ApplicationCore.Interfaces;

namespace Users.ApplicationCore.Events
{
    public class EventConsumer : IConsumer<UserCreatedEvent>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        public EventConsumer(IMapper mapper, IUsersRepository usersRepository)
        {
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public async Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var userEntity = _mapper.Map<UserEntity>(context.Message);
            await _usersRepository.Create(userEntity);            
        }
    }
}
