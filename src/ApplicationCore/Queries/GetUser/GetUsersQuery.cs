using Users.ApplicationCore.Enum;

namespace Users.ApplicationCore.Queries;

public class GetUsersQuery
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool HasConnected { get; set; }
    public string DisplayName { get; set; }
    public List<OrderableField> OrderableFields { get; set; }
}

public class OrderableField
{
    public string Field { get; set; }
    public SortDirection SortDirection { get; set; }
}