using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
    }
}