namespace Users.Domain.Entities;

public class UserEntity :BaseEntity
{   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
    public DateTime? LastConnectionDate { get; set; }
}

