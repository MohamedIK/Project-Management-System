namespace ProjectManagementSystem.Models
{
    public enum Role
    {
        None,
        Developer,
        Manager,
        Admin
    }

    public class Developer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; } = Role.None;
    }
}