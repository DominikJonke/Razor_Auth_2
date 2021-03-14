using System.ComponentModel.DataAnnotations;

namespace MyAuth_Razor.Core.Entities
{
    public class AuthUser
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string UserRole { get; set; }
    }
}
