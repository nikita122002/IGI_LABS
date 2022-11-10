using Microsoft.AspNetCore.Identity;

namespace WEB_053502_KHARLAP.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] Image { get; set; }

       
    }
}
