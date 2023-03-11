using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.ApplicationCore.Entities.UserAggregates;

public class Audit
{
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public string CreationUser { get; set;}
    public DateTime LastUpdateDate { get; set; }
    public string LastUpdateUser { get; set; }
}
