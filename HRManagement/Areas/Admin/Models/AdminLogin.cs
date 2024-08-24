using System.ComponentModel.DataAnnotations;

namespace HRManagement.Areas.Admin.Models
{
    public class AdminLogin
    {
        [Key]
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; private set; }

        public void setRole()
        {
            Role = "Admin";
        }
    }
    public class JWTTokenResponse
    {
        public string? Token { get; set; }
    }
}

