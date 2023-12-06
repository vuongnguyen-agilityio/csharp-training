using Domain.Primitives;

namespace Domain.Users
{
    public class User : BaseEntity
    {
        public User(UserId id, string name, string email, string password, UserRole role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
            Password = password;
        }

        private User() {}

        public UserId Id { get; private set; }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public UserRole Role { get; private set; } = UserRole.User;

        public void Update(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public void UpdateRole(UserRole role)
        {
            Role = role;
        }
    }
}
