using Microsoft.AspNetCore.Identity;

namespace neogym.core.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        
    }
}
