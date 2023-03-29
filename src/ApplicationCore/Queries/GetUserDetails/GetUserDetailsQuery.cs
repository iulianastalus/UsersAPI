using MediatR;

namespace Users.ApplicationCore.Queries.GetUserDetails;

public class GetUserDetailsQuoery : IRequest<GetUserDetailsResponse>
{
    public int Id { get; set; }
}
