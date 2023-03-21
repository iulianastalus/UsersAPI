using Users.ApplicationCore.Enum;

namespace Users.ApplicationCore;

public abstract class BaseResponse
{
    public Guid Id { get; set; }
    public OperationStatus Status { get; set; }
}
