using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime? Birthdate { get; set; }
        public int? PostalCode { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }

}