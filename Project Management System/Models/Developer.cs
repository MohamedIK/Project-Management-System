namespace Project_Management_Systesm.Models
{
    public enum Role
    {
        None,
        Developer,
        Manager,
        Admin,
    }

    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; } = Role.None;
    }
}
