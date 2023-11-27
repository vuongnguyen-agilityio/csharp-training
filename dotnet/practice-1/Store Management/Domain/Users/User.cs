namespace Domain.Users
{
    public class User
    {
        public User(UserId id, string name, string email, string password, UserRole role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            Password = password;
        }

        public UserId Id { get; private set; }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public UserRole Role { get; private set; } = UserRole.User;
    }
}
