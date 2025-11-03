public class UserCreateDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int RestaurantId { get; set; }
    public int RoleId { get; set; }
}