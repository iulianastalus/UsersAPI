
using FluentValidation;

namespace Users.ApplicationCore.Queries.GetUser;

public class GetUsersValidators : AbstractValidator<GetUsersQuery>
{
    public GetUsersValidators() 
    {
        List<string> UserQueryFields = new() 
        {
            "FirstName", "LastName", "Id", "HasConnected"
        };
        RuleFor(x => x.OrderableFields.Select(name => UserQueryFields.Contains(name.Field)));
    }
}
