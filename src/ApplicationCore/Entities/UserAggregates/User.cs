using Users.ApplicationCore.Interfaces;

namespace Users.ApplicationCore.Entities.UserAggregates;

    public class UserEntity : IAggregateRoot
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }   
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public DateTime? LastConnectionDate { get; set; }
        public List<Audit> AuditTrail { get; set; }
    }

