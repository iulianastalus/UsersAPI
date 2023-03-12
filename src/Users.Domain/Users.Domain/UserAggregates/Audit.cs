using System.ComponentModel.DataAnnotations;
namespace Users.Domain.UserAggregates;

public class Audit
{
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public string CreationUser { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public string LastUpdateUser { get; set; }
}
