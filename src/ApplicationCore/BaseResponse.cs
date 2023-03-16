using Users.ApplicationCore.Enum;

namespace Users.ApplicationCore;

public class BaseResponse
{
    public Guid Id { get; set; }
    public OperationStatus Status { get; set; }
}
