

namespace Users.ApplicationCore.Commands;

public class UpdateUserResponse :BaseResponse
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime UpdatedDate { get; set; }

}
