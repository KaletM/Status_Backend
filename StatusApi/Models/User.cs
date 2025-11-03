using StatusApi.Models;

namespace StatusApi.Models
{
    
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public int RestaurantId { get; set; }
        public int RoleId { get; set; }

        public Restaurant? Restaurant { get; set; }
        public Role? Role { get; set; }
        
    }

}