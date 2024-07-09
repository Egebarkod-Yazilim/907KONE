using Microsoft.AspNetCore.Identity;

namespace KONE.Entities.Concrete
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? IdentifierNumber { get; set; } = string.Empty;
        public string? KGKRegistrationNumber { get; set; } = string.Empty;
        public string? SerialNumber { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.MinValue;
        public string? PhoneNumber { get; set; } = string.Empty;

        public string? UserImage { get; set; }

        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string CreatedByName { get; set; } = "Admin";
        public virtual string ModifiedByName { get; set; } = "Admin";
        public virtual string? Note { get; set; }

        public ICollection<UserLoginHistory> UserLoginHistories { get; set; }
        public ICollection<ActivityLog> ActivityLogs { get; set; }
        public ICollection<UserFirmMapping> UserFirmMappings { get; set; }
    }
}
