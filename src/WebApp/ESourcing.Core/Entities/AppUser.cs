using Microsoft.AspNetCore.Identity;

namespace ESourcing.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirsName { get; set; }

        public string LastName { get; set; }

        public bool IsSaller { get; set; }

        public bool IsBuyer { get; set; }

        public bool IsAdmin { get; set; }

    }
}
