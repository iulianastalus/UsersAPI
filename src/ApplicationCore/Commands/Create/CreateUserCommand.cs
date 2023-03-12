﻿using MediatR;

namespace Users.ApplicationCore.Commands;

public class CreateUserCommand : IRequest<CreateUserResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
}